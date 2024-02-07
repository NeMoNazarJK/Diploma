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
    public partial class Form6 : Form
    {
        public Form6()
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

        private string Memory_Digital_Signature = "..\\..\\..\\Memory\\Digital Signature\\Memory_Digital_Signature.txt";
        private string Memory_Signature = "..\\..\\..\\Memory\\Digital Signature\\Memory_Signature.txt";
        private string Memory_Checklist = "..\\..\\..\\Memory\\Digital Signature\\Memory_Checklist.txt";
        private string Table_Digital_Signature = "DigitalSignatureTableMemory";
        private string Table_Signature = "SignatureTableMemory";
        private string Table_Checklist = "ChecklistTableMemory";
        private string saveDialogFileName = "Графік Генерація N-бітного ключа для електроного цифрового підпису RSA (пам'ять)";
        private string saveDialogFileNameSignature = "Графік N-бітного ключа для підписання електроного цифрового підпису RSA (пам'ять)";
        private string saveDialogFileNameChecklist = "Графік N-бітного ключа для перевірки електроного цифрового підпису RSA (пам'ять)";
        private string DialogMemory = "Операційна пам'ять (Мб)";
        private string pointonacoordinate = "Точка на координаті операційної пам'яті (Мб)";

        private Color seriesColor = Color.Blue;

        private void InitializeFormElements()
        {
            this.Size = new Size(1920, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA Digital Signature Graphs Memory";
            this.WindowState = FormWindowState.Maximized;

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
                Text = "Побудувати графік Генерація N-бітного ключа для електроного цифрового підпису RSA",
            };

            BuildingEncryption = new Button()
            {
                Location = new Point(1000, 350),
                Size = new Size(250, 45),
                Text = "Побудувати графік N-бітного ключа для підписання електроного цифрового підпису RSA",
            };

            BuildingDecrypted = new Button()
            {
                Location = new Point(1000, 690),
                Size = new Size(250, 45),
                Text = "Побудувати графік N-бітного ключа для перевірки електроного цифрового підпису RSA",
            };

            SaveGeneratingKey = new Button()
            {
                Location = new Point(1000, 70),
                Size = new Size(250, 45),
                Text = "Зберегти графік Генерація N-бітного ключа для електроного цифрового підпису RSA",
            };

            SaveGeneratingKeyT = new Button()
            {
                Location = new Point(1000, 130),
                Size = new Size(250, 45),
                Text = "Зберегти таблицю Генерація N-бітного ключа для електроного цифрового підпису RSA",
            };

            SaveEncryption = new Button()
            {
                Location = new Point(1000, 410),
                Size = new Size(250, 45),
                Text = "Зберегти графік N-бітного ключа для підписання електроного цифрового підпису RSA",
            };

            SaveEncryptionT = new Button()
            {
                Location = new Point(1000, 470),
                Size = new Size(250, 45),
                Text = "Зберегти таблицю N-бітного ключа для підписання електроного цифрового підпису RSA",
            };

            SaveDecrypted = new Button()
            {
                Location = new Point(1000, 750),
                Size = new Size(250, 45),
                Text = "Зберегти графік N-бітного ключа для перевірки електроного цифрового підпису RSA",
            };

            SaveDecryptedT = new Button()
            {
                Location = new Point(1000, 810),
                Size = new Size(250, 45),
                Text = "Зберегти таблицю N-бітного ключа для перевірки електроного цифрового підпису RSA",
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
                Building.BuildingButton_Click(sender, e, N, ChartGeneratingKey, Memory_Digital_Signature, saveDialogFileName, dataGridViewGK, DialogMemory, seriesColor, pointonacoordinate);
            };

            BuildingEncryption.Click += (sender, e) =>
            {
                Building.BuildingButton_Click(sender, e, N, ChartEncryption, Memory_Signature, saveDialogFileNameSignature, dataGridViewEncryption, DialogMemory, seriesColor, pointonacoordinate);
            };

            BuildingDecrypted.Click += (sender, e) =>
            {
                Building.BuildingButton_Click(sender, e, N, ChartDecrypted, Memory_Checklist, saveDialogFileNameChecklist, dataGridViewDecrypted, DialogMemory, seriesColor, pointonacoordinate);
            };

            SaveGeneratingKey.Click += (sender, e) =>
            {
                saveInstance.SaveButton_Click(sender, e, saveDialogFileName, ChartGeneratingKey);
            };

            SaveEncryption.Click += (sender, e) =>
            {
                saveInstance.SaveButton_Click(sender, e, saveDialogFileNameSignature, ChartEncryption);
            };

            SaveDecrypted.Click += (sender, e) =>
            {
                saveInstance.SaveButton_Click(sender, e, saveDialogFileNameChecklist, ChartDecrypted);
            };

            SaveGeneratingKeyT.Click += (sender, e) =>
            {
                saveInstance.SaveDataGridViewToExcel(sender, e, dataGridViewGK, Table_Digital_Signature);
            };

            SaveEncryptionT.Click += (sender, e) =>
            {
                saveInstance.SaveDataGridViewToExcel(sender, e, dataGridViewEncryption, Table_Signature);
            };

            SaveDecryptedT.Click += (sender, e) =>
            {
                saveInstance.SaveDataGridViewToExcel(sender, e, dataGridViewDecrypted, Table_Checklist);
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