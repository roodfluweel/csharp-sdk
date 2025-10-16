using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAYNLSDK.API.DynamicUUID;
using PAYNLSDK.Exceptions;

namespace PayNLSdk.Tests
{
    [TestClass]
    public class DynamicUuidTests
    {
        private const string ServiceId = "SL-1234-1234";
        private const string Secret = "abcdef1234567890abcdef1234567890abcdef12";
        private const string Reference = "INV001";
        private const string ExpectedUuid = "b0898a33-1234-1234-0000-494e56303031";

        [TestMethod]
        public void Encode_GeneratesExpectedUuid()
        {
            var uuid = DynamicUuid.Encode(ServiceId, Secret, Reference);

            Assert.AreEqual(ExpectedUuid, uuid);
        }

        [TestMethod]
        public void Validate_ReturnsTrueForKnownUuid()
        {
            var isValid = DynamicUuid.Validate(ExpectedUuid, Secret);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void Decode_ReturnsServiceIdAndReference()
        {
            var result = DynamicUuid.Decode(ExpectedUuid, Secret);

            Assert.AreEqual(ServiceId, result.ServiceId);
            Assert.AreEqual(Reference, result.Reference);
        }

        [TestMethod]
        public void Encode_WithInvalidSecret_ThrowsException()
        {
            Assert.ThrowsException<PayNlException>(() => DynamicUuid.Encode(ServiceId, "123", Reference));
        }

        [TestMethod]
        public void GetIdealQr_WithBase64_UsesProvidedDownloader()
        {
            var expectedBytes = new byte[] { 1, 2, 3 };
            string capturedUrl = null;

            var info = DynamicUuid.GetIdealQr(ExpectedUuid, true, uri =>
            {
                capturedUrl = uri.ToString();
                return expectedBytes;
            });

            Assert.AreEqual("https://qr6.ideal.nl/" + ExpectedUuid, info.Url);
            Assert.AreEqual("https://ideal.pay.nl/qr/" + ExpectedUuid, info.QrUrl);
            Assert.AreEqual(Convert.ToBase64String(expectedBytes), info.QrBase64);
            Assert.AreEqual("https://ideal.pay.nl/qr/" + ExpectedUuid, capturedUrl);
        }

        [TestMethod]
        public void GetBancontactQr_WithBase64_UsesProvidedDownloader()
        {
            var expectedBytes = new byte[] { 4, 5, 6 };
            string capturedUrl = null;

            var info = DynamicUuid.GetBancontactQr(ExpectedUuid, true, uri =>
            {
                capturedUrl = uri.ToString();
                return expectedBytes;
            });

            var expectedRedirect = "https://qr.pisp.me/bc/" + ExpectedUuid;
            var expectedQrUrl =
                "https://chart.googleapis.com/chart?cht=qr&chs=260x260&chl=" +
                Uri.EscapeDataString(expectedRedirect);

            Assert.AreEqual(expectedRedirect, info.Url);
            Assert.AreEqual(expectedQrUrl, info.QrUrl);
            Assert.AreEqual(Convert.ToBase64String(expectedBytes), info.QrBase64);
            Assert.AreEqual(expectedQrUrl, capturedUrl);
        }
    }
}
