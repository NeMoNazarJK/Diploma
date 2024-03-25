using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace Practical_Part_of_the_Diploma.RSA
{
    internal class DecryptedDataBase
    {
        public static async void OnDecryptedDataBaseClick(object sender, EventArgs a, string PrivatekeyPath, DataTable dataTable, DataGridView dataGridView, string alphabet, string Loading, string LoadingPath, string DecryptedTime, Label labelDecryptedTime, double memoryInMegabytesDecrypted, Label labelDecryptedMemory, string SuccessPath, float SuccessVolume, int SuccessNumber, string ErrorPath, float ErrorVolume, int ErrorNumber)
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
                            string fileContent = File.ReadAllText(PrivatekeyPath);
                            string[] parts = fileContent.Split(',');

                            if (parts.Length >= 2)
                            {
                                BigInteger d;
                                BigInteger n;

                                if (BigInteger.TryParse(parts[0], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out d) &&
                                    BigInteger.TryParse(parts[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out n))
                                {
                                    DataTable decryptedDataTable = new DataTable();

                                    foreach (DataColumn column in dataTable.Columns)
                                    {
                                        decryptedDataTable.Columns.Add(column.ColumnName, typeof(string));
                                    }

                                    foreach (DataRow row in dataTable.Rows)
                                    {
                                        DataRow decryptedRow = decryptedDataTable.NewRow();

                                        decryptedRow[0] = row[0];

                                        for (int i = 1; i < dataTable.Columns.Count; i++)
                                        {
                                            string message = row[i].ToString();
                                            string decryptedMessage = Decrypted(message, d, n, alphabet);
                                            decryptedRow[i] = decryptedMessage.ToString();
                                        }

                                        decryptedDataTable.Rows.Add(decryptedRow);
                                    }

                                    dataGridView.Invoke((MethodInvoker)delegate
                                    {
                                        dataGridView.DataSource = decryptedDataTable;
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
                    memoryInMegabytesDecrypted = process.PrivateMemorySize64 / (1024 * 1024);
                }
                stopwatch.Stop();
                TimeSpan Decrypteds = stopwatch.Elapsed;
                DecryptedTime = Decrypteds.ToString();

                labelDecryptedTime.Text = $"Час розшифрування бази даних: {DecryptedTime}";
                labelDecryptedMemory.Text = $"Виділена пам'ять: {memoryInMegabytesDecrypted} МБ для розшифроування бази даних";

                PlaySound.OnPlaySoundClick(sender, a, SuccessPath, SuccessVolume, SuccessNumber);

                MessageBox.Show("Розшифрування завершилося");
            }
            catch (FileNotFoundException)
            {
                PlaySound.OnPlaySoundClick(sender, a, ErrorPath, ErrorVolume, ErrorNumber);

                MessageBox.Show($"Файл за шляхом {PrivatekeyPath} не знайдено.");
            }
            catch (Exception ex)
            {
                PlaySound.OnPlaySoundClick(sender, a, ErrorPath, ErrorVolume, ErrorNumber);

                MessageBox.Show($"Помилка при дешифруванні бази даних: {ex.Message}");
            }
        }
        public static string Decrypted(string encryptedmessage, BigInteger d, BigInteger n, string alphabet)
        {
            List<BigInteger> encryptedNumbers = new List<BigInteger>();

            string[] encryptedBlockArray = encryptedmessage.Split(' ');
            foreach (string block in encryptedBlockArray)
            {
                BigInteger encryptedNumber = BigInteger.Parse(block, NumberStyles.HexNumber);
                encryptedNumbers.Add(encryptedNumber);
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

            return decryptedMessage.ToString();
        }
    }
}