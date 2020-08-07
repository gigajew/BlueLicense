using System;
using System.IO;
using BlueLicense.Core;
using BlueLicense.Core.Models;

namespace BlueLicense.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            SetDefaultKeyPair();

            Console.WriteLine("=== Generation Test ===");
            User john = GenerateTestUser();
            License johnsLicense = GenerateTestLicense(john);
            License deserialized;

            Console.WriteLine("Is valid license: {0}", johnsLicense.IsValidLicense() ? "Yes" : "No");

            Console.WriteLine("=== Deserialization Test ===");

            byte[] licenseChunk;
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream, BlueConfiguration.DefaultEncoding))
            {
                johnsLicense.Serialize(writer);
                licenseChunk = stream.ToArray();
            }

            using ( MemoryStream stream = new MemoryStream(licenseChunk ))
            using ( BinaryReader reader = new BinaryReader(stream, BlueConfiguration.DefaultEncoding ))
            {
                deserialized = License.Deserialize(reader);
            }

            Console.WriteLine("First name: {0}", deserialized.User.FirstName);
            Console.WriteLine("Last name: {0}", deserialized.User.LastName);
            Console.WriteLine("Email Address: {0}", deserialized.User.EmailAddress);
            Console.WriteLine("License Created: {0}", deserialized.CreationDate);
            Console.WriteLine("License Key: {0}", deserialized.Key);
            Console.WriteLine("Is Valid: {0}", deserialized.IsValidLicense() ? "Yes" : "No");

            Console.ReadLine();
        }

        static void SetDefaultKeyPair()
        {
            BlueConfiguration.PrivateKey = "<RSAKeyValue><Modulus>mvKmd7KI63G5/ORoX6wJ0wGi3eWAeOQtGRo3qqDLVkLGUsVH+s4N2WiSRUjgw0YowWl3zzFhK+QB+R4rg9g1LgPL8KLlcduKX967XI0Ik4aUYNWrmYTkcD7s0AdTqbuMh1Tg6N2MbN2L9keN5EZ9hJ6WdwfDbse59uWA2BltdjE=</Modulus><Exponent>AQAB</Exponent><P>wqFGBWFtPaw1RLHS5KHGVt6BpzS3avCHUitqf0ZAsComosE4uuxhZzzH1JtYriqQ9HJMrPLJm4GX356hhI9pKw==</P><Q>y84yNBHGf8E3OXN/X6Po0Or2LlMKphTMFpL6N7n48ceSq0WQgT+KCX0RfpT6Wj3oG6j1Jqmvq1YQzdpJLTX4Ew==</Q><DP>oAg5ae0tBJvXhO9uR73ZNs5n7xNCiXTS37aBL7uVLwTJleOogNIiWN+6M8+0AClR3R0qfL55FRtexGlLx5Kf1w==</DP><DQ>CVt5QJzEUV9Mqs2bvodnDBiNnwjfB0sTJ8ItzNs0C93O5SA3h0ekjdT5Naefav9GpeZ3AwRtdV9pPBpWm8XLkw==</DQ><InverseQ>JtSeD/slFy+orgNlAgS2x07HnEkF659H7KhCKsdfjITmS2pOOOwR9QX3/Gw6jrYZHGTdLMwbo1JiVyxGa8bsng==</InverseQ><D>iViFTpym2WyZnB0ql4N7wdo1b9O7KW24vAONTGXzV6cg/MV6pEp55DjZTyjmcrGB9s9yL+ppY+pcBWJE2D2SBLKTIPj3FzDCIMmAteUBPET6P8ar/pLrNjh0NROioj9QBUf1mQwG6zJ2nMvPFKufI/tMI0DzN7Li5sqr3DiBuPE=</D></RSAKeyValue>";
            BlueConfiguration.PublicKey = "<RSAKeyValue><Modulus>mvKmd7KI63G5/ORoX6wJ0wGi3eWAeOQtGRo3qqDLVkLGUsVH+s4N2WiSRUjgw0YowWl3zzFhK+QB+R4rg9g1LgPL8KLlcduKX967XI0Ik4aUYNWrmYTkcD7s0AdTqbuMh1Tg6N2MbN2L9keN5EZ9hJ6WdwfDbse59uWA2BltdjE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        }

        static User GenerateTestUser()
        {
            return User.Create("John", "Doe", "john.doe@aol.com");
        }

        static License GenerateTestLicense(User user)
        {
            return Keygen.GenerateLicense(user);
        }

        static void PrintNewKeyPair()
        {
            Console.WriteLine(BlueConfiguration.PrivateKey);
            Console.WriteLine();
            Console.WriteLine(BlueConfiguration.PublicKey);
            Console.ReadLine();
        }
    }
}
