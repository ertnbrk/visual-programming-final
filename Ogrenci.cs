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
    public partial class Ogrenci : Form
    {
        Form1 anaekran;
        public Ogrenci(Form1 form1)
        {
            SqlConnection conn = new SqlConnection();
            InitializeComponent();
            this.anaekran = form1;
            if (form1.Isogrenci)
            {
                ArrayList notlar = new ArrayList();
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                notlar = conn.Command_Reader("SELECT idogrenci,dersAdi , notl FROM dersler INNER JOIN notlar ON dersler.idders = notlar.dersid WHERE idogrenci = "+form1.id+";");
                dataGridView2.Visible = false;
                ArrayList a = new ArrayList();
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Ders";//Kolonların adı
                dataGridView1.Columns[1].Name = "Not";
                dataGridView1.Columns[2].Name = "HARF";
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  //hücre değil satır seçimi
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[0].Width = 128;
                dataGridView1.Columns[2].Width = 50;
                int derece = 0;
                int not = 0;
                string harfNotu = "";
                foreach (string item in notlar)
                {
                    string[] cols = new string[3];
                    
                    cols = item.Split('-');
                    not = Convert.ToInt32(cols[2]);

                    if (not <101 && not >84)
                    {
                        harfNotu = "AA";
                        
                    }
                    else if (not <85 && not >69)
                    {
                        harfNotu = "BA";
                    }
                    else if (not <70 && not > 49)
                    {
                        harfNotu = "BB";
                    }
                    else if (not <50 && not >20)
                    {
                        harfNotu = "CB";
                    }
                    else
                    {
                        harfNotu = "CC";
                    }

                    dataGridView1.Rows.Insert(0, cols[1], cols[2],harfNotu);
                    
                }
                

                


            }
            else
            {
                comboBox2.Visible = true;
                dataGridView2.Visible = true;
                dataGridView1.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Text = "DERSLER";
                ArrayList ders = new ArrayList();
                ArrayList bolum = new ArrayList();
                bolum = conn.Command_Reader("SELECT bolumad FROM bolumler");
                ders = conn.Command_Reader("SELECT dersAdi FROM dersler");
                label1.Visible = true;
                foreach (string item in bolum)
                {
                    comboBox2.Items.Add(item);
                }
                foreach (string item in ders)
                {

                    comboBox1.Items.Add(item);
                }
            }
            
        }
        
        
        private void Form2_Load(object sender, EventArgs e)
        {
            

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
            anaekran.Show();
            this.Hide();
        }
        SqlConnection conn = new SqlConnection();
        ArrayList myArray = new ArrayList();
        
        
    
        private void button3_Click(object sender, EventArgs e)
        {
            int notkiyas = 0;
            int ortalama = 0;
            ArrayList notlar = new ArrayList();

            notlar = conn.Command_Reader("SELECT notl FROM notlar INNER JOIN dersler ON notlar.dersid = dersler.idders WHERE dersAdi = '"+comboBox1.SelectedItem.ToString()+"'; ");
            
            
            foreach (string item in notlar)
            {
                //string mitem = item.Substring(0, item.IndexOf('-'));
               notkiyas  = notkiyas + Convert.ToInt32(item);
            }
            if (notlar.Count >0)
            {
               ortalama = notkiyas / notlar.Count;
                
                    if (ortalama > 80)
                    {
                        conn.Command_Nonq("UPDATE dersler SET Kredi = Kredi - 1, krediKirilma = 1 WHERE dersAdi = '" + comboBox1.SelectedItem.ToString() + "' AND Kredi >2; ");
                        
                    }
                
                
            }
 
            label1.Text = "Not ortalaması  => "+ ortalama;

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            anaekran.Show();
            this.Close();
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(34, 28);

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(29, 21);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            ArrayList ogrencibolum = new ArrayList();
            ogrencibolum = conn.Command_Reader("SELECT idogrenci,ogrenciAd,ogrenciSoy FROM `gp-final`.ogrenci INNER JOIN `gp-final`.bolumler ON ogrenci.bolumid = bolumler.idbolumler WHERE bolumad = '"+comboBox2.SelectedItem.ToString()+"';");
            foreach (string item in ogrencibolum)
            {
                string[] rows = new string[3];
                rows = item.ToString().Split('-');
                dataGridView2.Rows.Add(rows);
            }
            label1.Text = "Öğrenci Sayısı => " + (dataGridView2.Rows.Count-1).ToString();
            label1.Visible = true;
        }
    }
}
