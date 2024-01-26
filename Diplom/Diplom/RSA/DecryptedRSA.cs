using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.RSA
{
    internal class DecryptedRSA
    {
        public static string OnDecryptedTextClick(object sender, EventArgs a, out string DecryptedTextTime, string fileDecryptedKeyPath)
        {
            DecryptedTextTime = "";
            string alphabet = "—ABCDEFGHIJKLMNOPQRSTUVWXYZАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯabcdefghijklmnopqrstuvwxyzабвгґдеєжзиіїйклмнопрстуфхцчшщьюя \"\r\n'’.,:;!?-1234567890«»";

            string messageFilePath = "..\\..\\..\\Files\\encrypted_blocks.txt";

            IEnumerable<BigInteger> fileDecryptedTextPath = ReadFileAsBigIntegers(messageFilePath); ;

            File.WriteAllText("..\\..\\..\\Files\\fileDecryptedKeyPath.txt", fileDecryptedKeyPath);
            try
            {
                string fileContent = File.ReadAllText(fileDecryptedKeyPath);

                string[] parts = fileContent.Split(',');

                if (parts.Length >= 2)
                {
                    BigInteger d = BigInteger.Parse(parts[0]);

                    BigInteger n = BigInteger.Parse(parts[1]);

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    (string decryptedMessage, string decryptedMessageInNumbersfiles) = Decrypt(fileDecryptedTextPath, d, n, alphabet);

                    stopwatch.Stop();
                    TimeSpan encryptionTime = stopwatch.Elapsed;
                    DecryptedTextTime = encryptionTime.ToString();

                    //File.WriteAllText("..\\..\\..\\Files\\decrypted_InNumbers.txt", decryptedMessageInNumbersfiles);
                    File.WriteAllText("..\\..\\..\\Files\\decrypted_Message.txt", decryptedMessage);
                    //File.WriteAllText("..\\..\\..\\Files\\fileEncryptionTextPath.txt", fileDecryptedKeyPath);

                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Fine.txt"))
                    {
                        file.WriteLine($"BigInteger d: {d}");
                        file.WriteLine($"BigInteger n: {n}");
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

        static IEnumerable<BigInteger> ReadFileAsBigIntegers(string filePath)
        {
            // Читаем содержимое файла
            string fileContent = File.ReadAllText(filePath);

            // Разделяем строку на отдельные числа (предполагая, что они разделены, например, пробелами)
            string[] numbersAsString = fileContent.Split(' ');

            // Преобразуем каждую строку в BigInteger
            foreach (var numberAsString in numbersAsString)
            {
                if (BigInteger.TryParse(numberAsString, out var bigInteger))
                {
                    yield return bigInteger;
                }
                else
                {
                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_5.txt"))
                    {
                        file.WriteLine($"Помилка перетворення рядка {numberAsString} в BigInteger");
                    }
                }
            }
        }

        static (string, string) Decrypt(IEnumerable<BigInteger> encryptedBlocks, BigInteger d, BigInteger n, string alphabet)
        {
            int blockSize = n.ToString().Length - 1;
            var decryptedBlocks = encryptedBlocks.Select(block => BigInteger.ModPow(block, d, n));
            string decryptedMessageInNumbers = string.Join("", decryptedBlocks).PadLeft(encryptedBlocks.Count() * blockSize, '0');
            string decryptedMessageInNumbersfiles = string.Join("", decryptedBlocks.Where(block => block != 0));
            StringBuilder decryptedMessageBuilder = new StringBuilder();
            for (int i = 0; i < decryptedMessageInNumbers.Length; i += 3)
            {
                int index = int.Parse(decryptedMessageInNumbers.Substring(i, 3));
                decryptedMessageBuilder.Append(alphabet[index]);
            }
            string decryptedMessage = decryptedMessageBuilder.ToString();
            //decryptedMessage = decryptedMessage.Replace("—", "");
            return (decryptedMessage, decryptedMessageInNumbersfiles);
        }
    }
}