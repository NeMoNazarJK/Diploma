using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text;

namespace Diplom.RSA
{
    internal class EncryptionRSA
    {
        public static string OnEncryptionTextClick(object sender, EventArgs a, string txtTextSize, out string EncryptionTextTime, string fileEncryptionTextPath)
        {
            EncryptionTextTime = "";
            string alphabet = "—ABCDEFGHIJKLMNOPQRSTUVWXYZАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯabcdefghijklmnopqrstuvwxyzабвгґдеєжзиіїйклмнопрстуфхцчшщьюя \"\r\n'’.,:;!?-1234567890«»";

            try
            {
                string fileContent = File.ReadAllText(fileEncryptionTextPath);

                string[] parts = fileContent.Split(',');

                if (parts.Length >= 2)
                {
                    BigInteger e = BigInteger.Parse(parts[0]);

                    BigInteger n = BigInteger.Parse(parts[1]);

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    (string encryptedMessage, IEnumerable<BigInteger> encryptedBlocks, string encryptedBlock, string messageBlock) = Encrypt(txtTextSize, e, n, alphabet);

                    stopwatch.Stop();
                    TimeSpan encryptionTime = stopwatch.Elapsed;
                    EncryptionTextTime = encryptionTime.ToString();

                    File.WriteAllText("..\\..\\..\\Files\\encrypted_blocks.txt", encryptedBlock);
                    File.WriteAllText("..\\..\\..\\Files\\encrypted_message.txt", encryptedMessage);
                }
                else
                {
                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_0.txt"))
                    {
                        file.WriteLine($"Файл має неправильний формат.");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_1.txt"))
                {
                    file.WriteLine($"Файл за шляхом {fileEncryptionTextPath} не знайдено.");
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_2.txt"))
                {
                    file.WriteLine($"Помилка при зчитуванні файлу: {ex.Message}");
                }
            }

            return (EncryptionTextTime);
        }

        public static (string, IEnumerable<BigInteger>, string, string) Encrypt(string message, BigInteger e, BigInteger n, string alphabet)
        {
            StringBuilder messageBuilder = new StringBuilder();
            foreach (char c in message)
            {
                int index = alphabet.IndexOf(c);
                if (index < 0)
                {
                    throw new Exception(string.Format("Символ {0} не знайдено в алфавіті.", c));
                }
                messageBuilder.Append(index.ToString("D3"));
            }
            string messageInNumbers = messageBuilder.ToString();
            var messageBlocks = Enumerable.Range(0, messageInNumbers.Length / 3).Select(i => messageInNumbers.Substring(i * 3, 3));
            string messageBlock = string.Join(" ", messageBlocks);
            var encryptedBlocks = messageBlocks.Select(block =>BigInteger.ModPow(BigInteger.Parse(block), e, n));
            string encryptedBlock = string.Join(" ", encryptedBlocks);
            string encryptedMessage = string.Join("", encryptedBlocks);
            return (encryptedMessage, encryptedBlocks, encryptedBlock, messageBlock);
        }

    }
}
