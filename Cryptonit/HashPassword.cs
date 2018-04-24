using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace Cryptonit
{

    public static class HashPassword
    {
        public static string createSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[16];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public static string hash(string password, string salt)
        {
            string saltAndPwd = String.Concat(password, salt);
            return Convert.ToBase64String( 
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(saltAndPwd))
                );
        }
    }
}