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
            string conStr = "server=hipsters.mysql.ukraine.com.ua;user=hipsters_guru;" +
                             "database=hipsters_guru;password=hipsters_guru;";

            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    string sql = "INSERT INTO friendf (name, lastname, age)" +
                                 "VALUES ('Misha', 'Ivanov', 26)";

                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    con.Open();

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
    }
}
