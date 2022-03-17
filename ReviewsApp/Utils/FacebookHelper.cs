using Newtonsoft.Json.Linq;
using ReviewsApp.Models.Settings;
using System;
using System.Text;

namespace ReviewsApp.Utils
{
    public class FacebookHelper
    {
        private readonly string _signedRequest;
        private string[] _requestData;
        private string _encodedSignature;
        private string _payload;
        private JObject _jsonObject;

        public FacebookHelper(string signedRequest)
        {
            _signedRequest = signedRequest;
            InitRequestData();
            InitJsonObject();
        }

        public string GetExpectedHash()
        {
            var appSecretBytes = Encoding.UTF8.GetBytes(Secrets.FacebookWebAppSecret);
            var hmac = new System.Security.Cryptography.HMACSHA256(appSecretBytes);
            var expectedHash = Convert.ToBase64String(hmac.ComputeHash(
                    Encoding.UTF8.GetBytes(_signedRequest.Split('.')[1])))
                .Replace('-', '+')
                .Replace('_', '/');

            return expectedHash;
        }

        private static string EncodeData(string data)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(data));
        }

        private void InitRequestData()
        {
            _requestData = _signedRequest.Split('.');
            if (!string.IsNullOrWhiteSpace(_requestData[0]))
            {
                _encodedSignature = FormatData(_requestData[0]);
            }
            if (!string.IsNullOrWhiteSpace(_requestData[1]))
            {
                _payload = FormatData(_requestData[1]);
            }
        }

        private static string FormatData(string data)
        {
            int mod4 = data.Length % 4;
            if (mod4 > 0)
            {
                data += new string('=', 4 - mod4);
            }
            data = data
                .Replace('-', '+')
                .Replace('_', '/');
            return data;
        }

        private void InitJsonObject()
        {
            var rawData = EncodeData(_payload);
            _jsonObject = JObject.Parse(rawData);
        }

        public string GetEncodedSignature()
        {
            return _encodedSignature;
        }

        public string GetPayload()
        {
            return _payload;
        }

        public JObject GetJsonObject()
        {
            return _jsonObject;
        }
    }
}
