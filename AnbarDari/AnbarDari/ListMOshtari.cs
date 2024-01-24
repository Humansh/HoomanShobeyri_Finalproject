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
    public partial class ListMOshtari : Form
    {
        public ListMOshtari()
        {
            InitializeComponent();
        }

        private void ListMOshtari_Load(object sender, EventArgs e)
        {
            listitem();
        }
        private void listitem()
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection sc = new SqlConnection(connection);
            sc.Open();
            string cm = " select * from [dbo].[Moshtari]";
            SqlCommand command = new SqlCommand(cm, sc);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                string line = dr["Name"].ToString() + "," + dr["Family"].ToString() + "," + dr["Phone"].ToString() + "," + dr["Address"].ToString() + "," + dr["NationalCode"].ToString() + "," + dr["CompanyName"].ToString() + "," + dr["Job"].ToString();
                listBox1.Items.Add(line);
            }
            dr.Close();
            sc.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = listBox1.SelectedItem.ToString();
            string[] line = select.Split(',');
            string code = line[4];
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection sc = new SqlConnection(connection);
            sc.Open();
            string cm = $" select * from [dbo].[Moshtari] where NationalCode={code}";
            SqlCommand command = new SqlCommand(cm, sc);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr["Name"].ToString();
                textBox2.Text = dr["Family"].ToString();
                textBox3.Text = dr["Phone"].ToString();
                textBox4.Text = dr["Address"].ToString();
                textBox5.Text = dr["NationalCode"].ToString();
                textBox6.Text = dr["CompanyName"].ToString();
                textBox7.Text = dr["Job"].ToString();
            }
            dr.Close();
            sc.Close();
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
            string cm = $"update [dbo].[Moshtari] set Name='{name}',Family='{family}',Phone='{Phone}',Address='{address}',CompanyName='{Cname}',Job='{job}' where NationalCode={Ncode}";
            SqlCommand command = new SqlCommand(cm, sc);
            command.ExecuteNonQuery();
            sc.Close();
            MessageBox.Show($"Moshtari <<{name}  {family}>> ba code <<{Ncode}>> UPDATE shod");
            listBox1.Items.Clear();
            listitem();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string code = textBox8.Text;
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection sc = new SqlConnection(connection);
            sc.Open();
            string cm = $" select * from [dbo].[Moshtari] where NationalCode={code}";
            SqlCommand command = new SqlCommand(cm, sc);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr["Name"].ToString();
                textBox2.Text = dr["Family"].ToString();
                textBox3.Text = dr["Phone"].ToString();
                textBox4.Text = dr["Address"].ToString();
                textBox5.Text = dr["NationalCode"].ToString();
                textBox6.Text = dr["CompanyName"].ToString();
                textBox7.Text = dr["Job"].ToString();
            }
            dr.Close();
            sc.Close();
        }
    }
}
 
