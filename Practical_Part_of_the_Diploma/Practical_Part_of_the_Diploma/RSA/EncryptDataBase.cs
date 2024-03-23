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
    internal class EncryptDataBase
    {
        public static void OnEncryptDataBaseClick(object sender, EventArgs a, string PublickeyPath, DataTable dataTable, DataGridView dataGridView, string alphabet)
        {          
            try
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

                        dataGridView.DataSource = encryptedDataTable;

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
                MessageBox.Show($"Файл за шляхом {PublickeyPath} не знайдено.");
            }
            catch (Exception ex)
            {
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