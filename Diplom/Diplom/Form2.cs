using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;

namespace Diplom
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeFormElements();
        }

        private Chart ChartGeneratingKey;
        private Chart ChartEncryption;
        private Chart ChartDecrypted;
        private DataGridView dataGridViewGK;
        private DataGridView dataGridViewEncryption;
        private DataGridView dataGridViewDecrypted;
        private Button SaveGeneratingKey;
        private Button SaveGeneratingKeyT;
        private Button SaveEncryption;
        private Button SaveEncryptionT;
        private Button SaveDecrypted;
        private Button SaveDecryptedT;
        private Button BuildingGeneratingKey;
        private Button BuildingEncryption;
        private Button BuildingDecrypted;

        private string Time_Generating_Key = "..\\..\\..\\Time\\Time_Key.txt";
        private string Time_Encryption = "..\\..\\..\\Time\\Time_Encryption.txt";
        private string Time_Decrypted = "..\\..\\..\\Time\\Time_Decrypted.txt";
        private string Table_Generating_Key = "GeneratingKeyTable";
        private string Table_Encryption = "EncryptionTable";
        private string Table_Decrypted = "DecryptedTable";
        private string saveDialogFileName = "Графік Генерація N-бітного ключа для RSA";
        private string saveDialogFileNameEncryption = "Графік Шифрування N-бітного ключа для RSA";
        private string saveDialogFileNameDecrypted = "Графік Розшифрування N-бітного ключа для RSA";

        private void InitializeFormElements()
        {
            this.Size = new Size(1920, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA_Graphs";

            ChartGeneratingKey = new Chart()
            {
                Location = new Point(10, 10),
                Size = new Size(990, 300),
            };

            ChartEncryption = new Chart()
            {
                Location = new Point(10, 350),
                Size = new Size(990, 300),
            };

            ChartDecrypted = new Chart()
            {
                Location = new Point(10, 690),
                Size = new Size(990, 300),
            };

            BuildingGeneratingKey = new Button()
            {
                Location = new Point(1000, 10),
                Size = new Size(250, 45),
                Text = "Побудувати графік Генерація N-бітного ключа для RSA",
            };

            BuildingEncryption = new Button()
            {
                Location = new Point(1000, 350),
                Size = new Size(250, 45),
                Text = "Побудувати графік Шифрування N-бітного ключа для RSA",
            };

            BuildingDecrypted = new Button()
            {
                Location = new Point(1000, 690),
                Size = new Size(250, 45),
                Text = "Побудувати графік Розшифрування N-бітного ключа для RSA",
            };

            SaveGeneratingKey = new Button()
            {
                Location = new Point(1000, 70),
                Size = new Size(250, 45),
                Text = "Зберегти графік Генерація N-бітного ключа для RSA",
            };

            SaveGeneratingKeyT = new Button()
            {
                Location = new Point(1000, 130),
                Size = new Size(250, 45),
                Text = "Зберегти таблицю Генерація N-бітного ключа для RSA",
            };

            SaveEncryption = new Button()
            {
                Location = new Point(1000, 410),
                Size = new Size(250, 45),
                Text = "Зберегти графік Шифрування N-бітного ключа для RSA",
            };

            SaveEncryptionT = new Button()
            {
                Location = new Point(1000, 470),
                Size = new Size(250, 45),
                Text = "Зберегти таблицю Шифрування N-бітного ключа для RSA",
            };

            SaveDecrypted = new Button()
            {
                Location = new Point(1000, 750),
                Size = new Size(250, 45),
                Text = "Зберегти графік Розшифрування N-бітного ключа для RSA",
            };

            SaveDecryptedT = new Button()
            {
                Location = new Point(1000, 810),
                Size = new Size(250, 45),
                Text = "Зберегти графік Розшифрування N-бітного ключа для RSA",
            };

            dataGridViewGK = new DataGridView()
            {
                Location = new Point(1260, 10),
                Size = new Size(570, 200),
            };

            dataGridViewEncryption = new DataGridView()
            {
                Location = new Point(1260, 350),
                Size = new Size(570, 200),
            };

            dataGridViewDecrypted = new DataGridView()
            {
                Location = new Point(1260, 690),
                Size = new Size(570, 200),
            };

            int[] N = new int[] { 256, 512, 1024, 2048, 4096, 8192 };

            BuildingGeneratingKey.Click += (sender, e) =>
            {
                BuildingButton_Click(sender, e, N, ChartGeneratingKey, Time_Generating_Key, saveDialogFileName, dataGridViewGK);
            };

            BuildingEncryption.Click += (sender, e) =>
            {
                BuildingButton_Click(sender, e, N, ChartEncryption, Time_Encryption, saveDialogFileNameEncryption, dataGridViewEncryption);
            };

            BuildingDecrypted.Click += (sender, e) =>
            {
                BuildingButton_Click(sender, e, N, ChartDecrypted, Time_Decrypted, saveDialogFileNameDecrypted, dataGridViewDecrypted);
            };

            SaveGeneratingKey.Click += (sender, e) =>
            {
                SaveButton_Click(sender, e, saveDialogFileName, ChartGeneratingKey);
            };

            SaveEncryption.Click += (sender, e) =>
            {
                SaveButton_Click(sender, e, saveDialogFileNameEncryption, ChartEncryption);
            };

            SaveDecrypted.Click += (sender, e) =>
            {
                SaveButton_Click(sender, e, saveDialogFileNameDecrypted, ChartDecrypted);
            };

            SaveGeneratingKeyT.Click += (sender, e) =>
            {
                SaveTable_Click(sender, e, dataGridViewGK, Table_Generating_Key);
            };

            SaveEncryptionT.Click += (sender, e) =>
            {
                SaveTable_Click(sender, e, dataGridViewEncryption, Table_Encryption);
            };

            SaveDecryptedT.Click += (sender, e) =>
            {
                SaveTable_Click(sender, e, dataGridViewDecrypted, Table_Decrypted);
            };

            Controls.Add(ChartGeneratingKey);
            Controls.Add(ChartEncryption);
            Controls.Add(ChartDecrypted);
            Controls.Add(BuildingGeneratingKey);
            Controls.Add(BuildingEncryption);
            Controls.Add(BuildingDecrypted);
            Controls.Add(SaveGeneratingKey);
            Controls.Add(SaveGeneratingKeyT);
            Controls.Add(SaveEncryption);
            Controls.Add(SaveEncryptionT);
            Controls.Add(SaveDecrypted);
            Controls.Add(SaveDecryptedT);
            Controls.Add(dataGridViewGK);
            Controls.Add(dataGridViewEncryption);
            Controls.Add(dataGridViewDecrypted);
        }

        private void BuildingButton_Click(object sender, EventArgs e, int[] N, Chart ChartGenerating, string file, string saveDialogFileName, DataGridView dataGridView1)
        {            
            string filePath = file;
            string content = File.ReadAllText(filePath);
            string[] valuesAsString = content.Split('+');

            List<double> MList = new List<double>();

            foreach (string valueStr in valuesAsString)
            {
                if (!string.IsNullOrEmpty(valueStr))
                {
                    double value;
                    if (double.TryParse(valueStr, out value))
                    {
                        MList.Add(value);
                    }
                    else
                    {
                        MessageBox.Show($"Неможливо конвертувати рядок '{valueStr}' в число.");
                        return;
                    }
                }
            }

            double[] M = MList.ToArray();

            int[] K = new int[] { 1, 2, 3, 4, 5, 6 };

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Номер";
            dataGridView1.Columns[1].Name = "Точка на координаті розміру ключа N (біт)";
            dataGridView1.Columns[2].Name = "Точка на координаті часу (с)";

            ChartArea chartArea = new ChartArea();
            ChartGenerating.ChartAreas.Add(chartArea);

            Series series = new Series();
            ChartGenerating.Series.Add(series);

            series.ChartType = SeriesChartType.Line;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            for (int i = 0; i < Math.Min(N.Length, M.Length); i++)
            {
                series.Points.AddXY(N[i], M[i]);

                string[] row = new string[] { K[i].ToString(), N[i].ToString(), M[i].ToString() };
                dataGridView1.Rows.Add(row);
            }

            series.BorderWidth = 3;

            series.Name = saveDialogFileName;
            series.LegendText = series.Name;
            series.Color = Color.Red;

            chartArea.AxisX.Title = "Розмір ключа N (біт)";
            chartArea.AxisX.TitleFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);

            chartArea.AxisY.Title = "Час (с)";
            chartArea.AxisY.TitleFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);

            Title seriesTitle = new Title();
            seriesTitle.Name = "SeriesTitle";
            seriesTitle.Text = series.Name;
            seriesTitle.Docking = Docking.Top;
            ChartGenerating.Titles.Add(seriesTitle);

            Legend legend = new Legend();
            legend.Docking = Docking.Right;
            ChartGenerating.Legends.Add(legend);
        }

        private void SaveButton_Click(object sender, EventArgs e, string saveDialogFileName, Chart chart1)
        {
            string savePath = Path.Combine("..\\..\\..\\Schedule\\", saveDialogFileName + ".png");

            chart1.SaveImage(savePath, ChartImageFormat.Png);
            MessageBox.Show("Зображення збережено.");
        }

        private void SaveTable_Click(object sender, EventArgs e, DataGridView dataGridViewT, string TableFile)
        {
            SaveDataGridViewToExcel(dataGridViewT, TableFile);
        }

        private void SaveDataGridViewToExcel(DataGridView dataGridView, string fileName)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add(fileName);

                for (int i = 1; i <= dataGridView.Columns.Count; i++)
                {
                    worksheet.Cell(1, i).Value = dataGridView.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        object cellValue = dataGridView.Rows[i].Cells[j].Value;
                        string stringValue = cellValue != null ? cellValue.ToString() : "";

                        worksheet.Cell(i + 2, j + 1).Value = stringValue;
                    }
                }

                string excelPath = Path.Combine("..\\..\\..\\Table\\", fileName + ".xlsx");
                workbook.SaveAs(excelPath);

                MessageBox.Show("Таблицю збережено.");
            }
        }
    }
}