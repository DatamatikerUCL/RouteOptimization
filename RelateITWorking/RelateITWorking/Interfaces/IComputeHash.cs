using System;
using System.Collections.Generic;
using System.Text;

namespace RelateITWorking.Interfaces
{
    public interface IComputeHash
    {

        string ComputeMD5Hash(string input);

        string ComputeSHA1Hash(string input);

        bool ValidateMD5Hash(string input, string hash);
        bool ValidateSHA1Hash(string input, string hash);
    }
}
