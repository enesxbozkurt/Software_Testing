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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BoolDeskApplication
{
    public partial class YoneticiGirisEkrani : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=BDESK-DEV\\SQLEXPRESS;Initial Catalog=BoolDesk;Integrated Security=True;TrustServerCertificate=True");

        public static string kadi = "";

        public static string ksifre = "";

        public static string kid = "";

        public YoneticiGirisEkrani()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
           
                bool giriskontrol = false;

                conn.Open();

                SqlCommand kadsifre = new SqlCommand("Select UserName,Password,Id from dbo.Users", conn);

                SqlDataReader koku = kadsifre.ExecuteReader();

                while (koku.Read())

                {

                    if (textBox1.Text == koku["UserName"].ToString() && textBox2.Text == koku["Password"].ToString())

                    {

                        giriskontrol = true;
                        kid = koku["Id"].ToString();

                    }

                }



                if (giriskontrol == true)

                {

                    kadi = textBox1.Text;
                    ksifre = textBox2.Text;

                    Portal form = new Portal();
                    form.Show();

                    this.Hide();


                }

                else MessageBox.Show("Kullanıcı Bulunamadı...");
                conn.Close();
            }

        private void YoneticiGirisEkrani_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
            
        }
    }
}
