using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Diplom.RSA;
using System.Numerics;
using System.Collections.Generic;

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
        private Button btnDecryptedText;
        private TextBox txtTextSize;
        private TextBox txtGeneratingkeys;
        private Label lblPrivatekeyTime;
        private Label lblPublickeyTime;
        private Label lblEncryptionTextTime;
        private Label lblDecryptedTextTime;

        private string PrivatekeyTime = "";
        private string PublickeyTime = "";
        private string EncryptionTextTime = "";
        private string DecryptedTextTime = "";
        private string fileEncryptionTextPath = "";
        private string fileDecryptedKeyPath = "";
        List<BigInteger> encryptedBlocks = new List<BigInteger>();

        private void InitializeFormElements()
        {
            this.Size = new Size(1920, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA";

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

            lblDecryptedTextTime = new Label
            {
                Location = new Point(750, 60),
                AutoSize = true,
                Text = ""
            };

            txtGeneratingkeys = new TextBox
            {
                Location = new Point(500, 10),
                Size = new Size(40, 40),
                Text = "2048"
            };

            btnGeneratingkeys = new Button
            {
                Location = new Point(500, 40),
                Size = new Size(150, 45),
                Text = "Згенерувати пару ключів"
            };

            btnEncryptionText = new Button
            {
                Location = new Point(500, 100),
                Size = new Size(150, 45),
                Text = "Зашифрувати ведений текст"
            };

            btnDecryptedText = new Button
            {
                Location = new Point(500, 160),
                Size = new Size(150, 45),
                Text = "Розшифрування тексту"
            };

            btnGeneratingkeys.Click += (sender, e) =>
            {
                GeneratingKeys.OnGeneratingKeysClick(sender, e, txtGeneratingkeys.Text, out PrivatekeyTime, out PublickeyTime);
                lblPrivatekeyTime.Text = $"Час генерування приватного ключа: {PrivatekeyTime}";
                lblPublickeyTime.Text = $"Час генерування публічного ключа: {PublickeyTime}";
            };

            btnEncryptionText.Click += (sender, e) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileEncryptionTextPath = openFileDialog.FileName;
                }
                EncryptionRSA.OnEncryptionTextClick(sender, e, txtTextSize.Text, out EncryptionTextTime, fileEncryptionTextPath);
                lblEncryptionTextTime.Text = $"Час за шифрування: {EncryptionTextTime}";
            };

            btnDecryptedText.Click += (sender, e) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileDecryptedKeyPath = openFileDialog.FileName;
                }
                DecryptedRSA.OnDecryptedTextClick(sender, e, out DecryptedTextTime, fileDecryptedKeyPath);
                lblDecryptedTextTime.Text = $"Час розшифрування: {DecryptedTextTime}";
            };
            lblPrivatekeyTime.Text = $"Час генерування приватного ключа: {PrivatekeyTime}";
            lblPublickeyTime.Text = $"Час генерування публічного ключа: {PublickeyTime}";
            lblEncryptionTextTime.Text = $"Час за шифрування: {EncryptionTextTime}";
            lblDecryptedTextTime.Text = $"Час розшифрування: {DecryptedTextTime}";

            Controls.Add(btnGeneratingkeys);
            Controls.Add(btnEncryptionText);
            Controls.Add(btnDecryptedText);
            Controls.Add(txtTextSize);
            Controls.Add(txtGeneratingkeys);
            Controls.Add(lblPrivatekeyTime);
            Controls.Add(lblPublickeyTime);
            Controls.Add(lblEncryptionTextTime);
            Controls.Add(lblDecryptedTextTime);
        }
    }
}