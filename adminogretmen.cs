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
    
    public partial class adminogretmen : Form
    {
        SqlConnection sqlCon = new SqlConnection();
        private Admin admin;
        public adminogretmen(Admin admin)
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
                a = sqlCon.Command_Reader("SELECT idOgretmen,ogretmencol,ogretmenSoy,bolumad,Admin,sifre FROM ogretmen INNER JOIN bolumler ON ogretmen.bolumid = bolumler.idbolumler");
                bolumler = sqlCon.Command_Reader("SELECT idbolumler,bolumad FROM bolumler");

                if (a is null)
                {
                    MessageBox.Show("boş");
                }
                foreach (string item in a)
                {
                    string[] cols = new string[6];
                    cols = item.Split('.');
                    dataGridView1.Rows.Add(cols);

                }
                comboBox2.Items.Add("Admin");
                comboBox2.Items.Add("Üye");

                comboBox2.SelectedIndex = 1;
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
        private void button1_Click(object sender, EventArgs e)
        {
            //EKLE
            if (textBox2.Text != null || textBox3.Text != null || comboBox1.SelectedItem != null || comboBox2.SelectedItem != null)
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
            Object adminmi = comboBox2.SelectedItem;




            int randomsifre = rnd.Next(1000, 9999);
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
                sqlCon.Command_Nonq("INSERT INTO `ogretmen` (idOgretmen,ogretmencol,ogretmenSoy,bolumid,Admin,sifre) VALUES('" + numara + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + bolumid + "','"+adminmi+"','"+randomsifre+"')");

                dataGridView1.Rows.Clear();
                comboBox1.Items.Clear();
                loadData();
            }
            catch (Exception exception)
            {

                MessageBox.Show("Bir hata meydana geldi lütfen Tekrar Deneyiniz\n" + exception);
            }
            }
            else
            {
                MessageBox.Show("Alanlar boş bırakılamaz");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            admin.Show();
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null || textBox3.Text != null || comboBox1.SelectedItem != null || comboBox2.SelectedItem != null)
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
                    string numaras = Convert.ToString(selectedRow.Cells["Column1"].Value);    //Sutunu bulamıyor nedense ayıkamadım
                    Object adminmi = comboBox2.SelectedItem;
                    try
                    {
                        sqlCon.Command_Nonq("UPDATE ogretmen SET ogretmencol = '" + textBox2.Text.ToString() + "' ,ogretmenSoy ='" + textBox3.Text.ToString() + "', bolumid ='" + bolumid + "', Admin = '" + adminmi + "', sifre='" + randomsifre + "' WHERE idOgretmen ='" + numaras + "'");
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
                MessageBox.Show("Alanlar boş bırakılamaz");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string numaras = Convert.ToString(selectedRow.Cells["Column1"].Value);    //Sutunu bulamıyor nedense ayıkamadım
                Object adminmi = comboBox2.SelectedItem;
                try
                {
                    sqlCon.Command_Nonq("DELETE FROM ogretmen WHERE idOgretmen='"+ numaras + "'");
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

