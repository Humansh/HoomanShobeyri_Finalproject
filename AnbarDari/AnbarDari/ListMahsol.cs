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
    public partial class ListMahsol : Form
    {
        public ListMahsol()
        {
            InitializeComponent();
        }

        private void ListMahsol_Load(object sender, EventArgs e)
        {
            listitem();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string code = textBox8.Text;
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection sc = new SqlConnection(connection);
            sc.Open();
            string cm = $" select * from [dbo].[Mahsol] where Code={code}";
            SqlCommand command = new SqlCommand(cm, sc);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr["Name"].ToString();
                textBox2.Text = dr["Code"].ToString();
                textBox3.Text = dr["Price"].ToString();
                textBox4.Text = dr["Count"].ToString();
            }
            dr.Close();
            sc.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = listBox1.SelectedItem.ToString();
            string[] line = select.Split(',');
            string code = line[1];
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection sc = new SqlConnection(connection);
            sc.Open();
            string cm = $" select * from [dbo].[Mahsol] where Code={code}";
            SqlCommand command = new SqlCommand(cm, sc);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr["Name"].ToString();
                textBox2.Text = dr["Code"].ToString();
                textBox3.Text = dr["Price"].ToString();
                textBox4.Text = dr["Count"].ToString();
            }
            dr.Close();
            sc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
                string name = textBox1.Text;
                string code = textBox2.Text;
                int price = int.Parse(textBox3.Text);
                int count = int.Parse(textBox4.Text);
                string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
                SqlConnection sc = new SqlConnection(connection);
                sc.Open();
                string cm = $"update [dbo].[Mahsol] set Name='{name}',Price='{price}',Count='{count}' where Code={code}";
                SqlCommand command = new SqlCommand(cm, sc);
                command.ExecuteNonQuery();
                sc.Close();
                MessageBox.Show($"Mahsole <<{name}>> ba code <<{code}>> Update shod");
                listBox1.Items.Clear();
                listitem();

        }
        private void listitem()
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection sc = new SqlConnection(connection);
            sc.Open();
            string cm = " select * from [dbo].[Mahsol]";
            SqlCommand command = new SqlCommand(cm, sc);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                string line = dr["Name"].ToString() + "," + dr["Code"].ToString() + "," + dr["Price"].ToString() + "," + dr["Count"].ToString();
                listBox1.Items.Add(line);
            }
            dr.Close();
            sc.Close();
        }
    }
}
