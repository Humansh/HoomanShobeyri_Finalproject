using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AnbarDari
{
    public partial class SabtMahsol : Form
    {
        public SabtMahsol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                string name = textBox1.Text;
                string code = textBox2.Text;
                int price = int.Parse(textBox3.Text);
                int count = int.Parse(textBox4.Text);
                string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
                SqlConnection sc = new SqlConnection(connection);
                sc.Open();
                string cm = $"insert into [dbo].[Mahsol](Name,Code,Price,Count) values ('{name}','{code}','{price}',{count})";
                SqlCommand command = new SqlCommand(cm, sc);
                command.ExecuteNonQuery();
                sc.Close();
                MessageBox.Show($"Mahsole <<{name}>> ba code <<{code}>> sabt shod");
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

        }

        private void SabtMahsol_Load(object sender, EventArgs e)
        {

        }
    }
}
