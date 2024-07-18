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
    public partial class SolutionOverdueInfo : Form
    {
        public SolutionOverdueInfo()
        {
            InitializeComponent();
        }

        private void SolutionOverdueInfo_Load(object sender, EventArgs e)
        {
            textBox7.Text = SolutionOverdue.ticket_id;
            textBox1.Text = SolutionOverdue.ticket_subject;
            richTextBox1.Text = SolutionOverdue.ticket_detail;
            textBox2.Text = SolutionOverdue.ticket_category;
            textBox3.Text = SolutionOverdue.ticket_status;
            textBox4.Text = SolutionOverdue.ticket_urgency;
            textBox5.Text = SolutionOverdue.ticket_analyst;
            textBox6.Text = SolutionOverdue.ticket_group;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SolutionOverdue solutionOverdue = new SolutionOverdue();
            solutionOverdue.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SolutionOverdue.conn.Open();
            int lastId = Convert.ToInt32(textBox7.Text);
            SqlCommand delHistory = new SqlCommand("DELETE FROM dbo.TicketHistories WHERE TicketId = '" + lastId + "'", SolutionOverdue.conn);
            delHistory.ExecuteNonQuery();
            SqlCommand sil = new SqlCommand("DELETE FROM dbo.Tickets WHERE Id = '" + lastId + "'", SolutionOverdue.conn);
            sil.ExecuteNonQuery();
            SolutionOverdue.conn.Close();
            MessageBox.Show("Ticket Tamamen Silindi");
            this.Hide();
            SolutionOverdue solutionOverdue = new SolutionOverdue();
            solutionOverdue.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SolutionOverdue.conn.Open();
            SqlCommand guncelle = new SqlCommand("update dbo.Tickets set RequestSubject='" + textBox1.Text + "',RequestDetail='" + richTextBox1.Text + "' where Id='" + SolutionOverdue.ticket_id + "'", SolutionOverdue.conn);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Ticket Başarıyla Güncellendi");
            this.Close();
            SolutionOverdue.conn.Close();
            SolutionOverdue solutionOverdue = new SolutionOverdue();
            solutionOverdue.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
