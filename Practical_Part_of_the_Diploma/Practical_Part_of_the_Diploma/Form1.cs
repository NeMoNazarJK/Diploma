using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Practical_Part_of_the_Diploma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeFormElements();
        }

        private DataGridView dataGridViewDataBase;
        private Button buttonOpenDataBase;
        private Button buttonGeneratingkeys;
        private ComboBox сomboBoxGeneratingkeys;
        private Label labelKeyTime;
        private Label labelKeyMemory;


        private string KeyTime = "";
        private double memoryInMegabytesKey = 0.0;

        private void InitializeFormElements()
        {
            this.Size = new Size(1920, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA";
            this.WindowState = FormWindowState.Maximized;

            dataGridViewDataBase = new DataGridView()
            {
                Location = new Point(10, 10),
                Size = new Size(900, 220),
            };

            buttonOpenDataBase = new Button()
            {
                Location = new Point(920,10),
                Size = new Size(250, 45),
                Text = "Відкрити базу даних",
            };

            buttonGeneratingkeys = new Button()
            {
                Location = new Point(920, 110),
                Size = new Size(250, 45),
                Text = "Згенерувати клюці RSA",
            };

            сomboBoxGeneratingkeys = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(920, 60),
                Size = new Size(250, 45),
            };

            labelKeyTime = new Label
            {
                Location = new Point(630, 15),
                AutoSize = true,
                Text = ""
            };

            сomboBoxGeneratingkeys.Items.Add("2048");
            сomboBoxGeneratingkeys.Items.Add("3072");
            сomboBoxGeneratingkeys.Items.Add("4096");

            сomboBoxGeneratingkeys.SelectedIndex = 0;

            buttonOpenDataBase.Click += (sender, e) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "База даних Access (*.mdb, *.accdb)|*.mdb;*.accdb";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={openFileDialog.FileName};";
                    string query = "SELECT * FROM Studens";

                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                        DataTable dataTable = new DataTable();

                        adapter.Fill(dataTable);
                        dataGridViewDataBase.DataSource = dataTable;
                        dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        MessageBox.Show($"Базу даних відкрито");
                    }
                }
            };

            сomboBoxGeneratingkeys.SelectedIndexChanged += (sender, e) =>
            {
                string selectedOption = сomboBoxGeneratingkeys.SelectedItem.ToString();
                MessageBox.Show($"Вибрано: {selectedOption}");
            };

            buttonGeneratingkeys.Click += (sender, e) =>
            {
                using (Process process = Process.GetCurrentProcess())
                {

                    //GeneratingKeys.OnGeneratingKeysClick(sender, e, сomboBoxGeneratingkeys, out KeyTime);
                    labelKeyTime.Text = $"×àñ ãåíåðóâàííÿ ïðèâàòíîãî êëþ÷à: {KeyTime}";
                }
                labelKeyMemory.Text = $"Âèêîðèñòàíà îïåðàòèâíà ïàì'ÿòü: {memoryInMegabytesKey} ÌÁ äëÿ ãåíåðóâàííÿ êëþ÷³â";

                MessageBox.Show("Клюці згенерувалися");
            };

            Controls.Add(dataGridViewDataBase);
            Controls.Add(buttonOpenDataBase);
            Controls.Add(buttonGeneratingkeys);
            Controls.Add(сomboBoxGeneratingkeys);
        }
    }
}