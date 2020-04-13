using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using RelateITWorking.Interfaces;

namespace RelateITWorking.Helpers
{
    public class Hashing : IComputeHash
    {
        public string ComputeMD5Hash(string input)
        {
            StringBuilder builder = new StringBuilder();
            byte[] textBytes = Encoding.ASCII.GetBytes(input);
            using (MD5 md5 = MD5.Create())
            {
                byte[] computeHash = md5.ComputeHash(textBytes);
                for (int i = 0; i < computeHash.Length; i++)
                {
                    builder.Append(computeHash[i].ToString("x2"));
                }
            }

            return builder.ToString();
        }

        public string ComputeSHA1Hash(string input)
        {
            StringBuilder builder = new StringBuilder();
            byte[] textBytes = Encoding.ASCII.GetBytes(input);
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] computeHash = sha1.ComputeHash(textBytes);
                for (int i = 0; i < computeHash.Length; i++)
                {
                    builder.Append(computeHash[i].ToString("x2"));
                }
            }

            return builder.ToString();
        }


        public bool ValidateMD5Hash(string input, string hash)
        {
            string tempHash = ComputeMD5Hash(input);
            bool flag;
            if (string.Compare(tempHash, hash) == 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        public bool ValidateSHA1Hash(string input, string hash)
        {
            string tempHash = ComputeSHA1Hash(input);
            bool flag;
            if (string.Compare(tempHash, hash) == 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }
    }
}
