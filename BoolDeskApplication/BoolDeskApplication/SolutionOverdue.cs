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

namespace BoolDeskApplication
{
    public partial class SolutionOverdue : Form
    {

        public static string ticket_id = "";
        public static string ticket_subject = "";
        public static string ticket_detail = "";
        public static string ticket_category = "";
        public static string ticket_urgency = "";
        public static string ticket_status = "";
        public static string ticket_analyst = "";
        public static string ticket_group = "";


        public static SqlConnection conn = new SqlConnection("Data Source=BDESK-DEV\\SQLEXPRESS;Initial Catalog=BoolDesk;Integrated Security=True;TrustServerCertificate=True");

        void listele()

        {
            DataTable tablo = new DataTable();
            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select * from dbo.Tickets where SolutionOverdue=1", conn);
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            conn.Close();
        }

        void ticketCategory()

        {
            conn.Open();
            SqlCommand category = new SqlCommand("SELECT * FROM dbo.Tickets INNER JOIN dbo.TicketCategories ON dbo.Tickets.TicketCategoryId = dbo.TicketCategories.Id where dbo.Tickets.Id='" + ticket_id + "' ", conn);
            SqlDataReader categoryOku = category.ExecuteReader();
            while (categoryOku.Read())
            {
                ticket_category = categoryOku["Name"].ToString();
            }
            conn.Close();
        }
        void ticketUrgency()

        {
            conn.Open();
            SqlCommand urgency = new SqlCommand("SELECT * FROM dbo.Tickets INNER JOIN dbo.TicketUrgencies ON dbo.Tickets.TicketUrgencyId = dbo.TicketUrgencies.Id where dbo.Tickets.Id='" + ticket_id + "'", conn);
            SqlDataReader urgencyOku = urgency.ExecuteReader();
            while (urgencyOku.Read())
            {
                ticket_urgency = urgencyOku["Name"].ToString();
            }
            conn.Close();
        }
        void ticketStatus()

        {
            conn.Open();
            SqlCommand status = new SqlCommand("SELECT * FROM dbo.Tickets INNER JOIN dbo.TicketStatus ON dbo.Tickets.TicketStatusId = dbo.TicketStatus.Id where dbo.Tickets.Id='" + ticket_id + "'", conn);
            SqlDataReader statusOku = status.ExecuteReader();
            while (statusOku.Read())
            {
                ticket_status = statusOku["Name"].ToString();
            }
            conn.Close();
        }
        void ticketAnalyst()

        {
            conn.Open();
            SqlCommand analyst = new SqlCommand("SELECT * FROM dbo.Tickets INNER JOIN dbo.Users ON dbo.Tickets.AssignedById = dbo.Users.Id where dbo.Tickets.Id='" + ticket_id + "'", conn);
            SqlDataReader analystOku = analyst.ExecuteReader();

            if (analystOku.HasRows == false)
            {
                ticket_analyst = "Bu Çağrıya Analist Atanmamış";
            }
            else
            {
                while (analystOku.Read())
                {
                    ticket_analyst = analystOku["FirstName"].ToString() + " " + analystOku["LastName"].ToString();
                }
            }

            conn.Close();
        }
        void ticketGroup()

        {
            conn.Open();
            SqlCommand group = new SqlCommand("SELECT * FROM dbo.Tickets INNER JOIN dbo.UserGroups ON dbo.Tickets.AssignedToGroupId = dbo.UserGroups.Id where dbo.Tickets.Id='" + ticket_id + "'", conn);
            SqlDataReader groupOku = group.ExecuteReader();

            if (groupOku.HasRows == false)
            {
                ticket_group = "Bu Çağrının Grubu Yok";
            }
            else
            {
                while (groupOku.Read())
                {
                    ticket_group = groupOku["Name"].ToString();

                }
            }

            conn.Close();
        }
        public SolutionOverdue()
        {
            InitializeComponent();
        }

        private void SolutionOverdue_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Portal portal = new Portal();
            portal.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ticket_id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ticket_subject = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            if (ticket_subject == "") { ticket_subject = "Bu Çağrının Konusu Yok"; }
            ticket_detail = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            if (ticket_detail == "") { ticket_detail = "Bu Çağrının Detayı Yok"; }
            ticketCategory();
            ticketUrgency();
            ticketStatus();
            ticketAnalyst();
            ticketGroup();
            this.Hide();
            SolutionOverdueInfo solutionOverdue = new SolutionOverdueInfo();
            solutionOverdue.ShowDialog();   
        }
    }
}
