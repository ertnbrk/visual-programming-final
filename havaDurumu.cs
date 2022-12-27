using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace visual_programming_final
{
    public partial class havaDurumu : Form
    {
        private Form1 anaekran;
        public havaDurumu(Form1 anaekran)
        {
            InitializeComponent();
            this.anaekran = anaekran;
            try
            {



                string api = "https://api.openweathermap.org/data/2.5/weather?q=kutahya&mode=xml&lang=tr&units=metric&appid=db7f4ec51c364d79ec191ce0a7c5e391";
                XDocument weather = XDocument.Load(api);
                var derece = weather.Descendants("temperature").ElementAt(0).Attribute("value").Value;
                var durum = weather.Descendants("weather").ElementAt(0).Attribute("value").Value;
                var ruzgar = weather.Descendants("speed").ElementAt(0).Attribute("value").Value;
                var nem = weather.Descendants("humidity").ElementAt(0).Attribute("value").Value;
                var hissedilen = weather.Descendants("feels_like").ElementAt(0).Attribute("value").Value;

                label6.Text = derece;
                label7.Text = ruzgar;
                label8.Text = durum;
                label9.Text = hissedilen;
                label10.Text = nem;
            }
            catch (Exception)
            {

                MessageBox.Show("İnternet Bağlantınız olduğuna emin olun");
                anaekran.Show();
                this.Close();

            }
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            anaekran.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
