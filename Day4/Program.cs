using System;
using System.Security.Cryptography;
using System.Text;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "bgvyzdsv";


            Hash hash = new Hash(input);


            string calcHash = hash.GetNewHash();

            while (!calcHash.StartsWith("000000"))
            {
                calcHash = hash.GetNewHash() ;
            }

            Console.WriteLine($"{calcHash}  {hash.Counter}");

            Console.WriteLine("Hello World!");
        }

        private class Hash
        {
            private string _inputHash;

            private int _counter = 0;

            public int Counter => _counter;

            public Hash(string input)
            {
                _inputHash = input;
            }

            public string GetNewHash()
            {
                _counter++;

                string hash = CalculateMD5Hash(_inputHash + _counter);

                return hash;
            }

            private string CalculateMD5Hash(string input)
            {
                MD5 md5 = MD5.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hash = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

 
    }
}
