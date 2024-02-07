using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Diplom.RSA
{
    internal class Checklist
    {
        public static string OnChecklistClick(object sender, EventArgs a, string txtChecklistValue, out string ChecklistTime, string Checklist, string Checklistbit)
        {
            ChecklistTime = "";
            string alphabet = "—ABCDEFGHIJKLMNOPQRSTUVWXYZАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯabcdefghijklmnopqrstuvwxyzабвгґдеєжзиіїйклмнопрстуфхцчшщьюя \"\r\n'’.,:;!?-1234567890«»";
            int bitLength = int.Parse(Checklistbit);

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            string hashedMessage = HashMessage.Hash(txtChecklistValue, alphabet);
            BigInteger hashedMessageBigInt = new BigInteger(Encoding.UTF8.GetBytes(hashedMessage));

            string message = string.Empty;

            try
            {
                using (StreamReader sr = new StreamReader(Checklist))
                {
                    message = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }

            if (hashedMessageBigInt == BigInteger.Parse(message))
            {
                MessageBox.Show("Підпис правильний");
            }
            else
            {
                MessageBox.Show("Підпис не правильний.");
            }

            stopwatch.Stop();
            TimeSpan Time = stopwatch.Elapsed;
            ChecklistTime = Time.ToString();

            using (StreamWriter file = new StreamWriter("..\\..\\..\\Time\\Digital Signature\\Time_" + bitLength + "_Checklist_біт.txt"))
            {
                file.WriteLine("{0}", Time.TotalSeconds);
            }

            return (ChecklistTime);
        }
    }
}