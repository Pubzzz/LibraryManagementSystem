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
    public partial class Home : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();
        public Home()
        {
            InitializeComponent();
            LoadAllCustomer();
        }
        private void LoadAllCustomer()
        {
            try
            {
                DS = new DataSet();
                bindingSource1.DataSource = null;

                con.Open();
                string qry = "Select * from Book";

                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "BookDetails");
                bindingSource1.DataSource = DS.Tables["BookDetails"];

                lblBookCount.Text = bindingSource1.Count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex);
            }
            finally
            {
                con.Close();
            }
            try
            {
                DS = new DataSet();
                bindingSource1.DataSource = null;

                con.Open();
                string qry = "Select * from Author";

                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "AuthorDetails");
                bindingSource1.DataSource = DS.Tables["AuthorDetails"];

                lblAuthorCount.Text = bindingSource1.Count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex);
            }
            finally
            {
                con.Close();
            }
            try
            {
                DS = new DataSet();
                bindingSource1.DataSource = null;

                con.Open();
                string qry = "Select * from Loan";

                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "LoanDetails");
                bindingSource1.DataSource = DS.Tables["LoanDetails"];

                lblLoanCount.Text = bindingSource1.Count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex);
            }
            finally
            {
                con.Close();
            }
        }
            private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            Home one = new Home();
            this.Hide();
            one.Show();
        }

        private void btn_Book_Click(object sender, EventArgs e)
        {
            Book one = new Book();
            this.Hide();
            one.Show();
        }

        private void btn_Author_Click(object sender, EventArgs e)
        {
            Author two = new Author();
            this.Hide();
            two.Show();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            Login two = new Login();
            this.Hide();
            two.Show();
        }

        private void btn_Library_Click(object sender, EventArgs e)
        {
            Library two = new Library();
            this.Hide();
            two.Show();
        }

        private void btn_Borrower_Click(object sender, EventArgs e)
        {
            Borrower two = new Borrower();
            this.Hide();
            two.Show();
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            Copy two = new Copy();
            this.Hide();
            two.Show();
        }

        private void btn_Loan_Click(object sender, EventArgs e)
        {
            Loan two = new Loan();
            this.Hide();
            two.Show();
        }

        private void btn_ViewBooks_Click(object sender, EventArgs e)
        {
            Book three = new Book();
            this.Hide();
            three.Show();
        }

        private void btn_ViewAuhors_Click(object sender, EventArgs e)
        {
            Author three = new Author();
            this.Hide();
            three.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Loan three = new Loan();
            this.Hide();
            three.Show();
        }
    }
}
