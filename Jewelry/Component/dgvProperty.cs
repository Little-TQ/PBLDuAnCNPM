using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Jewelry
{
    public partial class dgvProperty : UserControl
    {
        public dgvProperty()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // dgvProperty
            // 
            this.Name = "dgvProperty";
            this.Load += new System.EventHandler(this.dgvProperty_Load);
            this.ResumeLayout(false);

        }

        private void dgvProperty_Load(object sender, EventArgs e)
        {

        }
    }
}
