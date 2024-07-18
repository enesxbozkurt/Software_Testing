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
    public partial class InProgressInfo : Form
    {
        public InProgressInfo()
        {
            InitializeComponent();
        }

        private void InProgressInfo_Load(object sender, EventArgs e)
        {
            textBox7.Text = InProgress.ticket_id;
            textBox1.Text = InProgress.ticket_subject;
            richTextBox1.Text = InProgress.ticket_detail;
            textBox2.Text = InProgress.ticket_category;
            textBox3.Text = InProgress.ticket_status;
            textBox4.Text = InProgress.ticket_urgency;
            textBox5.Text = InProgress.ticket_analyst;
            textBox6.Text = InProgress.ticket_group;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            InProgress inProgress = new InProgress();
            inProgress.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InProgress.conn.Open();
            int lastId = Convert.ToInt32(textBox7.Text);
            SqlCommand delHistory = new SqlCommand("DELETE FROM dbo.TicketHistories WHERE TicketId = '" + lastId + "'", InProgress.conn);
            delHistory.ExecuteNonQuery();
            SqlCommand sil = new SqlCommand("DELETE FROM dbo.Tickets WHERE Id = '" + lastId + "'", InProgress.conn);
            sil.ExecuteNonQuery();
            InProgress.conn.Close();
            MessageBox.Show("Ticket Tamamen Silindi");
            this.Hide();
            InProgress inProgress = new InProgress();
            inProgress.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InProgress.conn.Open();
            SqlCommand guncelle = new SqlCommand("update dbo.Tickets set RequestSubject='" + textBox1.Text + "',RequestDetail='" + richTextBox1.Text + "' where Id='" + InProgress.ticket_id + "'", InProgress.conn);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Ticket Başarıyla Güncellendi");
            this.Close();
            InProgress.conn.Close();
            InProgress inProgress = new InProgress();
            inProgress.ShowDialog();
        }
    }
}
