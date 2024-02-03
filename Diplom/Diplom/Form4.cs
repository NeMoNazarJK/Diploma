using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Diplom.RSA;

namespace Diplom
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeFormElements();

            Icon = new Icon("..\\..\\..\\Icon\\Digital Signature.ico");
        }

        private TextBox txtTextSize;
        private TextBox txtGeneratingkeys;
        private Button btnGeneratingkeys;
        private Label lblKeyTime;
        private Label lblmemoryInMegabytesKey;

        private double memoryInMegabytesK = 0.0;
        private string KeyTime = "";

        private void InitializeFormElements()
        {
            this.Size = new Size(1920, 1080);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA Digital Signature";
            this.WindowState = FormWindowState.Maximized;
            
            txtTextSize = new TextBox
            {
                Location = new Point(10, 10),
                Size = new Size(430, 150),
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

            lblKeyTime = new Label
            {
                Location = new Point(630, 15),
                AutoSize = true,
                Text = ""
            };

            lblmemoryInMegabytesKey = new Label
            {
                Location = new Point(945, 15),
                AutoSize = true,
                Text = ""
            };

            btnGeneratingkeys.Click += (sender, e) =>
            {
                using (Process process = Process.GetCurrentProcess())
                {
                    int bitLength = int.Parse(txtGeneratingkeys.Text);

                    GeneratingKeysDigitalSignature.OnGeneratingKeysDigitalSignatureClick(sender, e, txtGeneratingkeys.Text, out KeyTime);
                    lblKeyTime.Text = $"Час генерування приватного ключа: {KeyTime}";
                    memoryInMegabytesK = process.PrivateMemorySize64 / (1024 * 1024);

                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Memory\\Memory_Key_" + bitLength + "_Digital_Signature_біт.txt"))
                    {
                        file.WriteLine("{0}", memoryInMegabytesK);
                    }
                }
                lblmemoryInMegabytesKey.Text = $"Використана оперативна пам'ять: {memoryInMegabytesK} МБ для генерування ключів";

                MessageBox.Show("Ключі успішно згенеровані.");
            };

            lblmemoryInMegabytesKey.Text = $"Використана оперативна пам'ять: {memoryInMegabytesK} МБ для генерування ключів";
            lblKeyTime.Text = $"Час генерування приватного ключа: {KeyTime}";

            Controls.Add(txtTextSize);
            Controls.Add(txtGeneratingkeys);
            Controls.Add(btnGeneratingkeys);
            Controls.Add(lblKeyTime);
            Controls.Add(lblmemoryInMegabytesKey);
        }
    }
}