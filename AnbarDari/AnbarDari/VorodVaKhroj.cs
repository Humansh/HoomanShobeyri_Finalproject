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
    public partial class VorodVaKhroj : Form
    {
        public VorodVaKhroj()
        {
            InitializeComponent();
        }

        private void VorodVaKhroj_Load(object sender, EventArgs e)
        {
            addlist();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string code = textBox5.Text;
            int count = int.Parse(textBox4.Text);
            int c = 0;  
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection sc = new SqlConnection(connection);
            sc.Open();
            string cm = $"select Count from [dbo].[Mahsol] where Code={code}";
            SqlCommand command = new SqlCommand(cm, sc);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                c =int.Parse(dr["Count"].ToString());
            }
            dr.Close();
            c += count;
            string cm2 = $"update [dbo].[Mahsol] set Count={c} ";
            SqlCommand command2 = new SqlCommand(cm2, sc);
            command2.ExecuteNonQuery();
            string cm3 = $"insert into [dbo].[Company nameorodKhoroj](CodeMahsol,Count,VorodiYaKhoroj) values ('{code}','{count}','2')";
            SqlCommand command3 = new SqlCommand(cm3, sc);
            command3.ExecuteNonQuery();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            addlist();
            sc.Close();

        }
        private void addlist()
        {
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection sc = new SqlConnection(connection);
            sc.Open();
            string cm = " select * from [dbo].[Company nameorodKhoroj]";
            SqlCommand command = new SqlCommand(cm, sc);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                string line = dr["CodeMahsol"].ToString() + "," + dr["CodeMoshtari"].ToString() + "," + dr["Count"].ToString();
                int vk = int.Parse(dr["VorodiYaKhoroj"].ToString());
                if (vk == 1)
                {
                    listBox1.Items.Add(line);
                }
                else
                    listBox2.Items.Add(line);

            }
            dr.Close();
            sc.Close();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            string code = textBox2.Text;
            int c = 0;
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection sc = new SqlConnection(connection);
            sc.Open();
            string cm = $"select Count from [dbo].[Mahsol] where Code={code}";
            SqlCommand command = new SqlCommand(cm, sc);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = int.Parse(dr["Count"].ToString());
            }
            for (int i = 0; i <= c; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
            dr.Close();
            sc.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = textBox2.Text;
            int count = int.Parse(comboBox1.SelectedItem.ToString());
            string codemeli = textBox1.Text;
            int c = 0;
            string connection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True";
            SqlConnection sc = new SqlConnection(connection);
            sc.Open();
            string cm = $"select Count from [dbo].[Mahsol] where Code={code}";
            SqlCommand command = new SqlCommand(cm, sc);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                c = int.Parse(dr["Count"].ToString());
            }
            dr.Close();
            c -= count;
            string cm2 = $"update [dbo].[Mahsol] set Count={c} ";
            SqlCommand command2 = new SqlCommand(cm2, sc);
            command2.ExecuteNonQuery();
            string cm3 = $"insert into [dbo].[Company nameorodKhoroj](CodeMahsol,CodeMoshtari,Count,VorodiYaKhoroj) values ('{code}','{codemeli}','{count}','1')";
            SqlCommand command3 = new SqlCommand(cm3, sc);
            command3.ExecuteNonQuery();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            addlist();
            sc.Close();

        }
    }
}
