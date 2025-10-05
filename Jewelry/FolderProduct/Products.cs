//using Jewelry.BLL;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Jewelry.FolderProduct
//{
//    public partial class Products : UserControl
//    {
//        private ProductBLL productBLL = new ProductBLL();
//        public Products()
//        {
//            InitializeComponent();
//        }
//        private void Products_Load(object sender, EventArgs e)
//        {
//            LoadProducts();
//        }

//        private void panelAdd_Click(object sender, EventArgs e)
//        {
//            Product_Add frm = new Product_Add();
//            frm.ShowDialog();
//        }

//        public void LoadProducts()
//        {
//            dgvProduct.DataSource = productBLL.GetAllProducts();


//            //Auto resize columns to fit content
//            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
//            dgvProduct.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

//            dgvProduct.RowTemplate.Height = 40;

//            dgvProduct.ScrollBars = ScrollBars.Both;

//            lblTotal.Text = "Total Product: " + dgvProduct.Rows.Count.ToString();
//            dgvProduct.ClearSelection();
//        }

//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            Product_Add product_Add = new Product_Add(this);
//            product_Add.ShowDialog();
//        }

//        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {

//        }

       
//    }

//}

