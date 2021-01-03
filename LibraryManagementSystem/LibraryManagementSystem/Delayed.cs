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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            LoadAllCustomer();
            CheckOverdue();
        }
        private void CheckOverdue()
        {/*
            using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
            {
                using (SqlCommand cmd = new SqlCommand("spNotReturnedBookLoanID", conn))
                {
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
            */

            string qry = "SELECT * from dbo.Loan WHERE CONVERT(DATE, RDate)  < CONVERT (DATE,GETDATE()) ";
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
                    string Rdate = "";
                    int NoOfDays = 0;

                    DataTable Dt = new DataTable();
                    OverdueGridView.DataSource = bindingSource1;
                    foreach (DataGridViewRow row in OverdueGridView.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {

                            DataRow dr = Dt.NewRow();

                            LID = row.Cells[0].Value.ToString();
                            BID = row.Cells[2].Value.ToString();
                            Rdate = row.Cells[4].Value.ToString();
                            break;

                        }
                    }


                    NoOfDays = (DateTime.Now.Date - DateTime.ParseExact(Rdate, "dd MMMM, yyyy",null)).Days;
                    PaymentDue = (15 * NoOfDays).ToString();

                    string qury = "INSERT INTO Overdue VALUES ('" + LID + "','" + BID + "','" + NoOfDays + "','" + PaymentDue + "')";
                    SqlCommand cmd = new SqlCommand(qury, con);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

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
            catch (Exception ex)
            {
                MessageBox.Show("Error occured : " + ex);
            }
            finally
            {
                con.Close();
                LoadAllCustomer();
            }
        }

        private void LoadAllCustomer()
        {
            try
            {
                DS = new DataSet();
                bindingSource1.DataSource = null;

                con.Open();
                string qry = "Select * from Overdue";

                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "Overdue");
                bindingSource1.DataSource = DS.Tables["Overdue"];
                OverdueGridView.DataSource = bindingSource1;
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            string query = "Select * from Overdue where LoanID ='" +txt_search.Text + "' ";
            SqlDataAdapter DA = new SqlDataAdapter(query, con);

            DataSet DS = new DataSet();
            DA.Fill(DS, "Overdue");
            bindingSource1.DataSource = DS.Tables["Overdue"];
            OverdueGridView.DataSource = bindingSource1;
        }
    }
}
