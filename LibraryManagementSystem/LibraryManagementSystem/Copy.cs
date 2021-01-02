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
    public partial class Copy : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();
        public Copy()
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
                string qry = "Select * from Copy";

                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "Copy");
                bindingSource1.DataSource = DS.Tables["Copy"];
                CopyGridView.DataSource = bindingSource1;
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

        private void btn_Library_Click(object sender, EventArgs e)
        {
            Library one = new Library();
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
            Author one = new Author();
            this.Hide();
            one.Show();
        }

        private void btn_Borrower_Click(object sender, EventArgs e)
        {
            Borrower one = new Borrower();
            this.Hide();
            one.Show();
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            Copy one = new Copy();
            this.Hide();
            one.Show();
        }

        private void btn_Loan_Click(object sender, EventArgs e)
        {
            Loan one = new Loan();
            this.Hide();
            one.Show();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

            string Avail = "Available";
            if (no.Checked)
            {
                Avail = "Not Available";
            }
            string qry = "SELECT * FROM Book where ISBN='" + txt_ISBN.Text + "' ";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if(DS.Rows.Count == 0)
                {
                    MessageBox.Show("This is not a registered book at the library");
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex);
            }
            finally
            {
                con.Close();
                LoadAllCustomer();
            }

            string query = "SELECT * FROM Copy where CopyID='" + txt_CopyID.Text + "' ";
            SqlCommand comd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter DoA = new SqlDataAdapter(comd);
                DataTable DoS = new DataTable();
                DoA.Fill(DoS);

                if (DoS.Rows.Count == 1)
                {
                    MessageBox.Show("This CopyID is taken ");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
                    {
                        using (SqlCommand cmmd = new SqlCommand("spInsertCopy", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@copyId", SqlDbType.VarChar).Value = txt_CopyID.Text;
                            cmd.Parameters.Add("@Availability", SqlDbType.VarChar).Value = Avail;
                            cmd.Parameters.Add("@pPrice", SqlDbType.VarChar).Value = txt_PurchasePrice.Text;
                            cmd.Parameters.Add("@sPrice", SqlDbType.VarChar).Value = txt_SellingPrice.Text;
                            cmd.Parameters.Add("@isbn", SqlDbType.VarChar).Value = txt_ISBN.Text;
                            

                            try
                            {
                                conn.Open();
                                cmmd.ExecuteNonQuery();
                                MessageBox.Show("Record added successfuly");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error occured : " + ex);
                            }
                            finally
                            {
                                conn.Close();
                                con.Close();
                                CopyGridView.DataSource = null;
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

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string query = "Select * from Copy where ISBN ='" + txt_Search.Text + "'";
            SqlDataAdapter DA = new SqlDataAdapter(query, con);

            DataSet DS = new DataSet();
            DA.Fill(DS, "Book");
            bindingSource1.DataSource = DS.Tables["Book"];
            CopyGridView.DataSource = bindingSource1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Search.Text = "";
            LoadAllCustomer();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Copy where CopyID='" + txt_CopyID.Text + "' ";
            SqlCommand comd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(comd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if (DS.Rows.Count == 0)
                {
                    MessageBox.Show("No record found.");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteCopies", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@copyId", SqlDbType.VarChar).Value = txt_CopyID.Text;

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
                                CopyGridView.DataSource = null;
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
            txt_CopyID.Text = "";
            yes.Checked = false;
            no.Checked = false;
            txt_PurchasePrice.Text = "";
            txt_SellingPrice.Text = "";
            txt_ISBN.Text = "";
            txt_Search.Text = "";
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string Avail = "";
            string Pp = "";
            string Sp = "";
            string Isbn = "";

            string query = "SELECT * FROM Copy where CopyID='" + txt_CopyID.Text + "' ";
            SqlCommand comd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(comd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if (DS.Rows.Count == 0)
                {
                    MessageBox.Show("No record found.");
                }
                else
                {
                    DataTable Dt = new DataTable();
                    CopyGridView.DataSource = bindingSource1;

                    foreach (DataGridViewRow row in CopyGridView.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            if (row.Cells[0].Value.ToString().Equals(txt_CopyID.Text))
                            {
                                DataRow dr = Dt.NewRow();

                                Avail = row.Cells[1].Value.ToString();
                                Pp = row.Cells[2].Value.ToString();
                                Sp = row.Cells[3].Value.ToString();
                                Isbn = row.Cells[4].Value.ToString();
                                break;
                            }
                        }
                    }

                    if (yes.Checked)
                    {
                        Avail = "Available";
                    }
                    else
                    {
                        Avail = "Not Available";
                    }

                    if (txt_PurchasePrice.Text != null && txt_PurchasePrice.Text != String.Empty)
                    {
                        Pp = txt_PurchasePrice.Text;
                    }

                    if (txt_SellingPrice.Text != null && txt_SellingPrice.Text != String.Empty)
                    {
                        Sp = txt_SellingPrice.Text;
                    }
                    if (txt_ISBN.Text != null && txt_ISBN.Text != String.Empty)
                    {
                        Isbn = txt_ISBN.Text;
                    }

                    using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateCopies", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@copyId", SqlDbType.VarChar).Value = txt_CopyID.Text;
                            cmd.Parameters.Add("@Availability", SqlDbType.VarChar).Value = Avail;
                            cmd.Parameters.Add("@pPrice", SqlDbType.VarChar).Value = Pp;
                            cmd.Parameters.Add("@sPrice", SqlDbType.VarChar).Value = Sp;
                            cmd.Parameters.Add("@isbn", SqlDbType.VarChar).Value = Isbn;

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
                                CopyGridView.DataSource = null;
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
                CopyGridView.DataSource = null;
                LoadAllCustomer();
            }
        }
    }
}
