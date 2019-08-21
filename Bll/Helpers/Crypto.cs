using System;
using System.Security.Cryptography;
using System.Text;

namespace Bll.Helpers
{
    public static class Crypto
    {
        public static string EncryptoMD5(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            Byte[] originalBytes = encoder.GetBytes(password);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            password = BitConverter.ToString(encodedBytes).Replace("-", "");
            var result = password.ToUpper();
            return result;
        }
    }
}
