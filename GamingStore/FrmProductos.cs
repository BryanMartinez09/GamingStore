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
  
    public partial class FrmProductos : Form
    {
        List<Producto> _listado = null;
        public FrmProductos()
        {
            InitializeComponent();
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listado = ProductoBL.Instance.SelectAll();
            dgvProducto.DataSource = _listado;

            //dgvCargo.DataSource = _listado;
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
    }
}
