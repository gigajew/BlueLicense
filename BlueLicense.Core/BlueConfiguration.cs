using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlueLicense.Core
{
    public static class BlueConfiguration
    {
        public static string PrivateKey { get; set; }
        public static string PublicKey { get; set; }

        public static Encoding DefaultEncoding { get; set; } = new UTF8Encoding(false, false);


        static BlueConfiguration()
        {
            using (SHA256 sha = SHA256CryptoServiceProvider.Create())
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                PrivateKey = rsa.ToXmlString(true);
                PublicKey = rsa.ToXmlString(false);
            }
        }
    }
}
