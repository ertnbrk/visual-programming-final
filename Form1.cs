using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.VisualBasic;
namespace visual_programming_final
{

    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            pictureBox8.Visible = false;
            pictureBox12.Visible = false;
        }

        public Ogrenci ogrenci;
        public üyeGirisi üye;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Isogrenci || Isogretmen)
            {
                ogrenci = new Ogrenci(this);
                ogrenci.Show();
                this.Hide();
            }
            else
            {
                üye = new üyeGirisi(this);
                üye.Show();
                this.Hide();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Isogretmen)
            {
                pictureBox2.Enabled = true;
                OgretimGörevlisi ogretmen = new OgretimGörevlisi(this);
                ogretmen.Show();
                this.Hide();
            }

            else
            {

                üye = new üyeGirisi(this);
                üye.Show();
                this.Hide();
            }
            
        }

        
        
        public bool giris = false;
        public string isim = "";
        public string id = "";
        public string Soy = "";
        public bool Isogrenci = false;
        public bool Isogretmen = false;
        private void button7_Click(object sender, EventArgs e)
        {
            if (giris)
            {

                DialogResult a = new DialogResult();
                a = MessageBox.Show("Çıkış Yapmak İstiyor musunuz", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {

                    pictureBox8.Visible = false;
                    pictureBox6.Visible = true;
                    giris = false;
                    Isogrenci = false;
                    Isogretmen = false;


                }
                else
                {

                }



            }

            else
            {
                üye = new üyeGirisi(this);
                this.Hide();
                üye.Show();

            }

        }



        private static int UyeHali()
        {

            return 0;
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SosyalMedya medya = new SosyalMedya(this);
            medya.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sinavSorgu sinav = new sinavSorgu(this);
            sinav.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Duyurular duyurular = new Duyurular(this);
            duyurular.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Isogrenci || Isogretmen)
            {
                ogrenci = new Ogrenci(this);
                ogrenci.Show();
                this.Hide();
            }
            else
            {
                üye = new üyeGirisi(this);
                üye.Show();
                this.Hide();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            HaberlerTakvim haber = new HaberlerTakvim(this);
            haber.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (Isogretmen)
            {
                pictureBox2.Enabled = true;
                OgretimGörevlisi ogretmen = new OgretimGörevlisi(this);
                ogretmen.Show();
                this.Hide();
            }

            else
            {

                üye = new üyeGirisi(this);
                üye.Show();
                this.Hide();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (giris)
            {

                DialogResult a = new DialogResult();
                a = MessageBox.Show("Çıkış Yapmak İstiyor musunuz", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (a == DialogResult.Yes)
                {

                    pictureBox8.Visible = false;
                    pictureBox6.Visible = true;
                    giris = false;
                    Isogrenci = false;
                    Isogretmen = false;
                    isAdmin = false;
                    pictureBox12.Visible = false;

                }
                else
                {

                }



            }

            else
            {
                üye = new üyeGirisi(this);
                this.Hide();
                üye.Show();

            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox9.Size = new Size(42, 36);
            
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.Size = new Size(50, 45);
        }
        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            pictureBox10.Size = new Size(58, 48);

        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            pictureBox10.Size = new Size(50, 42);
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(63, 58);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Size = new Size(50, 45);
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(63, 58);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(50, 45);
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(63, 58);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Size = new Size(50, 45);
        }
        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(63, 58);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Size = new Size(50, 45);
        }
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(63, 58);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Size = new Size(50, 45);
        }
        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            pictureBox7.Size = new Size(63, 58);
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Size = new Size(50, 45);
        }
        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            pictureBox6.Size = new Size(44, 40);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Size = new Size(40, 38);
        }
        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.Size = new Size(44, 40);
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Size = new Size(40, 38);
        }
        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            pictureBox11.Size = new Size(55, 50);
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            pictureBox11.Size = new Size(48, 45);
        }
        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            pictureBox12.Size = new Size(55, 50);
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            pictureBox12.Size = new Size(48, 45);
        }



        private void pictureBox10_Click(object sender, EventArgs e)
        {
            havaDurumu havaDurumu = new havaDurumu(this);
            try
            {
                havaDurumu.Show();
                this.Hide();
            }
            catch (Exception)
            {

                
            }
            
        }
        public bool isAdmin = false;

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            YemekListesi yemeklistesi = new YemekListesi(this);

            this.Hide();
            yemeklistesi.Show();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin(this);
            admin.Show();
            this.Hide();
        }
    }
}
