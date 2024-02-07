using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Diplom.RSA;
using System.Numerics;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Diplom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeFormElements();

            Icon = new Icon("..\\..\\..\\Icon\\Encryption.ico");
        }

        private Button btnGeneratingkeys;
        private Button btnEncryptionText;
        private Button btnDecryptedText;
        private Button OpenFiletClickE;
        private Button OpenFiletClickD;
        private Button OpenFiletClickA;
        private Button OpenFormGT;
        private Button OpenFormM;
        private Button OpenFormDS;
        private TextBox txtTextSize;
        private TextBox txtGeneratingkeys;
        private Label lblPrivatekeyTime;
        private Label lblPublickeyTime;
        private Label lblEncryptionTextTime;
        private Label lblDecryptedTextTime;
        private Label lblmemoryInMegabytesKey;
        private Label lblmemoryInMegabytesEncryption;
        private Label lblmemoryInMegabytesDecrypted;

        Form2 f2;
        Form3 f3;
        Form4 f4;

        private string PrivatekeyTime = "";
        private string PublickeyTime = "";
        private string EncryptionTextTime = "";
        private string DecryptedTextTime = "";
        private string fileEncryptionTextPath = "";
        private string fileDecryptedKeyPath = "";
        private double memoryInMegabytesK = 0.0;
        private double memoryInMegabytesE = 0.0;
        private double memoryInMegabytesD = 0.0;

        private void InitializeFormElements()
        {
            this.Size = new Size(1920, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA";
            this.WindowState = FormWindowState.Maximized;

            txtTextSize = new TextBox
            {
                Location = new Point(10, 10),
                Size = new Size(430, 150),
                Text = ""
            };

            lblPrivatekeyTime = new Label
            {
                Location = new Point(630, 15),
                AutoSize = true,
                Text = ""
            };

            lblPublickeyTime = new Label
            {
                Location = new Point(630, 30),
                AutoSize = true,
                Text = ""
            };

            lblEncryptionTextTime = new Label
            {
                Location = new Point(630, 45),
                AutoSize = true,
                Text = ""
            };

            lblDecryptedTextTime = new Label
            {
                Location = new Point(630, 60),
                AutoSize = true,
                Text = ""
            };

            lblmemoryInMegabytesKey = new Label
            {
                Location = new Point(945, 15),
                AutoSize = true,
                Text = ""
            };

            lblmemoryInMegabytesEncryption = new Label
            {
                Location = new Point(945, 30),
                AutoSize = true,
                Text = ""
            };

            lblmemoryInMegabytesDecrypted = new Label
            {
                Location = new Point(945, 45),
                AutoSize = true,
                Text = ""
            };

            txtGeneratingkeys = new TextBox
            {
                Location = new Point(460, 10),
                Size = new Size(40, 40),
                Text = "2048"
            };

            btnGeneratingkeys = new Button
            {
                Location = new Point(460, 40),
                Size = new Size(150, 45),
                Text = "Згенерувати пару ключів"
            };

            btnEncryptionText = new Button
            {
                Location = new Point(460, 100),
                Size = new Size(150, 45),
                Text = "Зашифрувати ведений текст"
            };

            btnDecryptedText = new Button
            {
                Location = new Point(460, 160),
                Size = new Size(150, 45),
                Text = "Розшифрування тексту"
            };

            OpenFiletClickE = new Button
            {
                Location = new Point(10, 100),
                Size = new Size(150, 45),
                Text = "Відкрити зашифрований текст"
            };

            OpenFiletClickD = new Button
            {
                Location = new Point(160, 100),
                Size = new Size(150, 45),
                Text = "Відкрити розшифрований текст"
            };

            OpenFiletClickA = new Button
            {
                Location = new Point(310, 100),
                Size = new Size(150, 45),
                Text = "Відкрити додаткову інформацію"
            };

            OpenFormGT = new Button
            {
                Location = new Point(630, 100),
                Size = new Size(150, 45),
                Text = "Відкрити графік часу"
            };

            OpenFormM = new Button
            {
                Location = new Point(945, 100),
                Size = new Size(150, 45),
                Text = "Відкрити графік пам'яті"
            };

            OpenFormDS = new Button
            {
                Location = new Point(460, 220),
                Size = new Size(150, 45),
                Text = "Цифровий підпис"
            };

            btnGeneratingkeys.Click += (sender, e) =>
            {
                using (Process process = Process.GetCurrentProcess())
                {
                    int bitLength = int.Parse(txtGeneratingkeys.Text);

                    GeneratingKeys.OnGeneratingKeysClick(sender, e, txtGeneratingkeys.Text, out PrivatekeyTime, out PublickeyTime);
                    lblPrivatekeyTime.Text = $"Час генерування приватного ключа: {PrivatekeyTime}";
                    lblPublickeyTime.Text = $"Час генерування публічного ключа: {PublickeyTime}";
                    memoryInMegabytesK = process.PrivateMemorySize64 / (1024 * 1024);

                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Memory\\Memory_Key_" + bitLength + "_біт.txt"))
                    {
                        file.WriteLine("{0}", memoryInMegabytesK);
                    }
                }
                lblmemoryInMegabytesKey.Text = $"Використана оперативна пам'ять: {memoryInMegabytesK} МБ для генерування ключів";

                MessageBox.Show("Ключі успішно згенеровані.");
            };

            btnEncryptionText.Click += (sender, e) =>
            {
                using (Process process = Process.GetCurrentProcess())
                {
                    int bitLength = int.Parse(txtGeneratingkeys.Text);

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileEncryptionTextPath = openFileDialog.FileName;
                    }
                    EncryptionRSA.OnEncryptionTextClick(sender, e, txtTextSize.Text, out EncryptionTextTime, fileEncryptionTextPath, txtGeneratingkeys.Text);
                    lblEncryptionTextTime.Text = $"Час шифрування: {EncryptionTextTime}";
                    memoryInMegabytesE = process.PrivateMemorySize64 / (1024 * 1024);

                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Memory\\Memory_Encryption_" + bitLength + "_біт.txt"))
                    {
                        file.WriteLine("{0}", memoryInMegabytesE);
                    }
                }
                lblmemoryInMegabytesEncryption.Text = $"Використана оперативна пам'ять: {memoryInMegabytesE} МБ для шифрування тексту";

                MessageBox.Show("За шифрування виконано успішно.");
            };

            btnDecryptedText.Click += (sender, e) =>
            {
                using (Process process = Process.GetCurrentProcess())
                {
                    int bitLength = int.Parse(txtGeneratingkeys.Text);

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileDecryptedKeyPath = openFileDialog.FileName;
                    }
                    DecryptedRSA.OnDecryptedTextClick(sender, e, out DecryptedTextTime, fileDecryptedKeyPath, txtGeneratingkeys.Text);
                    lblDecryptedTextTime.Text = $"Час розшифрування: {DecryptedTextTime}";
                    memoryInMegabytesD = process.PrivateMemorySize64 / (1024 * 1024);

                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Memory\\Memory_Decrypted_" + bitLength + "_біт.txt"))
                    {
                        file.WriteLine("{0}", memoryInMegabytesD);
                    }
                }
                lblmemoryInMegabytesDecrypted.Text = $"Використана оперативна пам'ять: {memoryInMegabytesD} МБ для для розшифрування тексту";

                MessageBox.Show("Розшифрування виконано успішно.");
            };

            OpenFiletClickE.Click += (sender, e) =>
            {
                OpenFile.OpenFiletClickEncryption(sender, e);
            };

            OpenFiletClickD.Click += (sender, e) =>
            {
                OpenFile.OpenFiletClickDecrypted(sender, e);
            };

            OpenFiletClickA.Click += (sender, e) =>
            {
                OpenFile.OpenFiletClickАdditional(sender, e);
            };

            OpenFormGT.Click += (sender, e) =>
            {
                oHacToolStrip2_Click(sender, e, f2);
            };

            OpenFormM.Click += (sender, e) =>
            {
                oHacToolStrip3_Click(sender, e, f3);
            };

            OpenFormDS.Click += (sender, e) =>
            {
                using (StreamWriter file = new StreamWriter("..\\..\\..\\Files\\Digital_signature.txt"))
                {
                    file.WriteLine("{0}", txtTextSize.Text);
                }
                oHacToolStrip4_Click(sender, e, f4);
            };

            lblmemoryInMegabytesKey.Text = $"Використана оперативна пам'ять: {memoryInMegabytesK} МБ для генерування ключів";
            lblmemoryInMegabytesEncryption.Text = $"Використана оперативна пам'ять: {memoryInMegabytesE} МБ для шифрування тексту";
            lblmemoryInMegabytesDecrypted.Text = $"Використана оперативна пам'ять: {memoryInMegabytesD} МБ для розшифрування тексту";
            lblPrivatekeyTime.Text = $"Час генерування приватного ключа: {PrivatekeyTime}";
            lblPublickeyTime.Text = $"Час генерування публічного ключа: {PublickeyTime}";
            lblEncryptionTextTime.Text = $"Час шифрування: {EncryptionTextTime}";
            lblDecryptedTextTime.Text = $"Час розшифрування: {DecryptedTextTime}";

            Controls.Add(btnGeneratingkeys);
            Controls.Add(btnEncryptionText);
            Controls.Add(btnDecryptedText);
            Controls.Add(OpenFiletClickE);
            Controls.Add(OpenFiletClickD);
            Controls.Add(OpenFiletClickA);
            Controls.Add(OpenFormGT);
            Controls.Add(OpenFormM);
            Controls.Add(OpenFormDS);
            Controls.Add(txtTextSize);
            Controls.Add(txtGeneratingkeys);
            Controls.Add(lblPrivatekeyTime);
            Controls.Add(lblPublickeyTime);
            Controls.Add(lblEncryptionTextTime);
            Controls.Add(lblDecryptedTextTime);
            Controls.Add(lblmemoryInMegabytesKey);
            Controls.Add(lblmemoryInMegabytesEncryption);
            Controls.Add(lblmemoryInMegabytesDecrypted);
        }

        private void oHacToolStrip2_Click(object sender, EventArgs e, Form f)
        {
            ReadingandWriting.PerformReadingAndWritingGKTime(sender, e);
            ReadingandWriting.PerformReadingAndWritingETime(sender, e);
            ReadingandWriting.PerformReadingAndWritingDTime(sender, e);
            f = new Form2();
            f.Show();
        }

        private void oHacToolStrip3_Click(object sender, EventArgs e, Form f)
        {
            ReadingandWriting.PerformReadingAndWritingGKMemory(sender, e);
            ReadingandWriting.PerformReadingAndWritingEMemory(sender, e);
            ReadingandWriting.PerformReadingAndWritingDMemory(sender, e);
            f = new Form3();
            f.Show();
        }

        private void oHacToolStrip4_Click(object sender, EventArgs e, Form f)
        {
            f = new Form4();
            f.Show();
        }
    }
}