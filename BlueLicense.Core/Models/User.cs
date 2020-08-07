using BlueLicense.Core.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlueLicense.Core.Models
{
    public class User
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string EmailAddress { get; protected set; }

        private User() { }

        private User(string firstname, string lastname, string emailaddress)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.EmailAddress = emailaddress;
        }

        public static User Create(string firstname, string lastname, string email)
        {
            return new User(firstname, lastname, email);
        }

        public byte[] GetSignature()
        {
            using (MemoryStream memory = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(memory, BlueConfiguration.DefaultEncoding))
            {
                writer.WriteNormalized(FirstName);
                writer.WriteNormalized(LastName);
                writer.WriteNormalized(EmailAddress);

                return memory.ToArray();
            }
        }

        public static User Deserialize(BinaryReader reader)
        {
            User user = new User();
            user.FirstName = reader.ReadString();
            user.LastName = reader.ReadString();
            user.EmailAddress = reader.ReadString();
            return user;
        }

        public void Serialize(BinaryWriter writer)
        {
            writer.Write(FirstName);
            writer.Write(LastName);
            writer.Write(EmailAddress);
            writer.Flush();
        }
    }
}
