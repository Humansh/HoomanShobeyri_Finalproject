using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnbarDari
{
    public partial class SabtMOshtari : Form
    {
        public SabtMOshtari()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string family = textBox2.Text;
            string Phone = textBox3.Text;
            string address = textBox4.Text;
            string Ncode = textBox5.Text;
            string Cname = textBox6.Text;
            string job = textBox7.Text;
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection sc = new SqlConnection(connection);
            sc.Open();
            string cm = $"insert into [dbo].[Moshtari](Name,Family,Phone,Address,NationalCode,CompanyName,Job) values ('{name}','{family}','{Phone}','{address}','{Ncode}','{Cname}','{job}')";
            SqlCommand command = new SqlCommand(cm, sc);
            command.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show($"Moshtari <<{name}  {family}>> ba code <<{Ncode}>> sabt shod");
        }

        private void SabtMOshtari_Load(object sender, EventArgs e)
        {

        }
    }
}
