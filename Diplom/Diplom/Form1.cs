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
        private TextBox txtTextSize;
        private TextBox txtGeneratingkeys;
        private Label lblPrivatekeyTime;
        private Label lblPublickeyTime;
        private Label lblEncryptionTextTime;

        private string PrivatekeyTime = "";
        private string PublickeyTime = "";
        private string EncryptionTextTime = "";

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

            btnEncryptionText = new Button
            {
                Location = new Point(500, 80),
                Size = new Size(180, 22),
                Text = "Зашифрувати ведений текст"
            };        

            btnGeneratingkeys.Click += (sender, e) =>
            {
                GeneratingKeys.OnGeneratingKeysClick(sender, e, txtGeneratingkeys.Text, out PrivatekeyTime, out PublickeyTime);
                lblPrivatekeyTime.Text = $"Час генерування приватного ключа: {PrivatekeyTime}";
                lblPublickeyTime.Text = $"Час генерування публічного ключа: {PublickeyTime}";
            };

            btnEncryptionText.Click += (sender, e) =>
            {
                EncryptionRSA.OnEncryptionTextClick(sender, e, txtTextSize.Text, out EncryptionTextTime);
                lblEncryptionTextTime.Text = $"Час за шифрування: {EncryptionTextTime}";
            };

            Controls.Add(btnGeneratingkeys);
            Controls.Add(btnEncryptionText);
            Controls.Add(txtTextSize);
            Controls.Add(txtGeneratingkeys);
            Controls.Add(lblPrivatekeyTime);
            Controls.Add(lblPublickeyTime);
            Controls.Add(lblEncryptionTextTime);

        }
    }
}