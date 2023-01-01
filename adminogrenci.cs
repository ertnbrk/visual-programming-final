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
    
    public partial class adminogrenci : Form
    {
        private Admin admin;
        SqlConnection sqlCon = new SqlConnection();
        public adminogrenci(Admin admin)
        {
            
            this.admin = admin;
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  //hücre değil satır seçimi
            dataGridView1.ReadOnly = true;
            loadData();
        }
        public void loadData()
        {
            try
            {
                ArrayList a = new ArrayList();
                ArrayList bolumler = new ArrayList();
                a = sqlCon.Command_Reader("SELECT idogrenci,ogrenciAd,ogrenciSoy,bolumad FROM ogrenci INNER JOIN bolumler ON ogrenci.bolumid = bolumler.idbolumler");
                bolumler = sqlCon.Command_Reader("SELECT idbolumler,bolumad FROM bolumler");

                if (a is null)
                {
                    MessageBox.Show("boş");
                }
                foreach (string item in a)
                {
                    string[] cols = new string[4];
                    cols = item.Split('-');
                    dataGridView1.Rows.Add(cols);

                }
                foreach (var item in bolumler)
                {
                    comboBox1.Items.Add(item);
                }


            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            admin.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != null && textBox3.Text != null && comboBox1.SelectedItem != null)
                {
                    string numara = "";
                    //Dzenle
                    Random rnd = new Random();
                    string randomsayi = "";
                    for (int i = 0; i < 5; i++)
                    {
                        randomsayi += rnd.Next(0, 9).ToString();
                    }
                    int randomsifre = rnd.Next(1000, 9999);
                    DateTime now = DateTime.Now;
                    Object bolum = comboBox1.SelectedItem;
                    int bolumid = Convert.ToInt32(bolum.ToString().Substring(0, bolum.ToString().IndexOf('-')));

                    if (bolumid > 9)
                    {
                        numara = now.Date.Year + bolum.ToString().Substring(0, bolum.ToString().IndexOf('-')) + randomsayi;
                        MessageBox.Show(numara);
                    }
                    else
                    {
                        numara = now.Date.Year + "0" + bolum.ToString().Substring(0, bolum.ToString().IndexOf('-')) + randomsayi;
                        MessageBox.Show(numara);
                    }

                    //int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    if (dataGridView1.SelectedCells.Count > 0)
                    {
                        int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                        string numaras = Convert.ToString(selectedRow.Cells["Column4"].Value);    //Sutunu bulamıyor nedense ayıkamadım

                        try
                        {
                            sqlCon.Command_Nonq("UPDATE ogrenci SET idogrenci = '" + numara + "' ,ogrenciAd ='" + textBox2.Text.ToString() + "', ogrenciSoy ='" + textBox3.Text.ToString() + "', bolumid = '" + bolumid + "', sifre='" + randomsifre + "' WHERE idogrenci ='" + numaras + "'");
                            dataGridView1.Rows.Clear();
                            comboBox1.Items.Clear();
                            loadData();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bir Satır Seç");
                    }
                }
                else
                {
                    MessageBox.Show("Girdiler boş bırakılamaz");
                }
            
                
            }
            catch (Exception)
            {

                MessageBox.Show("Girdilerinizin doğru olduğundan emin olun");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null && textBox3.Text != null && comboBox1.SelectedItem != null)
            {
                string numara;
                Random rnd = new Random();
                string randomsayi = "";
                for (int i = 0; i < 5; i++)
                {
                    randomsayi += rnd.Next(0, 9).ToString();
                }
                DateTime now = DateTime.Now;
                Object bolum = comboBox1.SelectedItem;
                string bolumAD = bolum.ToString().Substring(bolum.ToString().IndexOf('-'));
                int bolumid = Convert.ToInt32(bolum.ToString().Substring(0, bolum.ToString().IndexOf('-')));
                if (bolumid > 9)
                {
                    numara = now.Date.Year + bolum.ToString().Substring(0, bolum.ToString().IndexOf('-')) + randomsayi;
                    MessageBox.Show(numara);
                }
                else
                {
                    numara = now.Date.Year + "0" + bolum.ToString().Substring(0, bolum.ToString().IndexOf('-')) + randomsayi;
                    MessageBox.Show(numara);
                }
                try
                {
                    sqlCon.Command_Nonq("INSERT INTO `ogrenci` (`idogrenci`, `ogrenciAd`, `ogrenciSoy`, `bolumid`) VALUES('" + numara + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + bolumid + "')");
                    dataGridView1.Rows.Insert(0, numara, textBox2.Text, textBox3.Text, bolumAD);
                    dataGridView1.Rows.Clear();
                    comboBox1.Items.Clear();
                    loadData();
                }
                catch (Exception exception)
                {

                    MessageBox.Show("Bir hata meydana geldi lütfen Tekrar Deneyiniz\n" + exception);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //sil
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string numaras = Convert.ToString(selectedRow.Cells["Column4"].Value);    
                
                try
                {
                    sqlCon.Command_Nonq("DELETE FROM ogrenci WHERE idogrenci='" + numaras + "'");
                    dataGridView1.Rows.Clear();
                    comboBox1.Items.Clear();
                    loadData();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error!");
                }
            }
            else
            {
                MessageBox.Show("Bir Satır Seç");
            }
        }
    }
}
