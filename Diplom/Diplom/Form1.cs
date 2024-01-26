using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Diplom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeFormElements();
        }

        private Button btnGeneratingkeys;
        private TextBox txtTextSize;
        private TextBox txtGeneratingkeys;
        private Label lblPrivatekeyTime;
        private Label lblPublickeyTime;

        private string PrivatekeyTime;
        private string PublickeyTime;

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
                Size = new Size(400, 400),
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

            btnGeneratingkeys.Click += (sender, e) =>
            {
                RSA.OnGeneratingKeysClick(sender, e, txtGeneratingkeys.Text, PrivatekeyTime, PublickeyTime);
                lblPrivatekeyTime.Text = $"Час генерування приватного ключа: {PrivatekeyTime}";
                lblPublickeyTime.Text = $"Час генерування публічного ключа: {PublickeyTime}";
            };

            Controls.Add(btnGeneratingkeys);
            Controls.Add(txtTextSize);
            Controls.Add(txtGeneratingkeys);
            Controls.Add(lblPrivatekeyTime);
            Controls.Add(lblPublickeyTime);

        }
    }
}