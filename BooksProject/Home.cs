using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksProject
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        string ISBN = "";
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            if (txtISBN.Text != "" && txtBTitle.Text != "" && txtBTitle.Text != "" && txtPrice.Text != "" && txtQtity.Text != "")
            {
                string isbn = txtISBN.Text;
                string title = txtBTitle.Text;
                string author = txtAuthor.Text;
                string price = txtPrice.Text;
                string qun = txtQtity.Text;

                ShowInfor sh = new ShowInfor(isbn, title, author, price, qun);

                sh.ShowDialog();
            }
            else
            {
                MessageBox.Show("no selected row ");
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            showData();
        }
        void showData()
        {
            string sql = "select * from Book";
            DataTable booktb = Database.GetDataTable(sql);
            dataGridView1.DataSource = booktb;
        }
        private void TxtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
               
                e.Handled = true;
            }
        }

        private void TxtQtity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
               
                e.Handled = true;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            if (txtISBN.Text != "" && txtBTitle.Text != "" && txtBTitle.Text != "" && txtPrice.Text != "" && txtQtity.Text != "")
            {

                string isbn = txtISBN.Text;
                string title = txtBTitle.Text;
                string author = txtAuthor.Text;
                double price = Convert.ToDouble(txtPrice.Text);
                double qun = Convert.ToDouble(txtQtity.Text);
                string sql = "INSERT into Book VALUES ('" + isbn + "','" + title + "','" + author + "'," + price + "," + qun + ")";
                int rows = Database.InsertUpdateDelete(sql);
                if (rows != 0)
                {
                    MessageBox.Show("Inserted successfully");
                    showData();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("fill all the field");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (ISBN != "")
            {
                if (txtISBN.Text != "" && txtBTitle.Text != "" && txtBTitle.Text != "" && txtPrice.Text != "" && txtQtity.Text != "")
                {
                    string isbn = txtISBN.Text;
                    string title = txtBTitle.Text;
                    string author = txtAuthor.Text;
                    double price = Convert.ToDouble(txtPrice.Text);
                    double qun = Convert.ToDouble(txtQtity.Text);
                    string sql = "UPDATE   Book SET " +
                        "ISBN =  '" + isbn + "',BookTitle = '" + title + "',AuthorName = '" + author + "',Price = " + price + ",Quantity= " + qun + " WHERE ISBN ='" + ISBN + "'";
                    int rows = Database.InsertUpdateDelete(sql);
                    if (rows != 0)
                    {
                        MessageBox.Show("updated successfully");
                        showData();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
                else
                {
                    MessageBox.Show("fill all the fields");
                }
            }
            else
            {
                MessageBox.Show("no selected row ");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

            if (ISBN != "")
            {
                string sql = "DELETE FROM Book WHERE ISBN ='" + ISBN + "'";
                int rows = Database.InsertUpdateDelete(sql);
                if (rows != 0)
                {
                    MessageBox.Show("delete successfully"+rows);
                    showData();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("no selected row ");
            }
            
        }

        private void DataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtISBN.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ISBN = txtISBN.Text;
            txtBTitle.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtAuthor.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPrice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtQtity.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.Show();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.Show();
        }
    }
}
