using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
namespace visual_programming_final
{
    
    public partial class YemekListesi : Form
    {
        Form1 form1;
        SqlConnection sqlCon = new SqlConnection();
        public YemekListesi(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            
        }

        private void YemekListesi_Load(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy-dd-MM");
                ArrayList a = new ArrayList();
                a = sqlCon.Command_Reader("SELECT * FROM yemeklistesi WHERE Tarih =\""+date+"\"");
                MessageBox.Show(date);
                foreach (string item in a)
                {
                    string[] cols = new string[5];
                    cols = item.Split('.');
                    MessageBox.Show(item);
                    label6.Text = cols[1];
                    label7.Text = cols[2];
                    label8.Text = cols[3];
                    label9.Text = cols[4];
                    


                }


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Close();
        }

        //pencere taşınılabilirliği
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
    }
}
