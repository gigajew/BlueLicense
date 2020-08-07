# Blue License
A simple license key generator and validation framework. Generate users as well as licenses and validate them on the fly.

## Contents
### BlueLicense.Core
Contains the core files for the framework

### BlueLicense.Tests
Test different features within the framework

## Usage
Import the core framework
```c#
using BlueLicense.Core;
using BlueLicense.Core.Models;
```

Set your public or private key (don't include your private key for end-user software)
```c#
BlueConfiguration.PrivateKey = "<RSAKeyValue><Modulus>mvKmd7KI63G5/ORoX6wJ0wGi3eWAeOQtGRo3qqDLVkLGUsVH+s4N2WiSRUjgw0YowWl3zzFhK+QB+R4rg9g1LgPL8KLlcduKX967XI0Ik4aUYNWrmYTkcD7s0AdTqbuMh1Tg6N2MbN2L9keN5EZ9hJ6WdwfDbse59uWA2BltdjE=</Modulus><Exponent>AQAB</Exponent><P>wqFGBWFtPaw1RLHS5KHGVt6BpzS3avCHUitqf0ZAsComosE4uuxhZzzH1JtYriqQ9HJMrPLJm4GX356hhI9pKw==</P><Q>y84yNBHGf8E3OXN/X6Po0Or2LlMKphTMFpL6N7n48ceSq0WQgT+KCX0RfpT6Wj3oG6j1Jqmvq1YQzdpJLTX4Ew==</Q><DP>oAg5ae0tBJvXhO9uR73ZNs5n7xNCiXTS37aBL7uVLwTJleOogNIiWN+6M8+0AClR3R0qfL55FRtexGlLx5Kf1w==</DP><DQ>CVt5QJzEUV9Mqs2bvodnDBiNnwjfB0sTJ8ItzNs0C93O5SA3h0ekjdT5Naefav9GpeZ3AwRtdV9pPBpWm8XLkw==</DQ><InverseQ>JtSeD/slFy+orgNlAgS2x07HnEkF659H7KhCKsdfjITmS2pOOOwR9QX3/Gw6jrYZHGTdLMwbo1JiVyxGa8bsng==</InverseQ><D>iViFTpym2WyZnB0ql4N7wdo1b9O7KW24vAONTGXzV6cg/MV6pEp55DjZTyjmcrGB9s9yL+ppY+pcBWJE2D2SBLKTIPj3FzDCIMmAteUBPET6P8ar/pLrNjh0NROioj9QBUf1mQwG6zJ2nMvPFKufI/tMI0DzN7Li5sqr3DiBuPE=</D></RSAKeyValue>";
BlueConfiguration.PublicKey = "<RSAKeyValue><Modulus>mvKmd7KI63G5/ORoX6wJ0wGi3eWAeOQtGRo3qqDLVkLGUsVH+s4N2WiSRUjgw0YowWl3zzFhK+QB+R4rg9g1LgPL8KLlcduKX967XI0Ik4aUYNWrmYTkcD7s0AdTqbuMh1Tg6N2MbN2L9keN5EZ9hJ6WdwfDbse59uWA2BltdjE=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
```

Create a new user (assuming you've set the private key part)
```c#
var user = User.Create("John", "Doe", "john.doe@aol.com");
```

Generate a license for this user
```c#
var license = Keygen.GenerateLicense(user);
```

Validate user license key
```c#
var isValidLicense = license.IsValidLicense();
Console.WriteLine("Is valid license: {0}", isValidLicense ? "Yes" : "No");
```

## Contribute
Feel free to contribute to this project and make it better.