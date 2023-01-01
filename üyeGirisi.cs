using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
namespace visual_programming_final
{
    public partial class üyeGirisi : Form
    {
        
        Form1 form1;
        public üyeGirisi(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }

        

        private void üyeGirisi_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;

        }
       SqlConnection conn = new SqlConnection();
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Close();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ArrayList ogrencilerid = new ArrayList();
            ArrayList ogrenciler = new ArrayList();
            ArrayList ogrenci_sy = new ArrayList();
            ArrayList isAdmins = new ArrayList();
            ArrayList ogrenciad = new ArrayList();
            if (radioButton1.Checked)
            {
                //Öğrenci

                ogrencilerid = conn.Command_Reader("SELECT idogrenci FROM ogrenci");
                
                ogrenci_sy = conn.Command_Reader("SELECT ogrenciSoy from ogrenci");
                ogrenciad = conn.Command_Reader("SELECT ogrenciAd from ogrenci");

                for (int i = 0; i < ogrencilerid.Count; i++)
                {
                    if (ogrencilerid[i].ToString() == textBox1.Text)
                    {
                        ogrenciler = conn.Command_Reader("SELECT sifre FROM ogrenci WHERE idogrenci =" + ogrencilerid[i] +"");
                        if (textBox2.Text.ToString() == ogrenciler[0].ToString())
                        {
                            MessageBox.Show("Giriş Yapıldı");

                            form1.pictureBox8.Visible = true;
                            form1.pictureBox6.Visible = false;
                            form1.giris = true;
                            form1.Isogrenci = true;
                            form1.isim = ogrenciad[i].ToString();
                            form1.id = ogrencilerid[i].ToString();
                            form1.Soy = ogrenci_sy[i].ToString();
                            form1.Show();
                            this.Close();
                            break;
                        }
                        
                    }
                   


                }






            }
            else
            {
                //Öğretmen

                ogrencilerid = conn.Command_Reader("SELECT idOgretmen FROM ogretmen");
                ogrenciler = conn.Command_Reader("SELECT sifre FROM ogretmen");
                isAdmins = conn.Command_Reader("SELECT Admin FROM ogretmen");



                for (int i = 0; i < ogrencilerid.Count; i++)
                {
                    if (ogrencilerid[i].ToString() == textBox1.Text && ogrenciler[i].ToString() == textBox2.Text)
                    {
                        if (isAdmins[i].ToString() == "Admin")
                        {
                            form1.pictureBox12.Visible = true;
                        }
                        MessageBox.Show("Giriş Yapıldı");
                        form1.Show();
                        form1.pictureBox8.Visible = true;
                        form1.pictureBox6.Visible = false;
                        form1.giris = true;
                        form1.Isogretmen = true;
                        form1.id = ogrencilerid[i].ToString();
                        this.Close();
                        break;
                    }
                    else if (i + 1 == ogrencilerid.Count)
                    {
                        MessageBox.Show("Giriş Başarısız");
                    }
                }
            }
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            
            pictureBox2.Size = new Size(70,58);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(68,55);
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
