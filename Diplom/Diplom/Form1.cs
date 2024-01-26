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
        private TextBox txtFilterSize;

        private void InitializeFormElements()
        {
            this.Size = new Size(1920, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA";

            btnGeneratingkeys = new Button
            {
                Location = new Point(500, 10),
                Size = new Size(180, 22),
                Text = "Згенерувати пару ключів"
            };

            txtFilterSize = new TextBox
            {
                Location = new Point(10, 10),
                Size = new Size(400, 400),
                Text = ""
            };

            Controls.Add(btnGeneratingkeys);
            Controls.Add(txtFilterSize);

        }
    }
}