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
    public partial class ResponseOverdueInfo : Form
    {
        public ResponseOverdueInfo()
        {
            InitializeComponent();
        }

        private void ResponseOverdueInfo_Load(object sender, EventArgs e)
        {
            textBox7.Text = FirstResponseOverdue.ticket_id;
            textBox1.Text = FirstResponseOverdue.ticket_subject;
            richTextBox1.Text = FirstResponseOverdue.ticket_detail;
            textBox2.Text = FirstResponseOverdue.ticket_category;
            textBox3.Text = FirstResponseOverdue.ticket_status;
            textBox4.Text = FirstResponseOverdue.ticket_urgency;
            textBox5.Text = FirstResponseOverdue.ticket_analyst;
            textBox6.Text = FirstResponseOverdue.ticket_group;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FirstResponseOverdue firstResponseOverdue =new FirstResponseOverdue();
            firstResponseOverdue.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FirstResponseOverdue.conn.Open();
            int lastId = Convert.ToInt32(textBox7.Text);
            SqlCommand delHistory = new SqlCommand("DELETE FROM dbo.TicketHistories WHERE TicketId = '" + lastId + "'", FirstResponseOverdue.conn);
            delHistory.ExecuteNonQuery();
            SqlCommand sil = new SqlCommand("DELETE FROM dbo.Tickets WHERE Id = '" + lastId + "'", FirstResponseOverdue.conn);
            sil.ExecuteNonQuery();
            FirstResponseOverdue.conn.Close();
            MessageBox.Show("Ticket Tamamen Silindi");
            this.Hide();
            FirstResponseOverdue firstResponseOverdue = new FirstResponseOverdue();
            firstResponseOverdue.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FirstResponseOverdue.conn.Open();
            SqlCommand guncelle = new SqlCommand("update dbo.Tickets set RequestSubject='" + textBox1.Text + "',RequestDetail='" + richTextBox1.Text + "' where Id='" + FirstResponseOverdue.ticket_id + "'", FirstResponseOverdue.conn);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Ticket Başarıyla Güncellendi");
            this.Close();
            FirstResponseOverdue.conn.Close();
            FirstResponseOverdue firstResponseOverdue = new FirstResponseOverdue();
            firstResponseOverdue.ShowDialog();
        }
    }
}
