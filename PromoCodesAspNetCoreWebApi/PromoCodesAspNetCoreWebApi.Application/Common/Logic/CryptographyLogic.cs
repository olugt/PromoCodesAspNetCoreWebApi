using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Logic
{
    public static class CryptographyLogic
    {
        public static string HashStringToSha256ToBase64(string theString)
        {
            string hashToBase64 = null;

            using (SHA256 sha256 = SHA256.Create())
            {
                try
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(theString);
                    byte[] hash = sha256.ComputeHash(buffer);
                    hashToBase64 = Convert.ToBase64String(hash);
                }
                catch (IOException ioEx)
                {
                    throw ioEx;
                }
                catch (UnauthorizedAccessException unauthorizedAccessEx)
                {
                    throw unauthorizedAccessEx;
                }
            }

            return hashToBase64;
        }
    }
}
