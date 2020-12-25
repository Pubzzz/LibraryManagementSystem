
namespace LibraryManagementSystem
{
    partial class Copy
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Loan = new System.Windows.Forms.Button();
            this.btn_Library = new System.Windows.Forms.Button();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.btn_Borrower = new System.Windows.Forms.Button();
            this.btn_Author = new System.Windows.Forms.Button();
            this.btn_Book = new System.Windows.Forms.Button();
            this.btn_Dashboard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_CopyID = new System.Windows.Forms.TextBox();
            this.txt_PurchasePrice = new System.Windows.Forms.TextBox();
            this.txt_NoCopies = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Search = new System.Windows.Forms.Button();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txt_SellingPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ISBN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.btn_Loan);
            this.panel1.Controls.Add(this.btn_Library);
            this.panel1.Controls.Add(this.btn_Copy);
            this.panel1.Controls.Add(this.btn_Borrower);
            this.panel1.Controls.Add(this.btn_Author);
            this.panel1.Controls.Add(this.btn_Book);
            this.panel1.Controls.Add(this.btn_Dashboard);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(1, 65);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 913);
            this.panel1.TabIndex = 7;
            // 
            // btn_Loan
            // 
            this.btn_Loan.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Loan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Loan.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Loan.Location = new System.Drawing.Point(11, 794);
            this.btn_Loan.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Loan.Name = "btn_Loan";
            this.btn_Loan.Size = new System.Drawing.Size(333, 62);
            this.btn_Loan.TabIndex = 19;
            this.btn_Loan.Text = "LOANS";
            this.btn_Loan.UseVisualStyleBackColor = false;
            this.btn_Loan.Click += new System.EventHandler(this.btn_Loan_Click);
            // 
            // btn_Library
            // 
            this.btn_Library.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Library.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Library.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Library.Location = new System.Drawing.Point(11, 178);
            this.btn_Library.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Library.Name = "btn_Library";
            this.btn_Library.Size = new System.Drawing.Size(333, 62);
            this.btn_Library.TabIndex = 18;
            this.btn_Library.Text = "LIBRARIES";
            this.btn_Library.UseVisualStyleBackColor = false;
            this.btn_Library.Click += new System.EventHandler(this.btn_Library_Click);
            // 
            // btn_Copy
            // 
            this.btn_Copy.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Copy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Copy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Copy.Location = new System.Drawing.Point(11, 671);
            this.btn_Copy.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(333, 62);
            this.btn_Copy.TabIndex = 15;
            this.btn_Copy.Text = "COPIES";
            this.btn_Copy.UseVisualStyleBackColor = false;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // btn_Borrower
            // 
            this.btn_Borrower.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Borrower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Borrower.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Borrower.Location = new System.Drawing.Point(11, 548);
            this.btn_Borrower.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Borrower.Name = "btn_Borrower";
            this.btn_Borrower.Size = new System.Drawing.Size(333, 62);
            this.btn_Borrower.TabIndex = 14;
            this.btn_Borrower.Text = "BORROWERS";
            this.btn_Borrower.UseVisualStyleBackColor = false;
            this.btn_Borrower.Click += new System.EventHandler(this.btn_Borrower_Click);
            // 
            // btn_Author
            // 
            this.btn_Author.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Author.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Author.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Author.Location = new System.Drawing.Point(11, 425);
            this.btn_Author.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Author.Name = "btn_Author";
            this.btn_Author.Size = new System.Drawing.Size(333, 62);
            this.btn_Author.TabIndex = 13;
            this.btn_Author.Text = "AUTHORS";
            this.btn_Author.UseVisualStyleBackColor = false;
            this.btn_Author.Click += new System.EventHandler(this.btn_Author_Click);
            // 
            // btn_Book
            // 
            this.btn_Book.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Book.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Book.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Book.Location = new System.Drawing.Point(11, 302);
            this.btn_Book.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Book.Name = "btn_Book";
            this.btn_Book.Size = new System.Drawing.Size(333, 62);
            this.btn_Book.TabIndex = 12;
            this.btn_Book.Text = "BOOKS";
            this.btn_Book.UseVisualStyleBackColor = false;
            this.btn_Book.Click += new System.EventHandler(this.btn_Book_Click);
            // 
            // btn_Dashboard
            // 
            this.btn_Dashboard.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Dashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Dashboard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Dashboard.Location = new System.Drawing.Point(11, 55);
            this.btn_Dashboard.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Dashboard.Name = "btn_Dashboard";
            this.btn_Dashboard.Size = new System.Drawing.Size(333, 62);
            this.btn_Dashboard.TabIndex = 11;
            this.btn_Dashboard.Text = "DASHBOARD";
            this.btn_Dashboard.UseVisualStyleBackColor = false;
            this.btn_Dashboard.Click += new System.EventHandler(this.btn_Dashboard_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(1, -1);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1847, 55);
            this.panel2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(747, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(422, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "LIBRARY MANAGEMENT SYSTEM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(479, 262);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "No of Copies";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(479, 320);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Purchase Price";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(480, 197);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Copy ID";
            // 
            // txt_CopyID
            // 
            this.txt_CopyID.Location = new System.Drawing.Point(707, 192);
            this.txt_CopyID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_CopyID.Multiline = true;
            this.txt_CopyID.Name = "txt_CopyID";
            this.txt_CopyID.Size = new System.Drawing.Size(465, 25);
            this.txt_CopyID.TabIndex = 24;
            // 
            // txt_PurchasePrice
            // 
            this.txt_PurchasePrice.Location = new System.Drawing.Point(707, 315);
            this.txt_PurchasePrice.Margin = new System.Windows.Forms.Padding(4);
            this.txt_PurchasePrice.Multiline = true;
            this.txt_PurchasePrice.Name = "txt_PurchasePrice";
            this.txt_PurchasePrice.Size = new System.Drawing.Size(465, 25);
            this.txt_PurchasePrice.TabIndex = 25;
            // 
            // txt_NoCopies
            // 
            this.txt_NoCopies.Location = new System.Drawing.Point(707, 257);
            this.txt_NoCopies.Margin = new System.Windows.Forms.Padding(4);
            this.txt_NoCopies.Multiline = true;
            this.txt_NoCopies.Name = "txt_NoCopies";
            this.txt_NoCopies.Size = new System.Drawing.Size(465, 25);
            this.txt_NoCopies.TabIndex = 26;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Controls.Add(this.btn_Search);
            this.panel3.Controls.Add(this.txt_Search);
            this.panel3.Location = new System.Drawing.Point(483, 586);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1267, 82);
            this.panel3.TabIndex = 27;
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.Location = new System.Drawing.Point(593, 22);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(100, 28);
            this.btn_Search.TabIndex = 25;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            // 
            // txt_Search
            // 
            this.txt_Search.Location = new System.Drawing.Point(39, 26);
            this.txt_Search.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Search.Multiline = true;
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(465, 24);
            this.txt_Search.TabIndex = 24;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.Location = new System.Drawing.Point(1167, 492);
            this.btn_Clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(100, 28);
            this.btn_Clear.TabIndex = 31;
            this.btn_Clear.Text = "CLEAR";
            this.btn_Clear.UseVisualStyleBackColor = true;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.Location = new System.Drawing.Point(1013, 492);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(100, 28);
            this.btn_Delete.TabIndex = 30;
            this.btn_Delete.Text = "DELETE";
            this.btn_Delete.UseVisualStyleBackColor = true;
            // 
            // btn_Update
            // 
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(860, 492);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(100, 28);
            this.btn_Update.TabIndex = 29;
            this.btn_Update.Text = "UPDATE";
            this.btn_Update.UseVisualStyleBackColor = true;
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(707, 492);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(100, 28);
            this.btn_Add.TabIndex = 28;
            this.btn_Add.Text = "ADD";
            this.btn_Add.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(483, 676);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1267, 302);
            this.dataGridView1.TabIndex = 32;
            // 
            // txt_SellingPrice
            // 
            this.txt_SellingPrice.Location = new System.Drawing.Point(707, 367);
            this.txt_SellingPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txt_SellingPrice.Multiline = true;
            this.txt_SellingPrice.Name = "txt_SellingPrice";
            this.txt_SellingPrice.Size = new System.Drawing.Size(465, 25);
            this.txt_SellingPrice.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(479, 372);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Selling Price";
            // 
            // txt_ISBN
            // 
            this.txt_ISBN.Location = new System.Drawing.Point(707, 426);
            this.txt_ISBN.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ISBN.Multiline = true;
            this.txt_ISBN.Name = "txt_ISBN";
            this.txt_ISBN.Size = new System.Drawing.Size(465, 25);
            this.txt_ISBN.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(480, 431);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 35;
            this.label6.Text = "ISBN No";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(376, 65);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1472, 55);
            this.panel4.TabIndex = 53;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(517, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "COPIES";
            // 
            // Copy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1824, 991);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.txt_ISBN);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_SellingPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txt_NoCopies);
            this.Controls.Add(this.txt_PurchasePrice);
            this.Controls.Add(this.txt_CopyID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(1842, 1038);
            this.MinimumSize = new System.Drawing.Size(1842, 1028);
            this.Name = "Copy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copy";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_CopyID;
        private System.Windows.Forms.TextBox txt_PurchasePrice;
        private System.Windows.Forms.TextBox txt_NoCopies;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_Borrower;
        private System.Windows.Forms.Button btn_Author;
        private System.Windows.Forms.Button btn_Book;
        private System.Windows.Forms.Button btn_Dashboard;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_SellingPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_ISBN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Loan;
        private System.Windows.Forms.Button btn_Library;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label7;
    }
}