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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BoolDeskApplication
{
    public partial class OnHoldInfo : Form
    {
        public OnHoldInfo()
        {
            InitializeComponent();
        }

        private void OnHoldInfo_Load(object sender, EventArgs e)
        {
            textBox7.Text = OnHold.ticket_id;
            textBox1.Text = OnHold.ticket_subject;
            richTextBox1.Text = OnHold.ticket_detail;
            textBox2.Text = OnHold.ticket_category;
            textBox3.Text = OnHold.ticket_status;
            textBox4.Text = OnHold.ticket_urgency;
            textBox5.Text = OnHold.ticket_analyst;
            textBox6.Text = OnHold.ticket_group;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            OnHold onHold = new OnHold();
            onHold.ShowDialog();
        }      

        private void button2_Click_1(object sender, EventArgs e)
        {
            OnHold.conn.Open();
            int lastId = Convert.ToInt32(textBox7.Text);
            SqlCommand delHistory = new SqlCommand("DELETE FROM dbo.TicketHistories WHERE TicketId = '" + lastId + "'", OnHold.conn);
            delHistory.ExecuteNonQuery();
            SqlCommand sil = new SqlCommand("DELETE FROM dbo.Tickets WHERE Id = '" + lastId + "'", OnHold.conn);
            sil.ExecuteNonQuery();
            OnHold.conn.Close();
            MessageBox.Show("Ticket Tamamen Silindi");
            this.Hide();
            OnHold onHold = new OnHold();
            onHold.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OnHold.conn.Open();
            SqlCommand guncelle = new SqlCommand("update dbo.Tickets set RequestSubject='" + textBox1.Text + "',RequestDetail='" + richTextBox1.Text + "' where Id='" + OnHold.ticket_id + "'", OnHold.conn);
            guncelle.ExecuteNonQuery();
            MessageBox.Show("Ticket Başarıyla Güncellendi");
            this.Close();
            OnHold.conn.Close();
            OnHold onHold = new OnHold();
            onHold.ShowDialog();
        }
    }
}
