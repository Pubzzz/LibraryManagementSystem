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
    public partial class Author : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();
        public Author()
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
                string qry = "Select * from Author";

                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "Author");
                bindingSource1.DataSource = DS.Tables["Author"];
                AuthorGridView.DataSource = bindingSource1;
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
            Home two = new Home();
            this.Hide();
            two.Show();
        }

        private void btn_Library_Click(object sender, EventArgs e)
        {
            Library two = new Library();
            this.Hide();
            two.Show();
        }

        private void btn_Book_Click(object sender, EventArgs e)
        {
            Book two = new Book();
            this.Hide();
            two.Show();
        }

        private void btn_Author_Click(object sender, EventArgs e)
        {
            Author two = new Author();
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Author where AuthorID='" + txt_AuthorID.Text + "' ";
            SqlCommand comd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(comd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if (DS.Rows.Count == 1)
                {
                    MessageBox.Show("This Author ID is already used");
                }
                else
                {
                    string qury = "INSERT INTO Author VALUES ('" + txt_AuthorID.Text + "','" + txt_AuthorName.Text + "','" + txt_ContactNo.Text + "','"+txt_Email.Text+"')";
                    SqlCommand cmd = new SqlCommand(qury, con);

                    try
                    {

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Record added Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occured : " + ex);
                    }
                    finally
                    {
                        con.Close();
                        AuthorGridView.DataSource = null;
                        LoadAllCustomer();
                    }
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string qry = "DELETE FROM Author WHERE AuthorID='" + txt_AuthorID.Text + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generated " + ex);
            }
            finally
            {
                con.Close();
                AuthorGridView.DataSource = null;
                LoadAllCustomer();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_AuthorID.Text = "";
            txt_AuthorName.Text = "";
            txt_ContactNo.Text = "";
            txt_Email.Text = "";
            txt_Search.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Search.Text = "";
            LoadAllCustomer();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string query = "Select * from Author where AuthorID ='" + txt_Search.Text + "'";
            SqlDataAdapter DA = new SqlDataAdapter(query, con);

            DataSet DS = new DataSet();
            DA.Fill(DS, "Author");
            bindingSource1.DataSource = DS.Tables["Author"];
            AuthorGridView.DataSource = bindingSource1;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string AName = "";
            string Contact = "";
            string Email = "";


            string qry = "UPDATE Author SET Name=@AName, Contact=@Contact, Email=@Email Where AuthorID= @AID";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                DataTable Dt = new DataTable();
                AuthorGridView.DataSource = bindingSource1;

                foreach (DataGridViewRow row in AuthorGridView.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString().Equals(txt_AuthorID.Text))
                        {
                            DataRow dr = Dt.NewRow();

                            AName = row.Cells[1].Value.ToString();
                            Contact = row.Cells[2].Value.ToString();
                            Email = row.Cells[3].Value.ToString();
                            break;
                        }
                    }
                }

                if (txt_AuthorName.Text != null && txt_AuthorName.Text != String.Empty)
                {
                    AName = txt_AuthorName.Text;
                }

                if (txt_ContactNo.Text != null && txt_ContactNo.Text != String.Empty)
                {
                    Contact = txt_ContactNo.Text;
                }

                if (txt_Email.Text != null && txt_Email.Text != String.Empty)
                {
                    Email = txt_Email.Text;
                }

                cmd.Parameters.AddWithValue("@AName", AName);
                cmd.Parameters.AddWithValue("@Contact", Contact);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@AID", txt_AuthorID.Text);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generated " + ex);
            }
            finally
            {
                con.Close();
                AuthorGridView.DataSource = null;
                LoadAllCustomer();
            }
        }
    }
}
