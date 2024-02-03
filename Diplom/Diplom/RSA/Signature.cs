using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.RSA
{
    internal class Signature
    {
        public static string OnSignatureClick(object sender, EventArgs a, string txtGeneratingkeysValue, out string KeyTime, string bitLengthTXT)
        {
            KeyTime = "";
            int bitLength = int.Parse(bitLengthTXT);
            //try
            //{
            //    string fileContent = File.ReadAllText(txtGeneratingkeysValue);

            //    string[] parts = fileContent.Split(',');

            //    if (parts.Length >= 3)
            //    {
            //        BigInteger e = BigInteger.Parse(parts[0]);

            //        BigInteger d = BigInteger.Parse(parts[1]);

            //        BigInteger n = BigInteger.Parse(parts[2]);

            //        Stopwatch stopwatch = Stopwatch.StartNew();
                    
            //        stopwatch.Stop();
            //        TimeSpan keyTime = stopwatch.Elapsed;
            //        KeyTime = keyTime.ToString();


            //        using (StreamWriter file = new StreamWriter("..\\..\\..\\Time\\Time_Encryption_" + bitLength + "_Digital_Signature_біт.txt"))
            //        {
            //            file.WriteLine("{0}", keyTime.TotalSeconds);
            //        }
            //    }
            //    else
            //    {
            //        using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_18.txt"))
            //        {
            //            file.WriteLine($"Файл має неправильний формат.");
            //        }
            //    }
            //}
            return (KeyTime);
        }
    }
}