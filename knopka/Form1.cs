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
using System.Globalization;



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
            string conStr = "server=" + textBox1.Text + ";user=" + textBox3.Text +
";database=" + textBox2.Text + ";password =" + textBox4.Text;
            string fileVar1 = File.ReadLines("1.txt").Skip(0).First();
            string fileVar2 = File.ReadLines("1.txt").Skip(1).First();

            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    string sql = "INSERT INTO wp_posts (post_author, post_date, post_date_gmt, post_content, post_title, post_excerpt, post_status, comment_status, ping_status, post_password, post_name, to_ping, pinged, post_modified, post_modified_gmt, post_content_filtered, post_parent, guid, menu_order, post_type, post_mime_type, comment_count)" +
                                 "VALUES (1,@date,@date, @Content, @Title,'', 'publish', 'open', 'open','', @Postname,'','',@date,@date,'','0','','0','post','','');";
                    //(777, 1, '2016-03-26 00:39:53', '2016-03-26 00:39:53', 'SHIT SHIT SHIT', 'SHIT TESTING', '', 'publish', 'open', 'open', '', 'shit-test', '', '', '2016-03-26 00:39:53', '2016-03-26 00:39:53', '', 0, 'http://pdfdata.org/?p=777', 0, 'post', '', 0);

                    con.Open();

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //создаем параметры и добавляем их в коллекцию
                    
                    cmd.Parameters.AddWithValue("@Title", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Content", richTextBox1.Text);
                    cmd.Parameters.AddWithValue("@Postname", textBox6.Text);
                    // cmd.Parameters.AddWithValue("@Age", 18);
                    string dateTime2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    cmd.Parameters.AddWithValue("@date", dateTime2);



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные добавлены!");

                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private DataTable GetComments()
        {
            DataTable dt = new DataTable();

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = textBox1.Text;
            mysqlCSB.Database = textBox2.Text;
            mysqlCSB.UserID = textBox3.Text;
            mysqlCSB.Password = textBox4.Text;

            string queryString = @"SELECT slug FROM wp_terms WHERE term_id IN (SELECT term_id FROM wp_term_taxonomy WHERE taxonomy='post_tag')";

            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;

                MySqlCommand com = new MySqlCommand(queryString, con);

                try
                {
                    con.Open();

                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dt;
        }

        private DataTable GetCats()
        {
            DataTable dt = new DataTable();

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = textBox1.Text;
            mysqlCSB.Database = textBox2.Text;
            mysqlCSB.UserID = textBox3.Text;
            mysqlCSB.Password = textBox4.Text;

            string queryString = @"SELECT slug FROM wp_terms WHERE term_id IN (SELECT term_id FROM wp_term_taxonomy WHERE taxonomy='category')";

            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;

                MySqlCommand com = new MySqlCommand(queryString, con);

                try
                {
                    con.Open();

                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dt;
        }

        private DataTable GetPosts()
        {
            DataTable dt = new DataTable();

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = textBox1.Text;
            mysqlCSB.Database = textBox2.Text;
            mysqlCSB.UserID = textBox3.Text;
            mysqlCSB.Password = textBox4.Text;

            string queryString = @"SELECT post_title, post_name FROM wp_posts WHERE post_type='post'";

            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;

                MySqlCommand com = new MySqlCommand(queryString, con);

                try
                {
                    con.Open();

                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dt;
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void button14_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetComments();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = GetCats();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            dataGridView3.DataSource = GetPosts();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button14_Click_1(object sender, EventArgs e)
        {

        }
    }
}
