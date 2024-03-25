using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Practical_Part_of_the_Diploma.RSA
{
    internal class EncryptDataBase
    {
        public static async void OnEncryptDataBaseClick(object sender, EventArgs a, string PublickeyPath, DataTable dataTable, DataGridView dataGridView, string alphabet, string Loading, string LoadingPath, string EncryptionTime, Label labelEncryptionTime, double memoryInMegabytesEncryption, Label labelEncryptionMemory, string SuccessPath, float SuccessVolume, int SuccessNumber, string ErrorPath, float ErrorVolume, int ErrorNumber)
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                using (Process process = Process.GetCurrentProcess())
                {
                    using (Form loadingForm = LoadingMessageBox.ShowLoadingMessageBox(Loading, LoadingPath))
                    {
                        loadingForm.Show();

                        await Task.Run(() =>
                        {
                            string fileContent = File.ReadAllText(PublickeyPath);
                            string[] parts = fileContent.Split(',');

                            if (parts.Length >= 2)
                            {
                                BigInteger e;
                                BigInteger n;

                                if (BigInteger.TryParse(parts[0], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out e) &&
                                    BigInteger.TryParse(parts[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out n))
                                {
                                    DataTable encryptedDataTable = new DataTable();

                                    foreach (DataColumn column in dataTable.Columns)
                                    {
                                        encryptedDataTable.Columns.Add(column.ColumnName, typeof(string));
                                    }

                                    foreach (DataRow row in dataTable.Rows)
                                    {
                                        DataRow encryptedRow = encryptedDataTable.NewRow();

                                        encryptedRow[0] = row[0];

                                        for (int i = 1; i < dataTable.Columns.Count; i++)
                                        {
                                            string message = row[i].ToString();
                                            string encryptedMessage = Encrypt(message, e, n, alphabet);
                                            encryptedRow[i] = encryptedMessage;
                                        }

                                        encryptedDataTable.Rows.Add(encryptedRow);
                                    }

                                    dataGridView.Invoke((MethodInvoker)delegate {
                                        dataGridView.DataSource = encryptedDataTable;
                                    });
                                }
                                else
                                {
                                    PlaySound.OnPlaySoundClick(sender, a, ErrorPath, ErrorVolume, ErrorNumber);

                                    MessageBox.Show($"Файл має неправильний формат ключа.");
                                }
                            }
                            else
                            {
                                PlaySound.OnPlaySoundClick(sender, a, ErrorPath, ErrorVolume, ErrorNumber);

                                MessageBox.Show($"Файл має неправильний формат ключа.");
                            }
                        });
                    }
                    memoryInMegabytesEncryption = process.PrivateMemorySize64 / (1024 * 1024);
                }
                TimeSpan Encryption = stopwatch.Elapsed;
                EncryptionTime = Encryption.ToString();

                labelEncryptionTime.Text = $"Час зашифрування бази даних: {EncryptionTime}";
                labelEncryptionMemory.Text = $"Виділена пам'ять: {memoryInMegabytesEncryption} МБ для шифрування бази даних";

                PlaySound.OnPlaySoundClick(sender, a, SuccessPath, SuccessVolume, SuccessNumber);

                MessageBox.Show("Шифрування завершилося");
            }
            catch (FileNotFoundException)
            {
                PlaySound.OnPlaySoundClick(sender, a, ErrorPath, ErrorVolume, ErrorNumber);

                MessageBox.Show($"Файл за шляхом {PublickeyPath} не знайдено.");
            }
            catch (Exception ex)
            {
                PlaySound.OnPlaySoundClick(sender, a, ErrorPath, ErrorVolume, ErrorNumber);

                MessageBox.Show($"Помилка при шифруванні бази даних: {ex.Message}");
            }
        }

        public static string Encrypt(string message, BigInteger e, BigInteger n, string alphabet)
        {
            StringBuilder encryptedMessage = new StringBuilder();

            foreach (char c in message)
            {
                int index = alphabet.IndexOf(c);
                if (index < 0)
                {
                    MessageBox.Show($"Символа {c} немає в алфавіті.");
                }
                else
                {
                    BigInteger encryptedChar = BigInteger.ModPow(new BigInteger(index), e, n);
                    encryptedMessage.Append(encryptedChar.ToString("X"));
                    encryptedMessage.Append(" ");
                }
            }

            return encryptedMessage.ToString().Trim();
        }
    }
}