using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.IO;

namespace knopka
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void insertData()
        {
            string conStr = "server=" + textBox2.Text + ";user=" + textBox3.Text +
";database=" + textBox5.Text + ";password =" + textBox4.Text;

            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    string sql = "INSERT INTO friendf (name, lastname, age)" +
                                 "VALUES (@Name, @LastName, @Age);";

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //создаем параметры и добавляем их в коллекцию
                    
                    cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@LastName", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@Age", 18);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные добавлены!");

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            insertData();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
