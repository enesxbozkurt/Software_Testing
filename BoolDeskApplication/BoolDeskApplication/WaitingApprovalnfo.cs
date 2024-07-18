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
    public partial class WaitingApprovalnfo : Form
    {
        public WaitingApprovalnfo()
        {
            InitializeComponent();
        }

        private void WaitingApprovalnfo_Load(object sender, EventArgs e)
        {
            textBox7.Text = WaitingApproval.ticket_id;
            textBox1.Text = WaitingApproval.ticket_subject;
            richTextBox1.Text = WaitingApproval.ticket_detail;
            textBox2.Text = WaitingApproval.ticket_category;
            textBox3.Text = WaitingApproval.ticket_status;
            textBox4.Text = WaitingApproval.ticket_urgency;
            textBox5.Text = WaitingApproval.ticket_analyst;
            textBox6.Text = WaitingApproval.ticket_group;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            WaitingApproval waitingApproval = new WaitingApproval();
            waitingApproval.ShowDialog();
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            WaitingApproval.conn.Open();
            SqlCommand guncelle = new SqlCommand("update dbo.Tickets set RequestSubject='" + textBox1.Text + "',RequestDetail='" + richTextBox1.Text + "' where Id='" + WaitingApproval.ticket_id + "'", WaitingApproval.conn);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Ticket Başarıyla Güncellendi");
            this.Close();
            WaitingApproval.conn.Close();
            WaitingApproval waitingApproval = new WaitingApproval();
            waitingApproval.ShowDialog();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            WaitingApproval.conn.Open();
            int lastId = Convert.ToInt32(textBox7.Text);
            SqlCommand delHistory = new SqlCommand("DELETE FROM dbo.TicketHistories WHERE TicketId = '" + lastId + "'", WaitingApproval.conn);
            delHistory.ExecuteNonQuery();
            SqlCommand sil = new SqlCommand("DELETE FROM dbo.Tickets WHERE Id = '" + lastId + "'", WaitingApproval.conn);
            sil.ExecuteNonQuery();
            WaitingApproval.conn.Close();
            MessageBox.Show("Ticket Tamamen Silindi");
            this.Hide();
            WaitingApproval waitingApproval = new WaitingApproval();
            waitingApproval.ShowDialog();
        }
    }
}
