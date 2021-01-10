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

namespace LibraryManagementSystem
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True");

        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            
           string qry = "SELECT * FROM Users where Username='" + TxtUname.Text + "' AND Password='" + txtPass.Text + "'";
            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable DS = new DataTable();
                DA.Fill(DS);


                if (DS.Rows.Count == 1)
                {
                    Home one = new Home();
                    this.Hide();
                    one.Show();
                }
                else
                {
                    MessageBox.Show("Sorry! You are not a registered user");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generated : " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void btn_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(this, new EventArgs());
            }
        }

        private void btn_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
