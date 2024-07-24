using BussinesLogic;
using GamingEntities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GamingStore
{
    public partial class FrmProveedor : Form
    {
        List<Proveedor> _listado = null;
        public FrmProveedor()
        {
            InitializeComponent();
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listado = ProveedorBL.Instance.SelectAll();
            dgvProveedor.DataSource = _listado;

            //dgvCargo.DataSource = _listado;
        }
    }
}
