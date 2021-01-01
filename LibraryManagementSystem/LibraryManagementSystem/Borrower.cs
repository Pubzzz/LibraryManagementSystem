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
    public partial class Borrower : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();
        public Borrower()
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
                string qry = "Select * from Borrower";

                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "Borrower");
                bindingSource1.DataSource = DS.Tables["Borrower"];
                BorrowerGridView.DataSource = bindingSource1;
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
            string query = "SELECT * FROM Borrower where BID='" + txt_BorrowerID.Text + "' ";
            SqlCommand comd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(comd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if (DS.Rows.Count == 1)
                {
                    MessageBox.Show("This Borrower already exists ");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("spInsertBorrowers", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@BID", SqlDbType.VarChar).Value = txt_BorrowerID.Text;
                            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = txt_Name.Text;
                            cmd.Parameters.Add("@contact", SqlDbType.VarChar).Value = txt_ContactNo.Text;
                            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = txt_Address.Text;
                            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = txt_Email.Text;

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
                                BorrowerGridView.DataSource = null;
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
            /*string query = "SELECT * FROM Borrower where BID='" + txt_BorrowerID.Text + "' ";
            SqlCommand comd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(comd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if (DS.Rows.Count == 1)
                {
                    MessageBox.Show("This Borrower already exists ");
                }
                else
                {
                    string qury = "INSERT INTO Borrower VALUES ('" + txt_BorrowerID.Text + "','" + txt_Name.Text + "','" + txt_ContactNo.Text + "','" + txt_Address.Text + "','" + txt_Email.Text + "')";
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
                        BorrowerGridView.DataSource = null;
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
            }*/
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string name = "";
            string cont = "";
            string add = "";
            string mail = "";

            string qrey = "UPDATE Borrower SET Name=@name, Contact=@cont, Address=@add,Email=@mail Where BID= @ID";
            SqlCommand comd = new SqlCommand(qrey, con);
            try
            {
                con.Open();
                DataTable Dt = new DataTable();
                BorrowerGridView.DataSource = bindingSource1;

                foreach (DataGridViewRow row in BorrowerGridView.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString().Equals(txt_BorrowerID.Text))
                        {
                            DataRow dr = Dt.NewRow();

                            name = row.Cells[1].Value.ToString();
                            cont = row.Cells[2].Value.ToString();
                            add = row.Cells[3].Value.ToString();
                            mail = row.Cells[4].Value.ToString();
                            break;
                        }
                    }
                }

                if (txt_Name.Text != null && txt_Name.Text != String.Empty)
                {
                    name = txt_Name.Text;
                }

                if (txt_ContactNo.Text != null && txt_ContactNo.Text != String.Empty)
                {
                    cont = txt_ContactNo.Text;
                }

                if (txt_Address.Text != null && txt_Address.Text != String.Empty)
                {
                    add = txt_Address.Text;
                }
                if (txt_Email.Text != null && txt_Email.Text != String.Empty)
                {
                    mail = txt_Email.Text;
                }

                comd.Parameters.AddWithValue("@name", name);
                comd.Parameters.AddWithValue("@cont", cont);
                comd.Parameters.AddWithValue("@add", add);
                comd.Parameters.AddWithValue("@mail", mail);
                comd.Parameters.AddWithValue("@ID", txt_BorrowerID.Text);

                comd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generated " + ex);
            }
            finally
            {
                con.Close();
                BorrowerGridView.DataSource = null;
                LoadAllCustomer();
            }
             
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string qry = "DELETE FROM Borrower WHERE BID='" + txt_BorrowerID.Text + "'";
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
                BorrowerGridView.DataSource = null;
                LoadAllCustomer();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_BorrowerID.Text = "";
            txt_Name.Text = "";
            txt_ContactNo.Text = "";
            txt_Address.Text = "";
            txt_Email.Text = "";
            txt_Search.Text = "";
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string query = "Select * from Borrower where BID ='" + txt_Search.Text + "'";
            SqlDataAdapter DA = new SqlDataAdapter(query, con);

            DataSet DS = new DataSet();
            DA.Fill(DS, "Borrower");
            bindingSource1.DataSource = DS.Tables["Borrower"];
            BorrowerGridView.DataSource = bindingSource1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Search.Text = "";
            LoadAllCustomer();
        }
    }
}
