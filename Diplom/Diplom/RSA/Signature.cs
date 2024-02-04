using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.RSA
{
    internal class Signature
    {
        public static string OnSignatureClick(object sender, EventArgs a, string txtGeneratingkeysValue, out string KeyTime, string bitLengthTXT, string txtkeysValue)
        {
            KeyTime = "";
            int bitLength = int.Parse(bitLengthTXT);
            string alphabet = "—ABCDEFGHIJKLMNOPQRSTUVWXYZАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯabcdefghijklmnopqrstuvwxyzабвгґдеєжзиіїйклмнопрстуфхцчшщьюя \"\r\n'’.,:;!?-1234567890«»";
            try
            {
                string fileContent = File.ReadAllText(txtkeysValue);

                string[] parts = fileContent.Split(',');

                if (parts.Length >= 3)
                {
                    BigInteger e = BigInteger.Parse(parts[0]);

                    BigInteger d = BigInteger.Parse(parts[1]);

                    BigInteger n = BigInteger.Parse(parts[2]);

                    Stopwatch stopwatch = Stopwatch.StartNew();

                    stopwatch.Stop();
                    string hashedMessage = HashMessage.Hash(txtGeneratingkeysValue, alphabet);
                    BigInteger hashedMessageBigInt = new BigInteger(Encoding.UTF8.GetBytes(hashedMessage));
                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Hash.txt"))
                    {
                        file.WriteLine("{0}", hashedMessageBigInt);
                    }
                    
                    BigInteger s = InverseElement.FindInverseElement(hashedMessageBigInt, d, n);

                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Еlectronic_digital_signature_s.txt"))
                    {
                        file.WriteLine("{0}", s);
                    }

                    BigInteger m = InverseElement.FindInverseElement(s, e, n);

                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Еlectronic_digital_signature_m.txt"))
                    {
                        file.WriteLine("{0}", m);
                    }
                    TimeSpan keyTime = stopwatch.Elapsed;
                    KeyTime = keyTime.ToString();
                }
                else
                {
                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_18.txt"))
                    {
                        file.WriteLine($"Файл має неправильний формат.");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_19.txt"))
                {
                    file.WriteLine($"Файл за шляхом {txtkeysValue} не знайдено.");
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_20.txt"))
                {
                    file.WriteLine($"Помилка при зчитуванні файлу: {ex.Message}");
                }
            }
            return (KeyTime);
        }
    }
}