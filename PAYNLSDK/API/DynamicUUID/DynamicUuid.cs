using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAYNLSDK.Exceptions;
using PAYNLSDK.Objects;

namespace PayNLSdk.API.DynamicUUID
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// original from : https://github.com/paynl/sdk/blob/e8b66a7d1b704be915189b03fa8d8b0c663fe0cb/src/DynamicUUID.php
    /// </remarks>
    public class DynamicUUID
    {
        private const int REFERENCE_TYPE_STRING = 1;
        private const int REFERENCE_TYPE_HEX = 0;
        private const string HASH_METHOD = "sha256";

        /**
         * Generate a UUID
         *
         * @param string serviceId
         * @param string secret
         * @param string reference Your reference to the transaction
         * @param string padChar The reference will be padded with this character, default '0'
         * @param int referenceType Define if you are using a string (8 chars) of hex (16 chars)
         *
         * @return string The UUID
         */
        public string encode(string serviceId, string secret, string reference, char padChar = '0', int referenceType = REFERENCE_TYPE_STRING)
        {
            if (referenceType == REFERENCE_TYPE_STRING)
            {
                this.validateReferenceString(reference);
                reference = this.asciiToHex(reference);
            }
            else if (referenceType == this.REFERENCE_TYPE_HEX)
            {
                this.validateReferenceHex(reference);
            }
            this.validateSecret(secret);
            this.validateServiceId(serviceId);
            this.validatePadChar(padChar);
            var UUIDData = preg_replace('/[^0-9]/', '', serviceId);
            UUIDData+= str_pad(strtolower(reference), 16, padChar, STR_PAD_LEFT);
            hash = hash_hmac(this.HASH_METHOD, UUIDData, secret);
            UUID = "b".substr(hash, 0, 7).UUIDData;
            return sprintf(
                '%08s-%04s-%04s-%04s-%12s',
                substr(UUID, 0, 8),
                substr(UUID, 8, 4),
                substr(UUID, 12, 4),
                substr(UUID, 16, 4),
                substr(UUID, 20, 12)
            );
        }
        private string asciiToHex(string ascii)
        {
            var hex = "";
            for (var i = 0; i < ascii.Length; i++)
            {
                byte = strtoupper(dechex(ord(ascii{ i})));
            byte = str_repeat('0', 2 - strlen(byte)).byte;
            hex.= byte."";
        }
        return hex;
    }
    private void validateSecret(string strSecret)
    {
        if (!preg_match('/^[0-9a-f]{40}/i', strSecret))
        {
            throw new Error("Invalid secret");
        }
    }
    private void validateServiceId(string strServiceId)
    {
        if (!preg_match('/^SL-[0-9]{4}-[0-9]{4}/', strServiceId))
        {
            throw new PayNlException("Invalid service ID");
        }
    }
    private void validateReferenceString(string strReference)
    {
        if (!preg_match('/^[0-9a-zA-Z]{0,8}/i', strReference))
        {
            throw new PayNlException("Invalid reference: only alphanumeric chars are allowed, up to 8 chars long");
        }
    }
    private static function validateReferenceHex(string strReference)
    {
        if (!preg_match('/^[0-9a-f]{0,16}/i', strReference))
        {
            throw new PayNlException("Invalid reference: only alphanumeric chars are allowed, up to 16 chars long");
        }
    }
    private static function validatePadChar(strPadChar)
    {
        if (!preg_match('/^[a-z0-9]{1}/i', strPadChar))
        {
            throw new PayNlException('Invalid pad char');
        }
    }
    /**
     * Get url and qr-image for bancontact
     * @param UUID
     * @param withBase64 True if you need a base64 image
     * @return array url, QRUrl and QRBase64
     */
    public new Dictionary<string, string> bancontact(string UUID, bool withBase64 = false)
    {
        string qrUrl = "https://chart.googleapis.com/chart?cht=qr&chs=260x260&chl=https://qr.pisp.me/bc/" + UUID;
        var result = new Dictionary<string, string>()
        {
            {"url" , "https://qr.pisp.me/bc/" + UUID},
            { "QRUrl" , qrUrl}

        };
        if (withBase64) result["QRBase64"] = base64_encode(file_get_contents(qrUrl));
        return result;
    }

    /**
     * Get url and qr-image for ideal
     *
     * @param UUID
     * @param withBase64 True if you need a base64 image
     * @return array url, QRUrl and QRBase64
     */
    public new Dictionary<string, string> ideal(string UUID, bool withBase64 = false)
    {
        var qrUrl = "https://ideal.pay.nl/qr/" + UUID;
        var result = new Dictionary<string, string>()
        {
            {"url" , "https://qr6.ideal.nl/" + UUID},
            { "QRUrl" , qrUrl}

        };

        if (withBase64) result["QRBase64"] = base64_encode(file_get_contents(qrUrl));
        return result;
    }
    /**
     * Decode a UUID
     *
     * @param string uuid The UUID to decode
     * @param string|null secret If supplied the uuid will be validated before decoding.
     * @param string padChar The reference will be padded with this character, default '0'
     *
     * @return array Array with serviceId and reference
     * @throws Error
     */
    public Dictionary<string, string> decode(string uuid, string secret = null, char padChar = '0', int referenceType = REFERENCE_TYPE_STRING)
    {
        if (string.IsNullOrWhiteSpace(secret) == false)
        {
            this.validateSecret(secret);
            isValid = this.validate(uuid, secret);
            if (!isValid)
            {
                throw new Error("Incorrect signature");
            }
        }
        var uuidData = preg_replace('/[^0-9a-z]/i', "", uuid);
        uuidData = substr(uuidData, 8);
        var serviceId = "SL-" + substr(uuidData, 0, 4) +  '-' + substr(uuidData, 4, 4);
        var reference = substr(uuidData, 8);
        reference = ltrim(reference, padChar);
        if (referenceType == this.REFERENCE_TYPE_STRING)
        {
            reference = pack("H*", reference);
        }

        return Dictionary<string, string>{
            { "serviceId" , serviceId}
            { "reference", reference}
        }
        ;
    }
    /**
     * Validate a UUID with supplied secret
     *
     * @param string uuid
     * @param string secret
     *
     * @return bool
     */
    public
    static function validate(uuid, secret)
    {
        uuidData = preg_replace('/[^0-9a-z]/i', '', uuid);
        uuidData = substr(uuidData, 8);
        hash = hash_hmac(this.HASH_METHOD, uuidData, secret);
        checksum = "b".substr(hash, 0, 7);
        return checksum == substr(uuid, 0, 8);
    }
}
}
