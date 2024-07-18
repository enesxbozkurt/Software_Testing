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
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BoolDeskApplication
{
    public partial class Info : Form
    {

        
        public Info()
        {
            InitializeComponent();
        }

            /*
            ticket_category=dataGridView1.CurrentRow.Cells[20].Value.ToString();
            ticket_status=dataGridView1.CurrentRow.Cells[24].Value.ToString();
            ticket_urgency=dataGridView1.CurrentRow.Cells[25].Value.ToString();
            ticket_analyst=dataGridView1.CurrentRow.Cells[31].Value.ToString();
            ticket_group=dataGridView1.CurrentRow.Cells[30].Value.ToString();*/

        private void Info_Load(object sender, EventArgs e)
        {
            textBox7.Text = AllTickets.ticket_id;
            textBox1.Text = AllTickets.ticket_subject;
            richTextBox1.Text = AllTickets.ticket_detail;
            textBox2.Text = AllTickets.ticket_category;
            textBox3.Text = AllTickets.ticket_status;
            textBox4.Text = AllTickets.ticket_urgency;
            textBox5.Text = AllTickets.ticket_analyst;
            textBox6.Text = AllTickets.ticket_group;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AllTickets allTickets = new AllTickets();
            allTickets.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllTickets.conn.Open();
            SqlCommand guncelle = new SqlCommand("update dbo.Tickets set RequestSubject='" + textBox1.Text + "',RequestDetail='" + richTextBox1.Text + "' where Id='" + AllTickets.ticket_id + "'", AllTickets.conn);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Ticket Başarıyla Güncellendi");
            this.Close();
            AllTickets.conn.Close();
            AllTickets allTickets = new AllTickets();
            allTickets.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllTickets.conn.Open();
            int lastId = Convert.ToInt32(textBox7.Text);
            SqlCommand delHistory = new SqlCommand("DELETE FROM dbo.TicketHistories WHERE TicketId = '"+lastId+"'", AllTickets.conn);
            delHistory.ExecuteNonQuery();
            SqlCommand sil = new SqlCommand("DELETE FROM dbo.Tickets WHERE Id = '" + lastId + "'", AllTickets.conn);
            sil.ExecuteNonQuery();
            AllTickets.conn.Close();
            MessageBox.Show("Ticket Tamamen Silindi");
            this.Hide();
            AllTickets allTickets = new AllTickets();
            allTickets.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
