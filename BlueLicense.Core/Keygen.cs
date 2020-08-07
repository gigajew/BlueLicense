using BlueLicense.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlueLicense.Core
{
    public static class Keygen
    {
        /// <summary>
        /// Generate a license for the particular user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static License GenerateLicense(User user)
        {
            License license;
            using (SHA256 sha = SHA256CryptoServiceProvider.Create())
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(BlueConfiguration.PrivateKey);
                byte[] hash = rsa.SignData(user.GetSignature(), sha);
                string licenseKey = Convert.ToBase64String(hash);
                license = License.Create(user, licenseKey);
            }
            return license;
        }
    }
}
