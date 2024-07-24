using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using BarcodeStandard;

namespace GamingStore
{
    public partial class FrmAddProduct : Form
    {
        int id = 0;
        public FrmAddProduct()
        {
            InitializeComponent();
            UpdateCombo();
        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {
            
        }
        public void UpdateCombo()
        {

        }
    }
}
