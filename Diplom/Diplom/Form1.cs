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

        private Button btnOpenImage;
        private TextBox txtFilterSize;

        private void InitializeFormElements()
        {
            this.Size = new Size(1920, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA";          

            btnOpenImage = new Button
            {
                Location = new Point(1000, 1000),
                Size = new Size(150, 30),
                Text = ""
            };

            txtFilterSize = new TextBox
            {
                Location = new Point(10, 10),
                Size = new Size(400, 400),
                Text = "3"
            };

            Controls.Add(btnOpenImage);
            Controls.Add(txtFilterSize);

        }
    }
}