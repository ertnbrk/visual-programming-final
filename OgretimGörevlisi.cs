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
    public partial class OgretimGörevlisi : Form
    {
        SqlConnection conn = new SqlConnection();
        Form1 form1;
        public OgretimGörevlisi(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;



            comboBox2.Text = "Öğrenciler";
            comboBox1.Text = "Dersler";
            ArrayList dersler = new ArrayList();
           
            
            dersler = conn.Command_Reader("SELECT ogretmenid,dersAdi FROM verdiders INNER JOIN dersler ON verdiders.idders = dersler.idders");
           
            //Combobox1 dersler
            foreach (string item in dersler)
            {
                string[] dizi = new string[2];
                dizi = item.Split('-');

                if (form1.id.ToString() == dizi[0])
                {
                    comboBox1.Items.Add(dizi[1].ToString());
                }
            }
            //combobx2 ögrenciler

            





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

        string dersid;
        private void button1_Click(object sender, EventArgs e)
        {
            

            ArrayList ogrenciler = new ArrayList();
            ogrenciler = conn.Command_Reader("SELECT ogrencino,ogrenciAd,dersAdi,idders FROM (aldigiders INNER JOIN dersler ON aldigiders.dersid = dersler.idders) INNER JOIN ogrenci ON ogrenci.idogrenci = aldigiders.ogrencino;");
            
            foreach (string item in ogrenciler)
            {
                string[] dizi = new string[4];

                dizi = item.Split('-');
                
                if (dizi[2] == comboBox1.Text)
                {
                    Console.WriteLine(dizi[2].ToString());
                    comboBox2.Items.Add(dizi[0] + "-" + dizi[1]);
                    dersid = dizi[3];

                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }
        string selected;
        public void getir()
        {
            listBox1.Items.Clear();
            ArrayList notlar = new ArrayList();

            notlar = conn.Command_Reader("SELECT idogrenci,dersAdi , notl FROM dersler INNER JOIN notlar ON dersler.idders = notlar.dersid");
            selected = comboBox2.Text;
            selected = selected.Substring(0, selected.IndexOf('-'));
            foreach (string s in notlar)
            {
                string[] dizia = new string[3];
                dizia = s.Split('-');

                if (dizia[0] == selected && dizia[1] == comboBox1.Text)
                {
                    listBox1.Items.Add(dizia[1] + " == " + dizia[2]);
                }
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            getir();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Tamsayı bir değer giriniz");
            }
            else if (Convert.ToInt16(textBox1.Text)>100 || Convert.ToInt16(textBox1.Text)<0)
            {
                MessageBox.Show("Değer Aralığı Hatalı");
            }
            else
            {
                
                conn.Command_Nonq("UPDATE notlar SET notl ="+Convert.ToInt16(textBox1.Text)+" WHERE idogrenci ='"+selected+"' AND dersid = '"+dersid+"'");
                listBox1.Items.Clear();
                getir();
            }
            
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
