using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practical_Part_of_the_Diploma
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeFormElements();

            Icon = new Icon("..\\..\\..\\Icon\\Encryption.ico");
        }

        private PictureBox pictureBoxImage;

        private string image = "..\\..\\..\\Icon\\RSA.jpg";

        private void InitializeFormElements()
        {
            this.Size = new Size(1280, 640);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "RSA";
            this.BackColor = Color.White;
            this.ControlBox = false;

            pictureBoxImage = new PictureBox()
            {
                Location = new Point(-10, 0), 
                Size = new Size(1280, 640),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Image.FromFile(image)
            };

            Controls.Add(pictureBoxImage);
        }
    }
}
