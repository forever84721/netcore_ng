﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AngularAPI2_2.Utility
{
    public class Utility
    {
        public static string PasswordEncoding(string Pd)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();//建立一個SHA256
            byte[] source = System.Text.Encoding.Default.GetBytes(Pd);//將字串轉為Byte[]
            byte[] crypto = sha256.ComputeHash(source);//進行SHA256加密
            string result = Convert.ToBase64String(crypto);//把加密後的字串從Byte[]轉為字串
            return result;
        }
    }
}
