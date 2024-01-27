using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Text;

namespace Diplom.RSA
{
    internal class DecryptedRSA
    {
        public static string OnDecryptedTextClick(object sender, EventArgs a, out string DecryptedTextTime, string fileDecryptedKeyPath)
        {
            DecryptedTextTime = "";
            string alphabet = "—ABCDEFGHIJKLMNOPQRSTUVWXYZАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯabcdefghijklmnopqrstuvwxyzабвгґдеєжзиіїйклмнопрстуфхцчшщьюя \"\r\n'’.,:;!?-1234567890«»";
            
            string messageFilePath = "..\\..\\..\\Files\\encrypted_blocks.txt";
            string message = string.Empty;

            try
            {
                using (StreamReader sr = new StreamReader(messageFilePath))
                {
                    message = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }

            try
            {
                string fileContent = File.ReadAllText(fileDecryptedKeyPath);

                string[] parts = fileContent.Split(',');

                if (parts.Length >= 2)
                {
                    BigInteger d = BigInteger.Parse(parts[0]);
                    BigInteger n = BigInteger.Parse(parts[1]);

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    (string decryptedMessage, string decryptedMessageInNumbersfiles) = Decrypt(message, d, n, alphabet);
                    stopwatch.Stop();
                    TimeSpan decryptionTime = stopwatch.Elapsed;
                    DecryptedTextTime = decryptionTime.ToString();

                    File.WriteAllText("..\\..\\..\\Files\\decrypted_Message.txt", decryptedMessage);

                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Time\\Time_Decrypted.txt"))
                    {
                        file.WriteLine("{0}", decryptionTime.TotalSeconds);
                    }
                }
                else
                {
                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_3.txt"))
                    {
                        file.WriteLine($"Файл має неправильний формат.");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_4.txt"))
                {
                    file.WriteLine($"Файл за шляхом {fileDecryptedKeyPath} не знайдено.");
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_5.txt"))
                {
                    file.WriteLine($"Помилка при зчитуванні файлу: {ex.Message}");
                }
            }

            return DecryptedTextTime;
        }

        static (string, string) Decrypt(string encryptedBlocks, BigInteger d, BigInteger n, string alphabet)
        {
            List<BigInteger> encryptedNumbers = new List<BigInteger>();

            string[] encryptedBlockArray = encryptedBlocks.Split(' ');
            foreach (string block in encryptedBlockArray)
            {
                encryptedNumbers.Add(BigInteger.Parse(block));
            }

            StringBuilder decryptedMessage = new StringBuilder();
            StringBuilder decryptedMessageInNumbers = new StringBuilder();

            foreach (BigInteger block in encryptedNumbers)
            {
                BigInteger decryptedBlock = BigInteger.ModPow(block, d, n);
                int index = (int)decryptedBlock;
                decryptedMessage.Append(alphabet[index]);
                decryptedMessageInNumbers.Append($"{decryptedBlock} ");
            }

            return (decryptedMessage.ToString(), decryptedMessageInNumbers.ToString());
        }
    }
}