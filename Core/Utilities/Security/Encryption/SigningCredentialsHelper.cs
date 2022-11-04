using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper  //Bu class asp.net'e der ki : anahtar olarak bu security key'i kullan, güvenlik olarak daha HmacSha.. kullan diyoruz.Credential : Sisteme girmek için gerekli olanlar
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature); // bu anahtrı kullan, şifreleme olarak da güvenlik algoritmalarından hmacsha512 kullan.
        }
    }
}
