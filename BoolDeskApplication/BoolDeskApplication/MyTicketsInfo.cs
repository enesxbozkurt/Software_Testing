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

namespace BoolDeskApplication
{
    public partial class MyTicketsInfo : Form
    {
        public MyTicketsInfo()
        {
            InitializeComponent();
        }

        private void MyTicketsInfo_Load(object sender, EventArgs e)
        {
            textBox7.Text = Mytickets.ticket_id;
            textBox1.Text = Mytickets.ticket_subject;
            richTextBox1.Text = Mytickets.ticket_detail;
            textBox2.Text = Mytickets.ticket_category;
            textBox3.Text = Mytickets.ticket_status;
            textBox4.Text = Mytickets.ticket_urgency;
            textBox5.Text = Mytickets.ticket_analyst;
            textBox6.Text = Mytickets.ticket_group;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mytickets mytickets = new Mytickets(); 
            mytickets.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Mytickets.conn.Open();
            int lastId = Convert.ToInt32(textBox7.Text);
            SqlCommand delHistory = new SqlCommand("DELETE FROM dbo.TicketHistories WHERE TicketId = '" + lastId + "'", Mytickets.conn);
            delHistory.ExecuteNonQuery();
            SqlCommand sil = new SqlCommand("DELETE FROM dbo.Tickets WHERE Id = '" + lastId + "'", Mytickets.conn);
            sil.ExecuteNonQuery();
            Mytickets.conn.Close();
            MessageBox.Show("Ticket Tamamen Silindi");
            this.Hide();
            Mytickets mytickets = new Mytickets();
            mytickets.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mytickets.conn.Open();
            SqlCommand guncelle = new SqlCommand("update dbo.Tickets set RequestSubject='" + textBox1.Text + "',RequestDetail='" + richTextBox1.Text + "' where Id='" + Mytickets.ticket_id + "'", Mytickets.conn);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Ticket Başarıyla Güncellendi");
            this.Close();
            Mytickets.conn.Close();
            Mytickets mytickets = new Mytickets();
            mytickets.ShowDialog();
        }
    }
}
