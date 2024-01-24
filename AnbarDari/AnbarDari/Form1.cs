using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnbarDari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SabtMahsol sabtMahsol = new SabtMahsol();
            sabtMahsol.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListMahsol listMahsol = new ListMahsol();
            listMahsol.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SabtMOshtari sabtMOshtari = new SabtMOshtari();
            sabtMOshtari.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListMOshtari listMOshtari = new ListMOshtari();
            listMOshtari.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VorodVaKhroj vorodVaKhroj = new VorodVaKhroj();
            vorodVaKhroj.Show();  
        }
    }
}
