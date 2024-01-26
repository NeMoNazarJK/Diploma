using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Diplom.RSA;

namespace Diplom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeFormElements();
        }

        private Button btnGeneratingkeys;
        private Button btnEncryptionText;
        private Button btnOpenFileEncryptionText;
        private TextBox txtTextSize;
        private TextBox txtGeneratingkeys;
        private Label lblPrivatekeyTime;
        private Label lblPublickeyTime;
        private Label lblEncryptionTextTime;

        private string PrivatekeyTime = "";
        private string PublickeyTime = "";
        private string EncryptionTextTime = "";
        private string fileEncryptionTextPath = "";

        private void InitializeFormElements()
        {
            this.Size = new Size(1920, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA";

            btnGeneratingkeys = new Button
            {
                Location = new Point(500, 40),
                Size = new Size(180, 22),
                Text = "Згенерувати пару ключів"
            };

            txtGeneratingkeys = new TextBox
            {
                Location = new Point(500, 10),
                Size = new Size(40, 40),
                Text = "2048"
            };

            txtTextSize = new TextBox
            {
                Location = new Point(10, 10),
                Size = new Size(400, 150),
                Text = ""
            };

            lblPrivatekeyTime = new Label
            {
                Location = new Point(750, 15),
                AutoSize = true,
                Text = ""
            };

            lblPublickeyTime = new Label
            {
                Location = new Point(750, 30),
                AutoSize = true,
                Text = ""
            };

            lblEncryptionTextTime = new Label
            {
                Location = new Point(750, 45),
                AutoSize = true,
                Text = ""
            };

            btnOpenFileEncryptionText = new Button
            {
                Location = new Point(500, 80),
                Size = new Size(180, 22),
                Text = "Вибрати файл з публічним ключем"
            };

            btnEncryptionText = new Button
            {
                Location = new Point(500, 120),
                Size = new Size(180, 22),
                Text = "Зашифрувати ведений текст"
            };

            btnGeneratingkeys.Click += (sender, e) =>
            {
                GeneratingKeys.OnGeneratingKeysClick(sender, e, txtGeneratingkeys.Text, out PrivatekeyTime, out PublickeyTime);
                lblPrivatekeyTime.Text = $"Час генерування приватного ключа: {PrivatekeyTime}";
                lblPublickeyTime.Text = $"Час генерування публічного ключа: {PublickeyTime}";
            };

            btnOpenFileEncryptionText.Click += (sender, e) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileEncryptionTextPath = openFileDialog.FileName;
                }
            };

            btnEncryptionText.Click += (sender, e) =>
            {
                EncryptionRSA.OnEncryptionTextClick(sender, e, txtTextSize.Text, out EncryptionTextTime, fileEncryptionTextPath);
                lblEncryptionTextTime.Text = $"Час за шифрування: {EncryptionTextTime}";
            };

            Controls.Add(btnGeneratingkeys);
            Controls.Add(btnEncryptionText);
            Controls.Add(btnOpenFileEncryptionText);
            Controls.Add(txtTextSize);
            Controls.Add(txtGeneratingkeys);
            Controls.Add(lblPrivatekeyTime);
            Controls.Add(lblPublickeyTime);
            Controls.Add(lblEncryptionTextTime);

        }
    }
}