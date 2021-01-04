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
    public partial class Loan : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();
        public Loan()
        {
            InitializeComponent();
            LoadAllCustomer();
            CheckOverdue();
        }
        private void LoadAllCustomer()
        {
            try
            {
                DS = new DataSet();
                bindingSource1.DataSource = null;

                con.Open();
                string qry = "Select * from Loan";

                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "Loan");
                bindingSource1.DataSource = DS.Tables["Loan"];
                LoanGridView.DataSource = bindingSource1;
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
        private void btn_Add_Click(object sender, EventArgs e)
        {
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 100000000);

            bool isBorrowerExist = true;
            bool isCopyExist = true;


            txt_LendingDate.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            txt_ReturnedDate.Text = DateTime.Now.AddDays(14).ToString("dd MMMM, yyyy");

            string qry = "SELECT * FROM Borrower where BID='" + txt_BorrowerID.Text + "' ";
            SqlCommand comd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(comd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if (DS.Rows.Count == 0)
                {
                    isBorrowerExist = false;
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

            if (isBorrowerExist)
            {
                string qery = "SELECT * FROM Copy where CopyID='" + txt_CopyID.Text + "' ";
                SqlCommand cmmmd = new SqlCommand(qery, con);
                try
                {
                    con.Open();
                    SqlDataAdapter DA = new SqlDataAdapter(cmmmd);
                    DataTable DS = new DataTable();
                    DA.Fill(DS);

                    if (DS.Rows.Count == 0)
                    {
                        isCopyExist = false;
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


                if (isCopyExist)
                {
                    string query = "SELECT * FROM Loan where LoanID='" + txt_LoanID.Text + "' ";
                    SqlCommand cmmd = new SqlCommand(query, con);

                    try
                    {
                        con.Open();
                        SqlDataAdapter DA = new SqlDataAdapter(cmmd);
                        DataTable DS = new DataTable();
                        DA.Fill(DS);

                        if (DS.Rows.Count == 1)
                        {
                            MessageBox.Show("This Loan ID is already used");
                        }
                        else
                        {
                            using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
                            {
                                using (SqlCommand cmd = new SqlCommand("spInsertLoans", conn))
                                {
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    cmd.Parameters.Add("@loanId", SqlDbType.VarChar).Value = random;
                                    cmd.Parameters.Add("@copyId", SqlDbType.VarChar).Value = txt_CopyID.Text;
                                    cmd.Parameters.Add("@BID", SqlDbType.VarChar).Value = txt_BorrowerID.Text;
                                    cmd.Parameters.Add("@LDate", SqlDbType.VarChar).Value = txt_LendingDate.Text;
                                    cmd.Parameters.Add("@RDate", SqlDbType.VarChar).Value = txt_ReturnedDate.Text;

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
                                        LoanGridView.DataSource = null;
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
                else
                {
                    MessageBox.Show("This CopyID does not exist");
                }
            }
            else
            {
                MessageBox.Show("This borrower is not a registered user");
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string CID = "";
            string BID = "";
            string Ldate = "";
            string Rdate = "";

            string query = "SELECT * FROM Loan where LoanID='" + txt_LoanID.Text + "' ";
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
                    LoanGridView.DataSource = bindingSource1;

                    foreach (DataGridViewRow row in LoanGridView.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            if (row.Cells[0].Value.ToString().Equals(txt_LoanID.Text))
                            {
                                DataRow dr = Dt.NewRow();

                                CID = row.Cells[1].Value.ToString();
                                BID = row.Cells[2].Value.ToString();
                                Ldate = row.Cells[3].Value.ToString();
                                Rdate = row.Cells[4].Value.ToString();
                                break;
                            }
                        }
                    }
                    if (txt_CopyID.Text != null && txt_CopyID.Text != String.Empty)
                    {
                        CID = txt_CopyID.Text;
                    }

                    if (txt_BorrowerID.Text != null && txt_BorrowerID.Text != String.Empty)
                    {
                        BID = txt_BorrowerID.Text;
                    }

                    if (txt_LendingDate.Text != null && txt_LendingDate.Text != String.Empty)
                    {
                        Ldate = txt_LendingDate.Text;
                    }
                    if (txt_ReturnedDate.Text != null && txt_ReturnedDate.Text != String.Empty)
                    {
                        Rdate = txt_ReturnedDate.Text;
                    }

                    using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("spUpdateLoans", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@loanId", SqlDbType.VarChar).Value = txt_LoanID.Text;
                            cmd.Parameters.Add("@copyId", SqlDbType.VarChar).Value = CID;
                            cmd.Parameters.Add("@BID", SqlDbType.VarChar).Value = BID;
                            cmd.Parameters.Add("@LDate", SqlDbType.VarChar).Value = Ldate;
                            cmd.Parameters.Add("@RDate", SqlDbType.VarChar).Value = Rdate;

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
                                LoanGridView.DataSource = null;
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
                LoanGridView.DataSource = null;
                LoadAllCustomer();
            }

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Loan where LoanID='" + txt_LoanID.Text + "' ";
            SqlCommand comd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(comd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if (DS.Rows.Count == 0)
                {
                    MessageBox.Show("Lending details not found. ");
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
                    {
                        using (SqlCommand cmd = new SqlCommand("spDeleteLoans", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Add("@loanId", SqlDbType.VarChar).Value = txt_LoanID.Text;

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
                                LoanGridView.DataSource = null;
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
            txt_LoanID.Text = "";
            txt_CopyID.Text = "";
            txt_BorrowerID.Text = "";
            txt_LendingDate.Text = "";
            txt_ReturnedDate.Text = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            txt_search.Text = "";
            LoadAllCustomer();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string query = "Select * from Loan where LoanID ='" + txt_search.Text + "'";
            SqlDataAdapter DA = new SqlDataAdapter(query, con);

            DataSet DS = new DataSet();
            DA.Fill(DS, "Loan");
            bindingSource1.DataSource = DS.Tables["Loan"];
            LoanGridView.DataSource = bindingSource1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 one = new Form1();
            one.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fine one = new Fine();
            one.Show();
        }
        private void CheckOverdue()
        { 
                string qry = "SELECT * from Loan WHERE RDate < (CAST(GETDATE() AS DATE))";
                SqlCommand comd = new SqlCommand(qry, con);
                try
                {
                    con.Open();
                    SqlDataAdapter DA = new SqlDataAdapter(comd);
                    DataTable DS = new DataTable();
                    DA.Fill(DS);

                    if (DS.Rows.Count == 0)
                    {
                        MessageBox.Show("No Records Found");
                    }
                    else
                    {
                        string LID = "";
                        string BID = "";
                        string PaymentDue = "";
                        DateTime Rdate = new DateTime();
                        int NoOfDays = 0;

                        DataTable Dt = new DataTable();
                        LoanGridView.DataSource = bindingSource1;
                    foreach (DataGridViewRow row in LoanGridView.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {

                            DataRow dr = Dt.NewRow();

                            LID = row.Cells[0].Value.ToString();
                            BID = row.Cells[2].Value.ToString();
                            Rdate = DateTime.Parse(row.Cells[4].Value.ToString());
                        }


                        con.Close();
                        NoOfDays = (DateTime.Now.Date - Rdate.Date).Days;
                        PaymentDue = (15 * NoOfDays).ToString();

                        using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
                        {
                            using (SqlCommand cmd = new SqlCommand("spInsertOverdue", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.Add("@LoanId", SqlDbType.VarChar).Value = LID;
                                cmd.Parameters.Add("@BorrowerId", SqlDbType.VarChar).Value = BID;
                                cmd.Parameters.Add("@Days", SqlDbType.VarChar).Value = NoOfDays;
                                cmd.Parameters.Add("@Pay", SqlDbType.VarChar).Value =PaymentDue;

                                try
                                {
                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error occured : " + ex);
                                }
                                finally
                                {
                                    conn.Close();
                                    con.Close();
                                    
                                }
                            }
                        }
                        con.Close();
                    }
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
    }
}
