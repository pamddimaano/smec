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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;
        public int timeLeft { get; set; }
        public String name { get; set; }



        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=smec_db;uid=root;pwd=root");

            ControlBox = false;
            Text = "";
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


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timeLeft = 100;
            
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
            if (dt.Rows.Count == 1 && dt.Rows[0]["user_status"].ToString() == "active")
            {
                timer1.Start();
                string firstname = dt.Rows[0]["fname"].ToString();
                name = firstname;
                
                panel3.Show();
                pictureBox2.Enabled = false;
                pictureBox2.Visible = false;
            }
            else
            {
                MessageBox.Show("Invalid login", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.Enabled = true;
            pictureBox2.Visible = true;

            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 3;
            }
            else
            {
                timer1.Stop();
                panel3.Hide();
                MessageBox.Show("Logged in!");
                this.Hide();
                Form2 f5 = new Form2();
                f5.login_form = this;
                f5.getuser = name;
                f5.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
