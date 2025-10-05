using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design.Serialization;
using Jewelry.Account;
using Jewelry.FolderProduct;
namespace Jewelry
{
    public partial class Page_Account : Form
    {
        public Page_Account()
        {
            InitializeComponent();
        }
        private void LoadUserControl(UserControl uc)
        {
            pnlContainer.Controls.Clear();     
            uc.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(uc);     
        }
        private void Account_Load(object sender, EventArgs e)
        {
            LoadUserControl(new General());
        }
        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNAccount.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            homeToolStripMenuItem.BackColor = Color.Transparent;
            homeToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new General());

        }
        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNAccount.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            accountToolStripMenuItem.BackColor = Color.Transparent;
            accountToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new ManageAccount());
        }
        private void paymentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in mstNAccount.Items)
            {
                item.BackColor = Color.Transparent;
                item.ForeColor = Color.Black;
            }

            paymentToolStripMenuItem.BackColor = Color.Transparent;
            paymentToolStripMenuItem.ForeColor = Color.Red;
            LoadUserControl(new Provide_Permission());
        }
        
        private void btnExitAccount_Click(object sender, EventArgs e)
        {
            Application.Exit();  
        }

        //Transfer another form
        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashBoard frm = new DashBoard();
            this.Hide();
            frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void overviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Page_Overview frm = new Page_Overview();
            this.Hide();
            frm.ShowDialog();
        }

        private void productToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Product_View frm = new Product_View();
            this.Hide();
            frm.ShowDialog();
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Customer frm= new Customer();
            this.Hide();
            frm.ShowDialog();
        }

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Employee frm = new Employee();
            this.Hide();
            frm.ShowDialog();
        }

        private void wareHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Invoice frm = new Invoice();
            this.Hide();
            frm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdatePrice frm = new UpdatePrice();
            this.Hide();
            frm.ShowDialog();
        }
        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Sale_Select frm = new Payment_Sale_Select();
            this.Hide();
            frm.ShowDialog();
        }
        private void paymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void repurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_Repurchase_Select frm = new Payment_Repurchase_Select();
            this.Hide();
            frm.ShowDialog();
        }

        private void preOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment_PreOrder_Select frm = new Payment_PreOrder_Select();
            this.Hide();
            frm.ShowDialog();
        }
    }
}
