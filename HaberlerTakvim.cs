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
    public partial class HaberlerTakvim : Form
    {
        Form1 form1;
        public HaberlerTakvim(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
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
        private void button2_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Close();
        }

        private void HaberlerTakvim_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile("C:\\Users\\Administrator\\Documents\\Code\\c#\\visual-programming-final\\bin\\akademik.pdf");
            
            
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(34, 28);

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(29, 21);

        }

        private void axAcroPDF1_Enter(object sender, EventArgs e)
        {

        }
    }
}
