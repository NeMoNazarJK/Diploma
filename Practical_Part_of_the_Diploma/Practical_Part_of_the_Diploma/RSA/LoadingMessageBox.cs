using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practical_Part_of_the_Diploma.RSA
{
    internal class LoadingMessageBox
    {
        public static Form ShowLoadingMessageBox(string message, string loadingPath)
        {
            var loadingForm = new Form();
            loadingForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            loadingForm.MaximizeBox = false;
            loadingForm.MinimizeBox = false;
            loadingForm.StartPosition = FormStartPosition.CenterScreen;
            loadingForm.Size = new Size(300, 250);
            loadingForm.ControlBox = false;

            var pictureBoxLoading = new PictureBox
            {
                Image = Image.FromFile(loadingPath),
                SizeMode = PictureBoxSizeMode.CenterImage,
                Dock = DockStyle.Fill
            };

            var labelMessage = new Label
            {
                Text = message,
                Size = new Size(150, 30),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Font = new Font("Comic Sans MS", 12, FontStyle.Bold | FontStyle.Italic)
            };

            loadingForm.Controls.Add(pictureBoxLoading);
            loadingForm.Controls.Add(labelMessage);

            return loadingForm;
        }
    }
}