using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Paper_stone_scissors
{
    class Key
    {
        public Key(string[] args)
        {
            numGen = RandomNumberGenerator.Create();
            pcMove = RandomNumberGenerator.GetInt32(1, args.Length);
            key = new byte[KEY_LENGHT / 8];
            numGen.GetBytes(key);
            hmac = new HMACSHA256();
            bytePCmove = Encoding.Default.GetBytes(args[pcMove]);
        }

        public string GetStringKey()
        {
            keyStr = String.Concat<byte>(key);
            return keyStr;
        }

        public string GetStringHmac()
        {
            byte[] computedVal = new byte[key.Length + bytePCmove.Length];
            key.CopyTo(computedVal, 0);
            bytePCmove.CopyTo(computedVal, key.Length);
            var hmacVal = hmac.ComputeHash(computedVal);
            return (String.Concat<byte>(hmacVal));
        }

        public int pcMove;

        private const int KEY_LENGHT = 128;

        private byte[] key;

        private string keyStr;

        private RandomNumberGenerator numGen;

        private HMACSHA256 hmac;
        private byte[] bytePCmove;

    }
}
