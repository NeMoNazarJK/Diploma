﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    internal class ReadingandWriting
    {
        public static void PerformReadingAndWritingGK(object sender, EventArgs e)
        {
            try
            {
                string[] inputFilePaths = {
                    "..\\..\\..\\Time\\Time_Key_256_біт.txt",
                    "..\\..\\..\\Time\\Time_Key_512_біт.txt",
                    "..\\..\\..\\Time\\Time_Key_1024_біт.txt",
                    "..\\..\\..\\Time\\Time_Key_2048_біт.txt"
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
                MessageBox.Show("Значення успішно зчитані з файлів та записані в output.txt.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}");
            }
        }   
    }
}
