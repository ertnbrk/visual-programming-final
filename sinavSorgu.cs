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
    public partial class sinavSorgu : Form
    {
        Form1 form1;
        public sinavSorgu(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            if (form1.giris)
            {
                textBox1.Text = form1.id;
                listele();

            }
            else
            {
                textBox1.Text = "Öğrenci Numarası";
            }
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Ders Adı";//Kolonların adı belirleniyor
            dataGridView1.Columns[1].Name = "Sınıf";
            dataGridView1.Columns[2].Name = "Saat";
            dataGridView1.Columns[3].Name = "Tarih";
            
            dataGridView1.Columns[1].Width = 30;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 60;
            
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
        SqlConnection conn = new SqlConnection();
        private void button2_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            
            dataGridView1.Rows.Clear();
            listele();
            



        }

        


        private void listele()
        {
            ArrayList Sinavid = new ArrayList();
            ArrayList ogrenciSin = new ArrayList();
            Sinavid = conn.Command_Reader("SELECT * from sinavlar");
            ogrenciSin = conn.Command_Reader("SELECT idogrenci,ogrenciAd,ogrenciSoy FROM ogrenci");
            
            foreach (string item in Sinavid)
            {

                string mitem = item.Substring(0, item.IndexOf('-'));
                string[] dizim = new string[3];
                dizim = item.Split('-');
                if (mitem == textBox1.Text)
                {
                    if (label1.Text == "")
                    {

                        foreach (string a in ogrenciSin)
                        {
                            string mitema = a.Substring(0, a.IndexOf('-'));
                            if (mitema == mitem)
                            {
                                
                                label1.Text = a.Substring(a.IndexOf('-') + 1).Replace('-', ' ');
                                break;
                            }
                        }
                    }
                    dataGridView1.Rows.Add(dizim[1], dizim[2], dizim[3]);
                    
                }
            }
        }

        private void sinavSorgu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(34, 28);

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(29, 21);

        }
    }
}
