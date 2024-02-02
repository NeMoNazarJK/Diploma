using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Diplom
{
    internal class Building
    {
        public static void BuildingButton_Click(object sender, EventArgs e, int[] N, Chart ChartGenerating, string file, string saveDialogFileName, DataGridView dataGridView1, string Dialog, Color seriesColor, string pointonacoordinate)
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
            dataGridView1.Columns[2].Name = pointonacoordinate;

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
            series.Color = seriesColor;

            chartArea.AxisX.Title = "Розмір ключа N (біт)";
            chartArea.AxisX.TitleFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);

            chartArea.AxisY.Title = Dialog;
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

    }
}