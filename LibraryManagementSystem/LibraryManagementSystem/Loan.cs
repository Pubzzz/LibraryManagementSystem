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
            txt_LendingDate.Text = DateTime.Now.ToString("dd MMMM, yyyy");

            //CHECK WHETHER THE BID,CID AND LOAN ID ARE VALID EXCEPTIONS 

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
                    MessageBox.Show("This borrower is not a registered user");
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
                    MessageBox.Show("This CopyID does not exist");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generated : " + ex);
            }
            finally
            {
                con.Close();
            }

            string qury = "INSERT INTO Loan VALUES ('" + txt_LoanID.Text + "','" + txt_CopyID.Text + "','" + txt_BorrowerID.Text + "','" + txt_LendingDate.Text + "','" + txt_ReturnedDate.Text + "')";
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
                LoanGridView.DataSource = null;
                LoadAllCustomer();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string CID = "";
            string BID = "";
            string Ldate = "";
            string Rdate = "";


            string qry = "UPDATE Loan SET CopyID=@CID, BID=@BID, LDate=@Ldate,RDate=@Rdate Where LoanID= @LID";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
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

                cmd.Parameters.AddWithValue("@CID", CID);
                cmd.Parameters.AddWithValue("@BID", BID);
                cmd.Parameters.AddWithValue("@Ldate", Ldate);
                cmd.Parameters.AddWithValue("@Rdate", Rdate);
                cmd.Parameters.AddWithValue("@LID", txt_LoanID.Text);

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
                LoanGridView.DataSource = null;
                LoadAllCustomer();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string qry = "DELETE FROM Loan WHERE LoanID='" + txt_LoanID.Text + "'";
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
                LoanGridView.DataSource = null;
                LoadAllCustomer();
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
    }
}
