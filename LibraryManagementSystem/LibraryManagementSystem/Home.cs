using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            Home one = new Home();
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
            Author two = new Author();
            this.Hide();
            two.Show();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            Login two = new Login();
            this.Hide();
            two.Show();
        }

        private void btn_Library_Click(object sender, EventArgs e)
        {
            Library two = new Library();
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
    }
}
