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
        private Button btnSignature;
        private Button btnChecklist;
        private Button OpenFormGT;
        private Button OpenFormM;
        private Button OpenFiletClickA;
        private Button OpenFiletClickS;
        private Label lblKeyTime;
        private Label lblSignatureTime;
        private Label lblChecklistTime;
        private Label lblmemoryInMegabytesKey;
        private Label lblmemoryInSignature;
        private Label lblmemoryInChecklist;

        Form5 f5;
        Form6 f6;

        private double memoryInMegabytesK = 0.0;
        private double memoryInSignature = 0.0;
        private double memoryInChecklist = 0.0;
        private string KeyTime = "";
        private string SignatureTime = "";
        private string ChecklistTime = "";
        private string fileKey = "";
        private string Checklists = "..\\..\\..\\Files\\Еlectronic_digital_signature_m.txt";

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
                Location = new Point(10, 40),
                Size = new Size(150, 45),
                Text = "Згенерувати пару ключів"
            };

            btnSignature = new Button
            {
                Location = new Point(160, 40),
                Size = new Size(150, 45),
                Text = "Підписати повідомлення"
            };

            btnChecklist = new Button
            {
                Location = new Point(310, 40),
                Size = new Size(150, 45),
                Text = "Перевірити електроний цифровий підпис"
            };

            lblKeyTime = new Label
            {
                Location = new Point(630, 15),
                AutoSize = true,
                Text = ""
            };

            lblmemoryInMegabytesKey = new Label
            {
                Location = new Point(1050, 15),
                AutoSize = true,
                Text = ""
            };

            lblSignatureTime = new Label
            {
                Location = new Point(630, 30),
                AutoSize = true,
                Text = ""
            };

            lblmemoryInSignature = new Label
            {
                Location = new Point(1050, 30),
                AutoSize = true,
                Text = ""
            };

            lblChecklistTime = new Label
            {
                Location = new Point(630, 45),
                AutoSize = true,
                Text = ""
            };

            lblmemoryInChecklist = new Label
            {
                Location = new Point(1050, 45),
                AutoSize = true,
                Text = ""
            };

            OpenFormGT = new Button
            {
                Location = new Point(630, 60),
                Size = new Size(150, 45),
                Text = "Відкрити графік часу"
            };

            OpenFormM = new Button
            {
                Location = new Point(1050, 60),
                Size = new Size(150, 45),
                Text = "Відкрити графік пам'яті"
            };

            OpenFiletClickA = new Button
            {
                Location = new Point(10, 100),
                Size = new Size(150, 45),
                Text = "Відкрити додаткову інформацію"
            };

            OpenFiletClickS = new Button
            {
                Location = new Point(160, 100),
                Size = new Size(150, 45),
                Text = "Відкрити підписане повідомлення"
            };

            btnGeneratingkeys.Click += (sender, e) =>
            {
                using (Process process = Process.GetCurrentProcess())
                {
                    int bitLength = int.Parse(txtGeneratingkeys.Text);

                    GeneratingKeysDigitalSignature.OnGeneratingKeysDigitalSignatureClick(sender, e, txtGeneratingkeys.Text, out KeyTime);
                    lblKeyTime.Text = $"Час генерування ключа: {KeyTime}";
                    memoryInMegabytesK = process.PrivateMemorySize64 / (1024 * 1024);

                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Memory\\Digital Signature\\Memory_" + bitLength + "_Digital_Signature_біт.txt"))
                    {
                        file.WriteLine("{0}", memoryInMegabytesK);
                    }
                }
                lblmemoryInMegabytesKey.Text = $"Використана оперативна пам'ять: {memoryInMegabytesK} МБ для генерування ключів";

                MessageBox.Show("Ключі успішно згенеровані.");
            };

            btnSignature.Click += (sender, e) =>
            {
                using (Process process = Process.GetCurrentProcess())
                {
                    int bitLength = int.Parse(txtGeneratingkeys.Text);

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileKey = openFileDialog.FileName;
                    }

                    Signature.OnSignatureClick(sender, e, txtTextSize.Text, out SignatureTime, fileKey, txtGeneratingkeys.Text);
                    lblSignatureTime.Text = $"Час підписання повідомлення: {SignatureTime}";
                    memoryInSignature = process.PrivateMemorySize64 / (1024 * 1024);

                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Memory\\Digital Signature\\Memory_" + bitLength + "_Signature_біт.txt"))
                    {
                        file.WriteLine("{0}", memoryInSignature);
                    }

                }
                lblmemoryInSignature.Text = $"Використана оперативна пам'ять: {memoryInSignature} МБ для підписання повідомлення";

                MessageBox.Show("Підписання повідомлення завершено.");
            };

            btnChecklist.Click += (sender, e) =>
            {
                using (Process process = Process.GetCurrentProcess())
                {
                    int bitLength = int.Parse(txtGeneratingkeys.Text);

                    Checklist.OnChecklistClick(sender, e, txtTextSize.Text, out ChecklistTime, Checklists, txtGeneratingkeys.Text);
                    lblChecklistTime.Text = $"Час перевірки електроного цифрового підпису: {ChecklistTime}";
                    memoryInChecklist = process.PrivateMemorySize64 / (1024 * 1024);

                    using (StreamWriter file = new StreamWriter("..\\..\\..\\Memory\\Digital Signature\\Memory_" + bitLength + "_Checklist_біт.txt"))
                    {
                        file.WriteLine("{0}", memoryInChecklist);
                    }
                }
                lblmemoryInChecklist.Text = $"Використана оперативна пам'ять: {memoryInChecklist} МБ для перевірки електроного цифрового підпису";
            };

            OpenFormGT.Click += (sender, e) =>
            {
                oHacToolStrip2_Click(sender, e, f5);
            };

            OpenFormM.Click += (sender, e) =>
            {
                oHacToolStrip3_Click(sender, e, f6);
            };

            OpenFiletClickA.Click += (sender, e) =>
            {
                OpenFile.OpenFiletClickDigitalSignature(sender, e);
            };

            OpenFiletClickS.Click += (sender, e) =>
            {
                OpenFile.OpenFiletClickSignature(sender, e);
            };

            lblmemoryInMegabytesKey.Text = $"Використана оперативна пам'ять: {memoryInMegabytesK} МБ для генерування ключів";
            lblKeyTime.Text = $"Час генерування ключа: {KeyTime}";
            lblmemoryInSignature.Text = $"Використана оперативна пам'ять: {memoryInSignature} МБ для підписання повідомлення";
            lblSignatureTime.Text = $"Час підписання повідомлення: {SignatureTime}";
            lblmemoryInChecklist.Text = $"Використана оперативна пам'ять: {memoryInChecklist} МБ для перевірки електроного цифрового підпису";
            lblChecklistTime.Text = $"Час перевірки електроного цифрового підпису: {ChecklistTime}";

            Controls.Add(txtTextSize);
            Controls.Add(txtGeneratingkeys);
            Controls.Add(btnGeneratingkeys);
            Controls.Add(btnSignature);
            Controls.Add(btnChecklist);
            Controls.Add(OpenFormGT);
            Controls.Add(OpenFormM);
            Controls.Add(OpenFiletClickA);
            Controls.Add(OpenFiletClickS);
            Controls.Add(lblKeyTime);
            Controls.Add(lblSignatureTime);
            Controls.Add(lblChecklistTime);
            Controls.Add(lblmemoryInMegabytesKey);
            Controls.Add(lblmemoryInSignature);
            Controls.Add(lblmemoryInChecklist);
        }

        private void oHacToolStrip2_Click(object sender, EventArgs e, Form f)
        {
            ReadingandWriting.PerformReadingAndWritingGKDigitalSignatureTime(sender, e);
            ReadingandWriting.PerformReadingAndWritingEDigitalSignatureTime(sender, e);
            ReadingandWriting.PerformReadingAndWritingDDigitalSignatureTime(sender, e);
            f = new Form5();
            f.Show();
        }

        private void oHacToolStrip3_Click(object sender, EventArgs e, Form f)
        {
            ReadingandWriting.PerformReadingAndWritingGKDigitalSignatureMemory(sender, e);
            ReadingandWriting.PerformReadingAndWritingEDigitalSignatureMemory(sender, e);
            ReadingandWriting.PerformReadingAndWritingDDigitalSignatureMemory(sender, e);
            f = new Form6();
            f.Show();
        }
    }
}