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
            string query = "Select * from Book where ISBN ='" + txt_Search.Text + "'";
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
                    MessageBox.Show("This Book has been already registered ");
                }
                else
                {
                    string qury = "INSERT INTO Book VALUES ('" + txt_ISBN.Text + "','" + txt_Title.Text + "','" + txt_Author.Text + "','" + txt_NoCopies.Text + "','" + txt_Subject.Text + "')";
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
                        BookGridView.DataSource = null;
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

            string qry = "DELETE FROM Book WHERE ISBN='" + txt_ISBN.Text + "'";
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
                BookGridView.DataSource = null;
                LoadAllCustomer();
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


            string qry = "UPDATE Book SET Title=@Title, Author=@Author, Noofcopies=@Copies,Subject=@Sub Where ISBN= @ID";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
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

                cmd.Parameters.AddWithValue("@Title", Title);
                cmd.Parameters.AddWithValue("@Author", Author);
                cmd.Parameters.AddWithValue("@Copies", Copies);
                cmd.Parameters.AddWithValue("@Sub", Sub);
                cmd.Parameters.AddWithValue("@ID", txt_ISBN.Text);

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
                BookGridView.DataSource = null;
                LoadAllCustomer();
            }
        }
    }
}

