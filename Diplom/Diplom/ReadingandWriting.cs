using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    internal class ReadingandWriting
    {
        public static void PerformReadingAndWritingGKTime(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Time\\Time_Key_256_біт.txt",
                    "..\\..\\..\\Time\\Time_Key_512_біт.txt",
                    "..\\..\\..\\Time\\Time_Key_1024_біт.txt",
                    "..\\..\\..\\Time\\Time_Key_2048_біт.txt",
                    "..\\..\\..\\Time\\Time_Key_4096_біт.txt",
                    "..\\..\\..\\Time\\Time_Key_8192_біт.txt"
                };

                string outputFilePath = "..\\..\\..\\Time\\Time_Key.txt";

                using (StreamWriter outputFile = new StreamWriter(outputFilePath))
                {
                    foreach (string inputFilePath in inputFilePaths)
                    {
                        string value = File.ReadAllText(inputFilePath);

                        value = value.Replace(Environment.NewLine, "+");

                        outputFile.Write(value);
                    }
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_12.txt"))
                {
                    file.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        }

        public static void PerformReadingAndWritingETime(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Time\\Time_Encryption_256_біт.txt",
                    "..\\..\\..\\Time\\Time_Encryption_512_біт.txt",
                    "..\\..\\..\\Time\\Time_Encryption_1024_біт.txt",
                    "..\\..\\..\\Time\\Time_Encryption_2048_біт.txt",
                    "..\\..\\..\\Time\\Time_Encryption_4096_біт.txt",
                    "..\\..\\..\\Time\\Time_Encryption_8192_біт.txt"
                };

                string outputFilePath = "..\\..\\..\\Time\\Time_Encryption.txt";

                using (StreamWriter outputFile = new StreamWriter(outputFilePath))
                {
                    foreach (string inputFilePath in inputFilePaths)
                    {
                        string value = File.ReadAllText(inputFilePath);

                        value = value.Replace(Environment.NewLine, "+");

                        outputFile.Write(value);
                    }
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_13.txt"))
                {
                    file.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        }

        public static void PerformReadingAndWritingDTime(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Time\\Time_Decrypted_256_біт.txt",
                    "..\\..\\..\\Time\\Time_Decrypted_512_біт.txt",
                    "..\\..\\..\\Time\\Time_Decrypted_1024_біт.txt",
                    "..\\..\\..\\Time\\Time_Decrypted_2048_біт.txt",
                    "..\\..\\..\\Time\\Time_Decrypted_4096_біт.txt",
                    "..\\..\\..\\Time\\Time_Decrypted_8192_біт.txt"
                };

                string outputFilePath = "..\\..\\..\\Time\\Time_Decrypted.txt";

                using (StreamWriter outputFile = new StreamWriter(outputFilePath))
                {
                    foreach (string inputFilePath in inputFilePaths)
                    {
                        string value = File.ReadAllText(inputFilePath);

                        value = value.Replace(Environment.NewLine, "+");

                        outputFile.Write(value);
                    }
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_14.txt"))
                {
                    file.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        }

        public static void PerformReadingAndWritingGKMemory(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Memory\\Memory_Key_256_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Key_512_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Key_1024_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Key_2048_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Key_4096_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Key_8192_біт.txt"
                };

                string outputFilePath = "..\\..\\..\\Memory\\Memory_Key.txt";

                using (StreamWriter outputFile = new StreamWriter(outputFilePath))
                {
                    foreach (string inputFilePath in inputFilePaths)
                    {
                        string value = File.ReadAllText(inputFilePath);

                        value = value.Replace(Environment.NewLine, "+");

                        outputFile.Write(value);
                    }
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_15.txt"))
                {
                    file.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        }

        public static void PerformReadingAndWritingEMemory(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Memory\\Memory_Encryption_256_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Encryption_512_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Encryption_1024_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Encryption_2048_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Encryption_4096_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Encryption_8192_біт.txt"
                };

                string outputFilePath = "..\\..\\..\\Memory\\Memory_Encryption.txt";

                using (StreamWriter outputFile = new StreamWriter(outputFilePath))
                {
                    foreach (string inputFilePath in inputFilePaths)
                    {
                        string value = File.ReadAllText(inputFilePath);

                        value = value.Replace(Environment.NewLine, "+");

                        outputFile.Write(value);
                    }
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_16.txt"))
                {
                    file.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        }

        public static void PerformReadingAndWritingDMemory(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Memory\\Memory_Decrypted_256_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Decrypted_512_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Decrypted_1024_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Decrypted_2048_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Decrypted_4096_біт.txt",
                    "..\\..\\..\\Memory\\Memory_Decrypted_8192_біт.txt"
                };

                string outputFilePath = "..\\..\\..\\Memory\\Memory_Decrypted.txt";

                using (StreamWriter outputFile = new StreamWriter(outputFilePath))
                {
                    foreach (string inputFilePath in inputFilePaths)
                    {
                        string value = File.ReadAllText(inputFilePath);

                        value = value.Replace(Environment.NewLine, "+");

                        outputFile.Write(value);
                    }
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_17.txt"))
                {
                    file.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        }
    }
}