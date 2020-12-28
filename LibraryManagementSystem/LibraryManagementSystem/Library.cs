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
    public partial class Library : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();
        public Library()
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
                string qry = "Select * from Library";

                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "Library");
                bindingSource1.DataSource = DS.Tables["Library"];
                LibraryGridView.DataSource = bindingSource1;
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
            string type = "Main";
            if (radioButton2.Checked)
            {
                type = "Branch";
            }

            string query = "SELECT * FROM Library where LibID='" + txt_LibraryID.Text + "' ";
            SqlCommand comd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataAdapter DA = new SqlDataAdapter(comd);
                DataTable DS = new DataTable();
                DA.Fill(DS);

                if (DS.Rows.Count == 1)
                {
                    MessageBox.Show("This Library has already been registered");
                }
                else
                {
                    string qury = "INSERT INTO Library VALUES ('" + txt_LibraryID.Text + "','" + txt_LibraryName.Text + "','" + type + "','" + txt_Admin.Text + "','" + txt_ContactNo.Text + "','" + txt_Address.Text + "')";
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
                        LibraryGridView.DataSource = null;
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
            string qry = "DELETE FROM Library WHERE LibID='" + txt_LibraryID.Text + "'";
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
                LibraryGridView.DataSource = null;
                LoadAllCustomer();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {

            txt_LibraryID.Text = "";
            txt_LibraryName.Text = "";
            txt_Admin.Text = "";
            txt_ContactNo.Text = "";
            txt_Address.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_Search.Text = "";
            LoadAllCustomer();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string query = "Select * from Library where LibID ='" + txt_Search.Text + "'";
            SqlDataAdapter DA = new SqlDataAdapter(query, con);

            DataSet DS = new DataSet();
            DA.Fill(DS, "Library");
            bindingSource1.DataSource = DS.Tables["Library"];
            LibraryGridView.DataSource = bindingSource1;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string LName = "";
            string type = "";
            string admin = "";
            string contact = "";
            string address = "";


            string qry = "UPDATE Library SET Name=@LName, Type=@type, Administrator=@admin,Contact=@contact,Address=@address Where LibID= @LID";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                DataTable Dt = new DataTable();
                LibraryGridView.DataSource = bindingSource1;

                foreach (DataGridViewRow row in LibraryGridView.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (row.Cells[0].Value.ToString().Equals(txt_LibraryID.Text))
                        {
                            DataRow dr = Dt.NewRow();

                            LName = row.Cells[1].Value.ToString();
                            type = row.Cells[2].Value.ToString();
                            admin = row.Cells[3].Value.ToString();
                            contact = row.Cells[4].Value.ToString();
                            address = row.Cells[5].Value.ToString();
                            break;
                        }
                    }
                }

                if (txt_LibraryName.Text != null && txt_LibraryName.Text != String.Empty)
                {
                    LName = txt_LibraryName.Text;
                }

                if (radioButton1.Checked)
                {
                    type = "Main";
                }
                else
                {
                    type = "Branch";
                }
                if (txt_Admin.Text != null && txt_Admin.Text != String.Empty)
                {
                    admin = txt_Admin.Text;
                }

                if (txt_ContactNo.Text != null && txt_ContactNo.Text != String.Empty)
                {
                    contact = txt_ContactNo.Text;
                }
                if (txt_Address.Text != null && txt_Address.Text != String.Empty)
                {
                    address = txt_Address.Text;
                }
                cmd.Parameters.AddWithValue("@LName", LName);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@admin", admin);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@LID", txt_LibraryID.Text);

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
                LibraryGridView.DataSource = null;
                LoadAllCustomer();
            }
        }
    }
}
