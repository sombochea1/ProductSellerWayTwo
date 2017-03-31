using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProductSellerWayTwo
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        List<Product> list = new List<Product>();

        public Main(List<Product> list):this()
        {
            this.list = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                int id = AutoId.Id;
                string pname = txtPname.Text;
                int qty = int.Parse(txtQty.Text);
                double uprice = double.Parse(txtPrice.Text);

                Product product = new Product(id, pname, qty, uprice);

                list.Add(product);
                listView.Items.Add(product.item());

                AutoId.Id++;

                txtID.Text = AutoId.Id + "";
            }
            catch (Exception)
            {
                //Do something
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ViewProducts(list).Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if(list.Count > 0)
            {
                foreach (Product temp in list)
                {
                    listView.Items.Add(temp.item());
                    AutoId.GetLastId = temp.Id;
                }
            } else
            {
                AutoId.GetLastId = 0;
                AutoId.Id = 1;
            }

            if (AutoId.Id == AutoId.GetLastId)
                AutoId.Id++;
            else
                AutoId.Id = AutoId.GetLastId + 1;

            txtID.Text = AutoId.Id + "";
        }
    }
}
