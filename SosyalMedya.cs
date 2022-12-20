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
    public partial class SosyalMedya : Form
    {
        Form1 form1;
        public SosyalMedya(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
            
        }
        bool move;
        int mouse_x;
        int mouse_y;
        private void Form1_MouseUp(object sender, MouseEventArgs e)
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

        

        private void button5_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        
        
        

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(55,53);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(60,57);
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(60, 57);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(55, 53);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(60, 57);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(55, 53);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/");
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(34, 28);

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(29,21);

        }
    }
}