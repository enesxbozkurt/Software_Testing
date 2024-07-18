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
    public partial class OpenTicketsInfo : Form
    {
        public OpenTicketsInfo()
        {
            InitializeComponent();
        }

        private void OpenTicketsInfo_Load(object sender, EventArgs e)
        {
            textBox7.Text = OpenTickets.ticket_id;
            textBox1.Text = OpenTickets.ticket_subject;
            richTextBox1.Text = OpenTickets.ticket_detail;
            textBox2.Text = OpenTickets.ticket_category;
            textBox3.Text = OpenTickets.ticket_status;
            textBox4.Text = OpenTickets.ticket_urgency;
            textBox5.Text = OpenTickets.ticket_analyst;
            textBox6.Text = OpenTickets.ticket_group;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            OpenTickets openTickets = new OpenTickets();
            openTickets.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenTickets.conn.Open();
            SqlCommand guncelle = new SqlCommand("update dbo.Tickets set RequestSubject='" + textBox1.Text + "',RequestDetail='" + richTextBox1.Text + "' where Id='" + OpenTickets.ticket_id + "'", OpenTickets.conn);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Ticket Başarıyla Güncellendi");
            this.Close();
            OpenTickets.conn.Close();
            OpenTickets openTickets = new OpenTickets();
            openTickets.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenTickets.conn.Open();
            int lastId = Convert.ToInt32(textBox7.Text);
            SqlCommand delHistory = new SqlCommand("DELETE FROM dbo.TicketHistories WHERE TicketId = '" + lastId + "'", OpenTickets.conn);
            delHistory.ExecuteNonQuery();
            SqlCommand delApproval = new SqlCommand("DELETE FROM dbo.TicketApprovals WHERE TicketId = '" + lastId + "'", OpenTickets.conn);
            delApproval.ExecuteNonQuery();
            SqlCommand sil = new SqlCommand("DELETE FROM dbo.Tickets WHERE Id = '" + lastId + "'", OpenTickets.conn);
            sil.ExecuteNonQuery();
            OpenTickets.conn.Close();
            MessageBox.Show("Ticket Tamamen Silindi");
            this.Hide();
            OpenTickets openTickets = new OpenTickets();
            openTickets.ShowDialog();
        }
    }
}
