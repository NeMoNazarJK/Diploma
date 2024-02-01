using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;

namespace Diplom
{
    internal class saveInstance
    {
        public static void SaveButton_Click(object sender, EventArgs e, string saveDialogFileName, Chart chart1)
        {
            string savePath = Path.Combine("..\\..\\..\\Schedule\\", saveDialogFileName + ".png");

            chart1.SaveImage(savePath, ChartImageFormat.Png);
            MessageBox.Show("Зображення збережено.");
        }

        public static void SaveDataGridViewToExcel(object sender, EventArgs e, DataGridView dataGridView, string fileName)
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
