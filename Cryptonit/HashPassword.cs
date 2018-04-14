using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Cryptonit
{
    public static class HashPassword
    {
        public static string hash(string password)
        {
            return Convert.ToBase64String( 
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(password))
                );
        }
    }
}