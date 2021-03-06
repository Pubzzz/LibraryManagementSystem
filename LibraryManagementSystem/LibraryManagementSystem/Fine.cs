﻿using System;
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
    public partial class Fine : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True");
        SqlDataAdapter DA;
        DataSet DS = null;
        BindingSource bindingSource1 = new BindingSource();
        public Fine()
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
                string qry = "Select * from Payment ";
               
                DA = new SqlDataAdapter(qry, con);

                DA.Fill(DS, "Payment");
                bindingSource1.DataSource = DS.Tables["Payment"];
                PaymentsGridView.DataSource = bindingSource1;
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
        private void btn_calculate_Click(object sender, EventArgs e)
        {

        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            System.Random rand = new System.Random((int)System.DateTime.Now.Ticks);
            int random = rand.Next(1, 1000000);

            using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; Initial Catalog = LibDB; Integrated Security = True"))
            {
                using (SqlCommand cmd = new SqlCommand("spInsertPayments", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@LoanId", SqlDbType.VarChar).Value = random;
                    cmd.Parameters.Add("@BorrowerID", SqlDbType.VarChar).Value = txt_BID.Text;
                    cmd.Parameters.Add("@payment", SqlDbType.VarChar).Value = txt_Payment.Text;
                    cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd MMMM, yyyy");

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Transaction Successful");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occured : " + ex);
                    }
                    finally
                    {
                        conn.Close();
                        con.Close();
                        PaymentsGridView.DataSource = null;
                        LoadAllCustomer();
                    }
                }
            }
            con.Close();
        }
    }
}
