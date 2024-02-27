using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Practical_Part_of_the_Diploma.RSA;

namespace Practical_Part_of_the_Diploma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeFormElements();

            Icon = new Icon("..\\..\\..\\Icon\\Encryption.ico");
        }

        private DataGridView dataGridViewDataBase;
        private GroupBox groupBoxButton;
        private GroupBox groupBoxLabelTime;
        private GroupBox groupBoxLabelMemory;
        private Button buttonOpenDataBase;
        private Button buttonGeneratingkeys;
        private ComboBox сomboBoxGeneratingkeys;
        private Label labelKeyTime;
        private Label labelKeyMemory;

        private string KeyTime = "";
        private double memoryInMegabytesKey = 0.0;
        private string[] keySizes = { "2048", "3072", "4096" };

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

            groupBoxButton = new GroupBox()
            {
                Location = new Point(920, 10),
                Size = new Size(350, 250),
                Text = "Елементи керування"
            };

            groupBoxLabelTime = new GroupBox()
            {
                Location = new Point(1280, 10),
                Size = new Size(320, 250),
                Text = "Час"
            };

            buttonOpenDataBase = new Button()
            {
                Location = new Point((groupBoxButton.Width - 250) / 2, 30), // розташування по горизонталі: середина groupBoxButton
                Size = new Size(250, 45),
                Text = "Відкрити базу даних",
            };

            buttonGeneratingkeys = new Button()
            {
                Location = new Point((groupBoxButton.Width - 250) / 2, 140),
                Size = new Size(250, 45),
                Text = "Згенерувати клюці RSA",
            };

            сomboBoxGeneratingkeys = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point((groupBoxButton.Width - 250) / 2, 85),
                Size = new Size(250, 45),
            };

            labelKeyTime = new Label
            {
                Location = new Point(10, 30),
                AutoSize = true,
                Text = $"Час генерування ключа: {KeyTime}"
            };

            labelKeyMemory = new Label
            {
                Location = new Point(1600, 15),
                AutoSize = true,
                Text = $"Виділена пам'ять: {memoryInMegabytesKey} МБ для створення ключа"
            };

            groupBoxButton.Controls.Add(buttonOpenDataBase);
            groupBoxButton.Controls.Add(buttonGeneratingkeys);
            groupBoxButton.Controls.Add(сomboBoxGeneratingkeys);

            groupBoxLabelTime.Controls.Add(labelKeyTime);

            сomboBoxGeneratingkeys.Items.AddRange(keySizes);
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
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    GeneratingKeys.OnGeneratingKeysClick(sender, e, сomboBoxGeneratingkeys.SelectedItem.ToString());
                    stopwatch.Stop();
                    TimeSpan GeneratingKey = stopwatch.Elapsed;
                    KeyTime = GeneratingKey.ToString();

                    labelKeyTime.Text = $"Час генерування ключа: {KeyTime}";
                }
                labelKeyMemory.Text = $"Виділена пам'ять: {memoryInMegabytesKey} МБ для створення ключа";

                MessageBox.Show("Ключі згенерувалися");
            };

            Controls.Add(dataGridViewDataBase);
            Controls.Add(groupBoxButton);
            Controls.Add(groupBoxLabelTime);
            Controls.Add(labelKeyMemory);
        }
    }
}