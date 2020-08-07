using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlueLicense.Core.Models
{
    public class License
    {
        public DateTime CreationDate { get; protected set; }
        public User User { get; protected set; }

        public string Key { get; protected set; }

        private License() { }

        private License(User user)
        {
            this.User = user;
        }

        public static License Create(User user, string key)
        {
            License license = new License(user);
            license.CreationDate = DateTime.UtcNow;
            license.Key = key;
            return license;
        }

        public bool IsValidLicense()
        {
            using (SHA256 sha = SHA256CryptoServiceProvider.Create())
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                byte[] signature = Convert.FromBase64String(Key);
                rsa.FromXmlString(BlueConfiguration.PublicKey);
                return rsa.VerifyData(User.GetSignature(), sha, signature);
            }
        }

        public static License Deserialize(BinaryReader reader)
        {
            License license = new License();
                license.CreationDate = new DateTime(reader.ReadInt64(), DateTimeKind.Utc);
                license.User = User.Deserialize(reader);
                license.Key = reader.ReadString();
            return license;
        }

        public void Serialize(BinaryWriter writer)
        {
                writer.Write(CreationDate.Ticks);
                User.Serialize(writer);
                writer.Write(Key);
        }
    }
}
