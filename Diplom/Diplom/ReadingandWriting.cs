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

        public static void PerformReadingAndWritingGKDigitalSignatureTime(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Time\\Digital Signature\\Time_Key_256_Digital_Signature_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_Key_512_Digital_Signature_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_Key_1024_Digital_Signature_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_Key_2048_Digital_Signature_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_Key_4096_Digital_Signature_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_Key_8192_Digital_Signature_біт.txt"
                };

                string outputFilePath = "..\\..\\..\\Time\\Digital Signature\\Time_Key_Digital_Signature.txt";

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
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_21.txt"))
                {
                    file.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        }

        public static void PerformReadingAndWritingEDigitalSignatureTime(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Time\\Digital Signature\\Time_256_Signature_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_512_Signature_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_1024_Signature_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_2048_Signature_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_4096_Signature_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_8192_Signature_біт.txt"
                };

                string outputFilePath = "..\\..\\..\\Time\\Digital Signature\\Time_Signature.txt";

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
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_22.txt"))
                {
                    file.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        }

        public static void PerformReadingAndWritingDDigitalSignatureTime(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Time\\Digital Signature\\Time_256_Checklist_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_512_Checklist_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_1024_Checklist_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_2048_Checklist_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_4096_Checklist_біт.txt",
                    "..\\..\\..\\Time\\Digital Signature\\Time_8192_Checklist_біт.txt"
                };

                string outputFilePath = "..\\..\\..\\Time\\Digital Signature\\Time_Checklist.txt";

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
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_23.txt"))
                {
                    file.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        }

        public static void PerformReadingAndWritingGKDigitalSignatureMemory(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_256_Digital_Signature_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_512_Digital_Signature_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_1024_Digital_Signature_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_2048_Digital_Signature_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_4096_Digital_Signature_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_8192_Digital_Signature_біт.txt"
                };

                string outputFilePath = "..\\..\\..\\Memory\\Digital Signature\\Memory_Digital_Signature.txt";

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
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_24.txt"))
                {
                    file.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        }

        public static void PerformReadingAndWritingEDigitalSignatureMemory(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_256_Signature_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_512_Signature_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_1024_Signature_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_2048_Signature_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_4096_Signature_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_8192_Signature_біт.txt"
                };

                string outputFilePath = "..\\..\\..\\Memory\\Digital Signature\\Memory_Signature.txt";

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
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_25.txt"))
                {
                    file.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        }

        public static void PerformReadingAndWritingDDigitalSignatureMemory(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_256_Checklist_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_512_Checklist_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_1024_Checklist_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_2048_Checklist_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_4096_Checklist_біт.txt",
                    "..\\..\\..\\Memory\\Digital Signature\\Memory_8192_Checklist_біт.txt"
                };

                string outputFilePath = "..\\..\\..\\Memory\\Digital Signature\\Memory_Checklist.txt";

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
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_26.txt"))
                {
                    file.WriteLine($"Виникла помилка: {ex.Message}");
                }
            }
        }
    }
}