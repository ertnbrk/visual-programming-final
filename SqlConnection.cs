using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Security.Cryptography;

namespace visual_programming_final
{
    public partial class SqlConnection
    {
        
        
        
        
        public string myConnectionString = "server=127.0.0.1;uid=root;pwd=123456;database=gp-final";

       

        public ArrayList Command_Reader(string query)
        {
            ArrayList myArray = new ArrayList();
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                con.Open(); //connectionı buradaaçmayınca zaten reader açık hatası veriyor !!!
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int a = reader.FieldCount;
                        int i = 0;
                        while (reader.Read())
                        {

                            if(a == 2){
                                string myText = reader[0].ToString() + "-" + reader[1].ToString();
                                myArray.Add(myText);
                            }
                                
                            
                            
                            else if (a ==1)
                            {
                                string myText = reader[0].ToString();
                                myArray.Add(myText);
                                
                                 
                            }
                            else if (a ==3)
                            {
                                string myText = reader[0].ToString() + "-" + reader[1].ToString() + "-" + reader[2].ToString();
                                myArray.Add(myText);
                            }
                            else if (a == 4)
                            {
                                string myText = reader[0].ToString() + "-" + reader[1].ToString() + "-" + reader[2].ToString()+ "-" + reader[3];
                                myArray.Add(myText);
                            }
                            else if (a==5)
                            {
                                string myText = reader[0].ToString() + "." + reader[1].ToString() + "." + reader[2].ToString() + "." + reader[3].ToString()+ "."+ reader[4].ToString();
                                myArray.Add(myText);
                            }
                            else if (a == 6)
                            {
                                string myText = reader[0].ToString() + "." + reader[1].ToString() + "." + reader[2].ToString() + "." + reader[3].ToString() + "." + reader[4].ToString() + "." + reader[5].ToString();
                                myArray.Add(myText);
                            }
                            i++;
                            
                        }
                        
                    }
                }
            }
            return myArray;



        }
        
        public void Command_Nonq (string query)
        {
            using (MySqlConnection con = new MySqlConnection(myConnectionString))
            {
                con.Open(); //connectionı buradaaçmayınca zaten reader açık hatası veriyor !!!
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
