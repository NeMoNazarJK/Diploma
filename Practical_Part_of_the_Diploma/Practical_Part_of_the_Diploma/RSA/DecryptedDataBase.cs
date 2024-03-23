using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace Practical_Part_of_the_Diploma.RSA
{
    internal class DecryptedDataBase
    {
        private const string test = "..\\..\\..\\Files\\test.txt";

        public static void OnDecryptedDataBaseClick(object sender, EventArgs a, string PrivatekeyPath, DataTable dataTable, DataGridView dataGridView, string alphabet)
        {
            try
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

                        dataGridView.DataSource = decryptedDataTable;
                    }
                    else
                    {
                        MessageBox.Show($"Файл має неправильний формат ключа.");
                    }
                }
                else
                {
                    MessageBox.Show($"Файл має неправильний формат ключа.");
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Файл за шляхом {PrivatekeyPath} не знайдено.");
            }
            catch (Exception ex)
            {
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