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
            List<string> LoanIdlist = new List<string>();

            string qry = "SELECT LoanID from Loan";
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LoanIdlist.Add(reader.GetInt32(0).ToString());

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

            foreach (string loanId in LoanIdlist)
            {
                using (SqlCommand cmmd = new SqlCommand("spNotReturnedBookLoanID", con))
                {
                    cmmd.CommandType = CommandType.StoredProcedure;

                    cmmd.Parameters.Add("@loanId", SqlDbType.VarChar).Value = loanId;

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                        DataSet DS = new DataSet();
                        DA.Fill(DS, "Delayed");
                        bindingSource1.DataSource = DS.Tables["Delayed"];
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
            }*/
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
