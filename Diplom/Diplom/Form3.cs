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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeFormElements();

            Icon = new Icon("..\\..\\..\\Icon\\Schedule.ico");
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

        private string Memory_Generating_Key = "..\\..\\..\\Memory\\Memory_Key.txt";
        private string Memory_Encryption = "..\\..\\..\\Memory\\Memory_Encryption.txt";
        private string Memory_Decrypted = "..\\..\\..\\Memory\\Memory_Decrypted.txt";
        private string Table_Generating_Key = "GeneratingKeyTableMemory";
        private string Table_Encryption = "EncryptionTableMemory";
        private string Table_Decrypted = "DecryptedTableMemory";
        private string saveDialogFileName = "Графік Генерація N-бітного ключа для RSA (пам'ять)";
        private string saveDialogFileNameEncryption = "Графік Шифрування N-бітного ключа для RSA (пам'ять)";
        private string saveDialogFileNameDecrypted = "Графік Розшифрування N-бітного ключа для RSA (пам'ять)";
        private string DialogMemory = "Операційна пам'ять (Мб)";
        private string pointonacoordinate = "Точка на координаті операційної пам'яті (Мб)";

        private Color seriesColor = Color.Red;

        private void InitializeFormElements()
        {
            this.Size = new Size(1920, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA Graphs Memory";

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
                Building.BuildingButton_Click(sender, e, N, ChartGeneratingKey, Memory_Generating_Key, saveDialogFileName, dataGridViewGK, DialogMemory, seriesColor, pointonacoordinate);
            };

            BuildingEncryption.Click += (sender, e) =>
            {
                Building.BuildingButton_Click(sender, e, N, ChartEncryption, Memory_Encryption, saveDialogFileNameEncryption, dataGridViewEncryption, DialogMemory, seriesColor, pointonacoordinate);
            };

            BuildingDecrypted.Click += (sender, e) =>
            {
                Building.BuildingButton_Click(sender, e, N, ChartDecrypted, Memory_Decrypted, saveDialogFileNameDecrypted, dataGridViewDecrypted, DialogMemory, seriesColor, pointonacoordinate);
            };

            SaveGeneratingKey.Click += (sender, e) =>
            {
                saveInstance.SaveButton_Click(sender, e, saveDialogFileName, ChartGeneratingKey);
            };

            SaveEncryption.Click += (sender, e) =>
            {
                saveInstance.SaveButton_Click(sender, e, saveDialogFileNameEncryption, ChartEncryption);
            };

            SaveDecrypted.Click += (sender, e) =>
            {
                saveInstance.SaveButton_Click(sender, e, saveDialogFileNameDecrypted, ChartDecrypted);
            };

            SaveGeneratingKeyT.Click += (sender, e) =>
            {
                saveInstance.SaveDataGridViewToExcel(sender, e, dataGridViewGK, Table_Generating_Key);
            };

            SaveEncryptionT.Click += (sender, e) =>
            {
                saveInstance.SaveDataGridViewToExcel(sender, e, dataGridViewEncryption, Table_Encryption);
            };

            SaveDecryptedT.Click += (sender, e) =>
            {
                saveInstance.SaveDataGridViewToExcel(sender, e, dataGridViewDecrypted, Table_Decrypted);
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
    }
}
