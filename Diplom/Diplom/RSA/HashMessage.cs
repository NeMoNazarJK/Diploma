using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Diplom.RSA
{
    internal class HashMessage
    {
        public static string Hash(string message, string alphabet)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
               
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                byte[] alphabetBytes = Encoding.UTF8.GetBytes(alphabet);

                for (int i = 0; i < messageBytes.Length; i++)
                {
                    int index = Array.IndexOf(alphabetBytes, messageBytes[i]);
                    if (index != -1)
                    {
                        messageBytes[i] = (byte)index;
                    }
                }

                byte[] hashBytes = sha256.ComputeHash(messageBytes);

                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    stringBuilder.Append(b.ToString("X2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}