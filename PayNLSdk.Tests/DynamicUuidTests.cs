using System;
using Shouldly;
using Xunit;
using PayNlSdk.API.DynamicUUID;
using PayNlSdk.Exceptions;

namespace PayNlSdk.Tests
{
    public class DynamicUuidTests
    {
        private const string ServiceId = "SL-1234-1234";
        private const string Secret = "abcdef1234567890abcdef1234567890abcdef12";
        private const string Reference = "INV001";
        private const string ExpectedUuid = "b0898a33-1234-1234-0000-494e56303031";

        [Fact]
        public void Encode_GeneratesExpectedUuid()
        {
            var uuid = DynamicUuid.Encode(ServiceId, Secret, Reference);

            uuid.ShouldBe(ExpectedUuid);
        }

        [Fact]
        public void Validate_ReturnsTrueForKnownUuid()
        {
            var isValid = DynamicUuid.Validate(ExpectedUuid, Secret);

            isValid.ShouldBeTrue();
        }

        [Fact]
        public void Decode_ReturnsServiceIdAndReference()
        {
            var result = DynamicUuid.Decode(ExpectedUuid, Secret);

            result.ServiceId.ShouldBe(ServiceId);
            result.Reference.ShouldBe(Reference);
        }

        [Fact]
        public void Encode_WithInvalidSecret_ThrowsException()
        {
            Should.Throw<PayNlException>(() => DynamicUuid.Encode(ServiceId, "123", Reference));
        }

        [Fact]
        public void GetIdealQr_WithBase64_UsesProvidedDownloader()
        {
            var expectedBytes = new byte[] { 1, 2, 3 };
            string capturedUrl = null;

            var info = DynamicUuid.GetIdealQr(ExpectedUuid, true, uri =>
            {
                capturedUrl = uri.ToString();
                return expectedBytes;
            });

            info.Url.ShouldBe("https://qr6.ideal.nl/" + ExpectedUuid);
            info.QrUrl.ShouldBe("https://ideal.pay.nl/qr/" + ExpectedUuid);
            info.QrBase64.ShouldBe(Convert.ToBase64String(expectedBytes));
            capturedUrl.ShouldBe("https://ideal.pay.nl/qr/" + ExpectedUuid);
        }

        [Fact]
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

            info.Url.ShouldBe(expectedRedirect);
            info.QrUrl.ShouldBe(expectedQrUrl);
            info.QrBase64.ShouldBe(Convert.ToBase64String(expectedBytes));
            capturedUrl.ShouldBe(expectedQrUrl);
        }
    }
}
