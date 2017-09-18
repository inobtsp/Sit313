using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace App5
{
    class security
    {
        public string SHA256hash(string input)
        {
            byte[] sign_byte = Encoding.UTF8.GetBytes(input);
            var sha2 = SHA256.Create();
            sign_byte = sha2.ComputeHash(sign_byte);
            return Encoding.UTF8.GetString(sign_byte);
        }
    }
}
