using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Practical_Part_of_the_Diploma.RSA;
using System.Data.Common;

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
        private Button buttonEncryption;
        private Button buttonDecrypted;
        private Button buttonEncryptionSave;
        private ComboBox сomboBoxGeneratingkeys;
        private Label labelKeyTime;
        private Label labelEncryptionTime;
        private Label labelDecryptedTime;
        private Label labelKeyMemory;
        private Label labelEncryptionMemory;
        private Label labelDecryptedMemory;

        private string KeyTime = "";
        private string EncryptionTime = "";
        private string DecryptedTime = "";
        private double memoryInMegabytesKey = 0.0;
        private double memoryInMegabytesEncryption = 0.0;
        private double memoryInMegabytesDecrypted = 0.0;
        private string[] keySizes = { "16", "2048", "3072", "4096" };

        private string alphabet = "—ABCDEFGHIJKLMNOPQRSTUVWXYZАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯabcdefghijklmnopqrstuvwxyzабвгґдеєжзиіїйклмнопрстуфхцчшщьюя \"\r\n'’.,:;!?-1234567890«»";

        private void InitializeFormElements()
        {
            this.Size = new Size(1920, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            dataGridViewDataBase = new DataGridView()
            {
                Location = new Point(10, 10),
                Size = new Size(900, 220),
            };

            groupBoxButton = new GroupBox()
            {
                Location = new Point(920, 10),
                Size = new Size(350, 470),
                Text = "Елементи керування",
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold | FontStyle.Italic)
            };

            groupBoxLabelTime = new GroupBox()
            {
                Location = new Point(10, 230),
                Size = new Size(445, 250),
                Text = "Час",
                Font = new Font("Comic Sans MS", 9, FontStyle.Bold | FontStyle.Italic)
            };

            groupBoxLabelMemory = new GroupBox()
            {
                Location = new Point(465, 230),
                Size = new Size(445, 250),
                Text = "Пам'ять",
                Font = new Font("Comic Sans MS", 9, FontStyle.Bold | FontStyle.Italic)
            };

            buttonOpenDataBase = new Button()
            {
                Location = new Point((groupBoxButton.Width - 250) / 2, 30),
                Size = new Size(250, 45),
                Text = "Відкрити базу даних",
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold | FontStyle.Italic)
            };

            buttonGeneratingkeys = new Button()
            {
                Location = new Point((groupBoxButton.Width - 250) / 2, 140),
                Size = new Size(250, 45),
                Text = "Згенерувати клюці RSA",
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold | FontStyle.Italic)
            };

            buttonEncryption = new Button()
            {
                Location = new Point((groupBoxButton.Width - 250) / 2, 195),
                Size = new Size(250, 45),
                Text = "Зашифрувати Базу даних",
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold | FontStyle.Italic)
            };

            buttonDecrypted = new Button()
            {
                Location = new Point((groupBoxButton.Width - 250) / 2, 250),
                Size = new Size(250, 45),
                Text = "Розшифрувати Базу даних",
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold | FontStyle.Italic)
            };

            buttonEncryptionSave = new Button()
            {
                Location = new Point((groupBoxButton.Width - 250) / 2, 305),
                Size = new Size(250, 45),
                Text = "Перезаписати Базу даних",
                BackColor = Color.Black,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold | FontStyle.Italic)
            };

            сomboBoxGeneratingkeys = new ComboBox()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point((groupBoxButton.Width - 250) / 2, 85),
                Size = new Size(250, 45),
                BackColor = Color.White,
                ForeColor = Color.Black,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold | FontStyle.Italic)
            };

            labelKeyTime = new Label
            {
                Location = new Point(10, 30),
                AutoSize = true,
                Text = $"Час генерування ключа: {KeyTime}"
            };

            labelEncryptionTime = new Label
            {
                Location = new Point(10, 55),
                AutoSize = true,
                Text = $"Час зашифрування бази даних: {EncryptionTime}"
            };

            labelDecryptedTime = new Label
            {
                Location = new Point(10, 80),
                AutoSize = true,
                Text = $"Час розшифрування бази даних: {DecryptedTime}"
            };

            labelKeyMemory = new Label
            {
                Location = new Point(10, 30),
                AutoSize = true,
                Text = $"Виділена пам'ять: {memoryInMegabytesKey} МБ для створення ключа"
            };

            labelEncryptionMemory = new Label
            {
                Location = new Point(10, 55),
                AutoSize = true,
                Text = $"Виділена пам'ять: {memoryInMegabytesEncryption} МБ для шифрування бази даних"
            };

            labelDecryptedMemory = new Label
            {
                Location = new Point(10, 80),
                AutoSize = true,
                Text = $"Виділена пам'ять: {memoryInMegabytesDecrypted} МБ для розшифроування бази даних"
            };

            сomboBoxGeneratingkeys.Items.AddRange(keySizes);
            сomboBoxGeneratingkeys.SelectedIndex = 0;

            buttonOpenDataBase.Click += (sender, a) =>
            {
                DataTable dataTable = OpenFile.OnOpenDataBaseClick(sender, a);
                if (dataTable != null)
                {
                    dataGridViewDataBase.DataSource = dataTable;
                    dataGridViewDataBase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    MessageBox.Show($"Базу даних відкрито");
                }
                else
                {
                    MessageBox.Show($"Не вдалося відкрити базу даних");
                }
            };

            сomboBoxGeneratingkeys.SelectedIndexChanged += (sender, a) =>
            {
                string selectedOption = сomboBoxGeneratingkeys.SelectedItem.ToString();
                MessageBox.Show($"Вибрано: {selectedOption}");
            };

            buttonGeneratingkeys.Click += (sender, a) =>
            {
                using (Process process = Process.GetCurrentProcess())
                {
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    GeneratingKeys.OnGeneratingKeysClick(sender, a, сomboBoxGeneratingkeys.SelectedItem.ToString());
                    stopwatch.Stop();
                    TimeSpan GeneratingKey = stopwatch.Elapsed;
                    KeyTime = GeneratingKey.ToString();
                    memoryInMegabytesKey = process.PrivateMemorySize64 / (1024 * 1024);

                    labelKeyTime.Text = $"Час генерування ключа: {KeyTime}";
                }
                labelKeyMemory.Text = $"Виділена пам'ять: {memoryInMegabytesKey} МБ для створення ключа";

                MessageBox.Show("Ключі згенерувалися");
            };

            buttonEncryption.Click += (sender, a) =>
            {
                using (Process process = Process.GetCurrentProcess())
                {
                    string PublickeyPath = OpenFile.OnOpenFileKeyClick(sender, a);

                    DataTable dataTable = (DataTable)dataGridViewDataBase.DataSource;

                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    EncryptDataBase.OnEncryptDataBaseClick(sender, a, PublickeyPath, dataTable, dataGridViewDataBase, alphabet);
                    stopwatch.Stop();
                    TimeSpan Encryption = stopwatch.Elapsed;
                    EncryptionTime = Encryption.ToString();
                    memoryInMegabytesEncryption = process.PrivateMemorySize64 / (1024 * 1024);

                    labelEncryptionTime.Text = $"Час зашифрування бази даних: {EncryptionTime}";
                }
                labelEncryptionMemory.Text = $"Виділена пам'ять: {memoryInMegabytesEncryption} МБ для шифрування бази даних";

                MessageBox.Show("Шифрування завершилося");
            };

            buttonDecrypted.Click += (sender, a) =>
            {
                using (Process process = Process.GetCurrentProcess())
                {
                    string PrivatekeyPath = OpenFile.OnOpenFileKeyClick(sender, a);

                    DataTable dataTable = (DataTable)dataGridViewDataBase.DataSource;

                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    DecryptedDataBase.OnDecryptedDataBaseClick(sender, a, PrivatekeyPath, dataTable, dataGridViewDataBase, alphabet);
                    stopwatch.Stop();
                    TimeSpan Decrypted = stopwatch.Elapsed;
                    DecryptedTime = Decrypted.ToString();
                    memoryInMegabytesDecrypted = process.PrivateMemorySize64 / (1024 * 1024);

                    labelDecryptedTime.Text = $"Час розшифрування бази даних: {DecryptedTime}";
                }
                labelDecryptedMemory.Text = $"Виділена пам'ять: {memoryInMegabytesDecrypted} МБ для розшифроування бази даних";

                MessageBox.Show("Розшифрування завершилося");
            };

            buttonEncryptionSave.Click += (sender, a) =>
            {
                if (dataGridViewDataBase.DataSource != null)
                {
                    DataTable dataTable = (DataTable)dataGridViewDataBase.DataSource;

                    string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\..\\Database\\Database.accdb;Persist Security Info=False;";

                    using (OleDbConnection connection = new OleDbConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            foreach (DataGridViewRow row in dataGridViewDataBase.Rows)
                            {
                                if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                                {
                                    string id = row.Cells[0].Value.ToString();
                                    string name = row.Cells[1].Value.ToString();
                                    string date_of_entry = row.Cells[2].Value.ToString();
                                    string age = row.Cells[3].Value.ToString();
                                    string curriculum = row.Cells[4].Value.ToString();
                                    string group = row.Cells[5].Value.ToString();
                                    string specialty = row.Cells[6].Value.ToString();


                                    string query = "UPDATE Studens SET Name = ?, Date_of_entry = ?, Age = ?, Curriculum = ?, [Group] = ?, Specialty = ? WHERE id = ?";
                                    OleDbCommand dbCommand = new OleDbCommand(query, connection);
                                    dbCommand.Parameters.AddWithValue("@name", name);
                                    dbCommand.Parameters.AddWithValue("@date_of_entry", date_of_entry);
                                    dbCommand.Parameters.AddWithValue("@age", age);
                                    dbCommand.Parameters.AddWithValue("@curriculum", curriculum);
                                    dbCommand.Parameters.AddWithValue("@group", group);
                                    dbCommand.Parameters.AddWithValue("@specialty", specialty);
                                    dbCommand.Parameters.AddWithValue("@id", id);
                                    dbCommand.ExecuteNonQuery();

                                }
                            }

                            MessageBox.Show("Дані успішно оновлені у базі даних.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Помилка під час оновлення даних: {ex.Message}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Джерело даних DataGridView є пустим.");
                }
            };

            groupBoxButton.Controls.Add(buttonOpenDataBase);
            groupBoxButton.Controls.Add(buttonGeneratingkeys);
            groupBoxButton.Controls.Add(buttonEncryption);
            groupBoxButton.Controls.Add(buttonDecrypted);
            groupBoxButton.Controls.Add(buttonEncryptionSave);
            groupBoxButton.Controls.Add(сomboBoxGeneratingkeys);

            groupBoxLabelTime.Controls.Add(labelKeyTime);
            groupBoxLabelTime.Controls.Add(labelEncryptionTime);
            groupBoxLabelTime.Controls.Add(labelDecryptedTime);

            groupBoxLabelMemory.Controls.Add(labelKeyMemory);
            groupBoxLabelMemory.Controls.Add(labelEncryptionMemory);
            groupBoxLabelMemory.Controls.Add(labelDecryptedMemory);

            Controls.Add(dataGridViewDataBase);
            Controls.Add(groupBoxButton);
            Controls.Add(groupBoxLabelTime);
            Controls.Add(groupBoxLabelMemory);
        }
    }
}