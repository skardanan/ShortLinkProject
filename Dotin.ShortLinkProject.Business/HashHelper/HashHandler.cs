using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotin.ShortLinkProject.Business.HashHelper
{
   public class HashHandler
    {
        private const int HASHSIZE = 3;
        public static string Hash(string str)
        {

            var allowedSymbols = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            var hash = new char[HASHSIZE];

            for (int i = 0; i < str.Length; i++)
            {
                hash[i % HASHSIZE] = (char)(hash[i % HASHSIZE] ^ str[i]);
            }

            for (int i = 0; i < HASHSIZE; i++)
            {
                hash[i] = allowedSymbols[hash[i] % allowedSymbols.Length];
            }

            return new string(hash);
        }
    }
}
