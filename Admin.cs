using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visual_programming_final
{
    
    public partial class Admin : Form
    {
        Form1 anekran;
        public Admin(Form1 anekran)
        {
            InitializeComponent();
            this.anekran = anekran;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            adminogrenci ogrenci = new adminogrenci(this);
            this.Hide();
            ogrenci.Show();
        }

       

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            adminogretmen ogretmen = new adminogretmen(this);
            ogretmen.Show();
            this.Hide();
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(34, 28);

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(29, 21);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            anekran.Show();

            this.Close();
        }
        bool move;
        int mouse_x;
        int mouse_y;
        public void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }
    }
}
