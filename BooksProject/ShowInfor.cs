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
    public partial class ShowInfor : Form
    {
        public ShowInfor()
        {
            InitializeComponent();
        }
        public ShowInfor(string i,string t,string a,string p, string q)
        {
            InitializeComponent();
            txtISBN.Text = i;
            txtPrice.Text = p;
            txtBTitle.Text = t;
            txtAuthor.Text = a;
            txtQtity.Text = q;
 
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowInfor_Load(object sender, EventArgs e)
        {

        }
    }
}
