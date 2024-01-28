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
    }
}