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
                notlar = conn.Command_Reader("SELECT idogrenci,dersAdi , notl FROM dersler INNER JOIN notlar ON dersler.idders = notlar.dersid");
                /*
                foreach (string item in notlar)
                {
                    string[] dizi = new string[3];
                    dizi = item.Split('-');

                    if (dizi[0] == anaekran.id)
                    {
                        listBox1.Items.Add(dizi[1] + " == " + dizi[2]);
                    }
                }
                */
                ArrayList a = new ArrayList();
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.ColumnCount = 2;
                dataGridView1.Columns[0].Name = "Ders";//Kolonların adı
                dataGridView1.Columns[1].Name = "Not";
                
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  //hücre değil satır seçimi
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[0].Width = 50;

                foreach (string item in notlar)
                {
                    string[] cols = new string[3];
                    
                    cols = item.Split('-');
                    dataGridView1.Rows.Insert(0, cols[1], cols[2]);
                    
                }

                


            }
            else
            {
                dataGridView1.Visible = false;
                comboBox1.Visible = true;
                comboBox1.Text = "BÖLÜMLER";
                ArrayList bolumler = new ArrayList();
                ArrayList clm = new ArrayList();
                bolumler = conn.Command_Reader("SELECT bolumad FROM bolumler");
                label1.Visible = true;
                foreach (string item in bolumler)
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
            listBox1.Items.Clear();
            
            ArrayList innerım = new ArrayList();
            
            innerım = conn.Command_Reader("SELECT bolumad,idogrenci,ogrenciAd,ogrenciSoy FROM bolumler INNER JOIN ogrenci ON bolumler.idbolumler = ogrenci.bolumid");

            
            foreach (string item in innerım)
            {
                string mitem = item.Substring(0, item.IndexOf('-'));
                if (comboBox1.Text == mitem)
                {
                    listBox1.Items.Add(item.Replace('-', ' '));
                }
            }
            label1.Text = "Öğrenci Sayısı => "+listBox1.Items.Count;
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
    }
}
