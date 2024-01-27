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

namespace Diplom
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeFormElements();
        }

        private Chart ChartGeneratingKey;
        private Button SaveGeneratingKey;
        private Button BuildingGeneratingKey;

        private void InitializeFormElements()
        {
            this.Size = new Size(1920, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA_Graphs";

            ChartGeneratingKey = new Chart()
            {
                Location = new Point(10, 10),
                Size = new Size(990, 400),
            };

            BuildingGeneratingKey = new Button()
            {
                Location = new Point(1000, 10),
                Size = new Size(150, 45),
                Text = "Побудувати графік Генерація N-бітного ключа для RSA",
            };

            SaveGeneratingKey = new Button()
            {
                Location = new Point(1000, 70),
                Size = new Size(150, 45),
                Text = "Зберегти графік Генерація N-бітного ключа для RSA",
            };

            int[] N = new int[] { 256, 512, 1024, 2048, 4096, 8192 };
            int[] M = new int[] { 23, 12, 32, 11, 54, 20 };

            BuildingGeneratingKey.Click += (sender, e) =>
            {
                BuildingButton_Click(sender, e, N, M, ChartGeneratingKey);
            };

            string saveDialogFileName = "Графік Генерація N-бітного ключа для RSA";

            SaveGeneratingKey.Click += (sender, e) =>
            {
                SaveButton_Click(sender, e, saveDialogFileName, ChartGeneratingKey);
            };

            Controls.Add(ChartGeneratingKey);
            Controls.Add(BuildingGeneratingKey);
            Controls.Add(SaveGeneratingKey);
        }

        private void BuildingButton_Click(object sender, EventArgs e, int[] N, int[] M, Chart ChartGenerating)
        {
            ChartArea chartArea = new ChartArea();
            ChartGenerating.ChartAreas.Add(chartArea);

            Series series = new Series();
            ChartGenerating.Series.Add(series);

            series.ChartType = SeriesChartType.Spline;

            for (int i = 0; i < Math.Min(N.Length, M.Length); i++)
            {
                series.Points.AddXY(N[i], M[i]);
            }

            series.BorderWidth = 3;

            series.Name = "Генерація N-бітного ключа для RSA";
            series.LegendText = series.Name;
            series.Color = Color.Red;

            chartArea.AxisX.Title = "Довжина ключа";
            chartArea.AxisX.TitleFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);

            chartArea.AxisY.Title = "Час";
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
    }
}
