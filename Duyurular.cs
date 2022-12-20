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
using Microsoft.VisualBasic;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace visual_programming_final
{
    public partial class Duyurular : Form
    {

        Form1 form1;
        SqlConnection sqlCon = new SqlConnection();
        int nRowIndex;
        public Duyurular(Form1 form1)
        {

            InitializeComponent();
            this.form1 = form1;

            // tablonun ayarları
            dataGridView1.ClearSelection();
            
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Tarih";//Kolonların adı
            dataGridView1.Columns[1].Name = "Duyuru";

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  //hücre değil satır seçimi
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.FirstDisplayedScrollingRowIndex = nRowIndex;  //scroll
            try
            {
                ArrayList a = new ArrayList();
                a = sqlCon.Command_Reader("SELECT tarihDuyurular, Duyuru FROM duyurular");

                foreach (string item in a)
                {
                    string[] cols = new string[2];
                    cols = item.Split('-');
                    dataGridView1.Rows.Insert(0, cols[0], cols[1]);
                }

                nRowIndex = dataGridView1.Rows.Count - 2;
                dataGridView1.Rows[nRowIndex].Selected = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //giriş yapmış mı
            if (form1.giris && form1.Isogretmen)
            {
                pictureBox3.Visible = true;
                pictureBox2.Visible = true;
            }
            else
            {
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
            }

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

        
        public void duyuruEkle(string a, string b)
        {

            
            dataGridView1.Rows.Insert(0, a, b);
            
            sqlCon.Command_Nonq("INSERT INTO duyurular(tarihDuyurular,Duyuru) VALUES('" + a + "','" + b + "')");


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {


            try
            {
                string yeni_duyuru = Interaction.InputBox("Duyuru Girişi", "Duyurunuzu Giriniz.", "", 0, 0);
                string[] duyurularım = yeni_duyuru.Split('-');
                string tarih = duyurularım[0];
                tarih.Trim();
                string duyuru = duyurularım[1];
                duyuru.Trim();
                if (tarih == "-1" || duyuru == "-1")
                {
                    MessageBox.Show("HATA MEVCUT", "Tarihi veya Duyuruyu boş bırakamazsınız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    duyuruEkle(tarih, duyuru);
                }
            }
            catch (Exception)
            {


            }


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            //dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[nRowIndex].Index);




            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string cellValue = Convert.ToString(selectedRow.Cells["Duyuru"].Value);
                sqlCon.Command_Nonq("DELETE FROM duyurular WHERE (`duyuru` = '" + cellValue + "')");
                
                
                    dataGridView1.Rows.RemoveAt(selectedRow.Index);
                
            }


            
                    
                    


                
               /* else
                {
                    MessageBox.Show("BİR DUYURU SEÇİNİZ", "İşlem Başarısız !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
            
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(34, 28);

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(29, 21);

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            
        }


    }
}

