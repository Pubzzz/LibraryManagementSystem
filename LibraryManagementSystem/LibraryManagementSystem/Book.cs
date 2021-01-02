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
    public partial class Book : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();
        public Book()
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

                DA.Fill(DS, "Book");
                bindingSource1.DataSource = DS.Tables["Book"];
                BookGridView.DataSource = bindingSource1;
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

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string query = "Select * from Book where Title ='" + txt_Search.Text + "'";
            SqlDataAdapter DA = new SqlDataAdapter(query, con);

            DataSet DS = new DataSet();
            DA.Fill(DS, "Book");
            bindingSource1.DataSource = DS.Tables["Book"];
            BookGridView.DataSource = bindingSource1;
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
            string query = "SELECT * FROM Book where ISBN='" + txt_ISBN.Text + "' ";
            SqlCommand comd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(comd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if (DS.Rows.Count == 1)
                {
                    MessageBox.Show("This Book has already been registered ");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("spInsertBooks", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@ISBN", SqlDbType.VarChar).Value = txt_ISBN.Text;
                            cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = txt_Title.Text;
                            cmd.Parameters.Add("@author", SqlDbType.VarChar).Value = txt_Author.Text;
                            cmd.Parameters.Add("@copies", SqlDbType.VarChar).Value = txt_NoCopies.Text;
                            cmd.Parameters.Add("@subject", SqlDbType.VarChar).Value = txt_Subject.Text;

                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Record added Successfully");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error occured : " + ex);
                            }
                            finally
                            {
                                conn.Close();
                                con.Close();
                                BookGridView.DataSource = null;
                                LoadAllCustomer();
                            }
                        }
                    }
                    con.Close();
                }
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {

            string query = "SELECT * FROM Book where ISBN='" + txt_ISBN.Text + "' ";
            SqlCommand comd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(comd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if (DS.Rows.Count == 0)
                {
                    MessageBox.Show("This Book is not registered.");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteBooks", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@ISBN", SqlDbType.VarChar).Value = txt_ISBN.Text;

                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Record deleted Successfully");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error occured : " + ex);
                            }
                            finally
                            {
                                conn.Close();
                                con.Close();
                                BookGridView.DataSource = null;
                                LoadAllCustomer();
                            }
                        }
                    }
                    con.Close();
                }
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

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_ISBN.Text = "";
            txt_Author.Text = "";
            txt_NoCopies.Text = "";
            txt_Search.Text = "";
            txt_Subject.Text = "";
            txt_Title.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Search.Text = "";
            LoadAllCustomer();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string Title = "";
            string Author = "";
            string Copies = "";
            string Sub = "";

            string query = "SELECT * FROM Book where ISBN='" + txt_ISBN.Text + "' ";
            SqlCommand comd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(comd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if (DS.Rows.Count == 0)
                {
                    MessageBox.Show("This Author ID does not exist.");
                }
                else
                {
                    DataTable Dt = new DataTable();
                    BookGridView.DataSource = bindingSource1;

                    foreach (DataGridViewRow row in BookGridView.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            if (row.Cells[0].Value.ToString().Equals(txt_ISBN.Text))
                            {
                                DataRow dr = Dt.NewRow();

                                Title = row.Cells[1].Value.ToString();
                                Author = row.Cells[2].Value.ToString();
                                Copies = row.Cells[3].Value.ToString();
                                Sub = row.Cells[4].Value.ToString();
                                break;
                            }
                        }
                    }

                    if (txt_Title.Text != null && txt_Title.Text != String.Empty)
                    {
                        Title = txt_Title.Text;
                    }

                    if (txt_Author.Text != null && txt_Author.Text != String.Empty)
                    {
                        Author = txt_Author.Text;
                    }

                    if (txt_NoCopies.Text != null && txt_NoCopies.Text != String.Empty)
                    {
                        Copies = txt_NoCopies.Text;
                    }
                    if (txt_Subject.Text != null && txt_Subject.Text != String.Empty)
                    {
                        Sub = txt_Subject.Text;
                    }

                    using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateBooks", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@ISBN", SqlDbType.VarChar).Value = txt_ISBN.Text;
                            cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = Title;
                            cmd.Parameters.Add("@author", SqlDbType.VarChar).Value = Author;
                            cmd.Parameters.Add("@copies", SqlDbType.VarChar).Value = Copies;
                            cmd.Parameters.Add("@subject", SqlDbType.VarChar).Value = Sub;

                            try
                            {
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Record Updated Successfully");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error occured : " + ex);
                            }
                            finally
                            {
                                conn.Close();
                                con.Close();
                                BookGridView.DataSource = null;
                                LoadAllCustomer();
                            }
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generated " + ex);
            }
            finally
            {
                con.Close();
                BookGridView.DataSource = null;
                LoadAllCustomer();
            }
        }
    }
}

