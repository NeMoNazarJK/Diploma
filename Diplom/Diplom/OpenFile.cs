using System;
using System.IO;
using System.Diagnostics;

namespace Diplom
{
    internal class OpenFile
    {
        public static string OpenFiletClickАdditional(object sender, EventArgs a)
        {
            string filePath = "..\\..\\..\\Files\\additional_information_RSA.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    Process.Start("notepad.exe", filePath);
                }
                catch (Exception ex)
                {
                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_6.txt"))
                    {
                        file.WriteLine($"Помилка відкриття файлу: {ex.Message}");
                    }
                }
            }
            else
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_7.txt"))
                {
                    file.WriteLine($"Файл не існує за шляхом: {filePath}");
                }
            }

            return "";
        }

        public static string OpenFiletClickDecrypted(object sender, EventArgs a)
        {
            string filePath = "..\\..\\..\\Files\\decrypted_Message.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    Process.Start("notepad.exe", filePath);
                }
                catch (Exception ex)
                {
                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_8.txt"))
                    {
                        file.WriteLine($"Помилка відкриття файлу: {ex.Message}");
                    }
                }
            }
            else
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_9.txt"))
                {
                    file.WriteLine($"Файл не існує за шляхом: {filePath}");
                }
            }

            return "";
        }

        public static string OpenFiletClickEncryption(object sender, EventArgs a)
        {
            string filePath = "..\\..\\..\\Files\\encrypted_message.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    Process.Start("notepad.exe", filePath);
                }
                catch (Exception ex)
                {
                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_10.txt"))
                    {
                        file.WriteLine($"Помилка відкриття файлу: {ex.Message}");
                    }
                }
            }
            else
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_11.txt"))
                {
                    file.WriteLine($"Файл не існує за шляхом: {filePath}");
                }
            }

            return "";
        }

        public static string OpenFiletClickDigitalSignature(object sender, EventArgs a)
        {
            string filePath = "..\\..\\..\\Files\\additional_information_RSA_Digital_Signature.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    Process.Start("notepad.exe", filePath);
                }
                catch (Exception ex)
                {
                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_27.txt"))
                    {
                        file.WriteLine($"Помилка відкриття файлу: {ex.Message}");
                    }
                }
            }
            else
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_28.txt"))
                {
                    file.WriteLine($"Файл не існує за шляхом: {filePath}");
                }
            }

            return "";
        }

        public static string OpenFiletClickSignature(object sender, EventArgs a)
        {
            string filePath = "..\\..\\..\\Files\\Еlectronic_digital_signature_s.txt";

            if (File.Exists(filePath))
            {
                try
                {
                    Process.Start("notepad.exe", filePath);
                }
                catch (Exception ex)
                {
                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_29.txt"))
                    {
                        file.WriteLine($"Помилка відкриття файлу: {ex.Message}");
                    }
                }
            }
            else
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Erorr_30.txt"))
                {
                    file.WriteLine($"Файл не існує за шляхом: {filePath}");
                }
            }

            return "";
        }
    }
}