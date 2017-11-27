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

namespace smec
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;
        
        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=smec_db;uid=root;pwd=root");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string username = user.Text;
            string password = pass.Text;
            string query = "SELECT * FROM tbl_user " + " WHERE username =  '" + username + "' AND password = '" + password + "'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            //IF THERE EXIST USERNAME AND PASSWORD
            if (dt.Rows.Count == 1)
            {
                string firstname = dt.Rows[0]["fname"].ToString();
                string lastname = dt.Rows[0][2].ToString();
                Form2 f2 = new Form2();
                f2.login_form = this;
                f2.getuser = firstname;
                f2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
