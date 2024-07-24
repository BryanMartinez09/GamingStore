using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinesLogic;
using DataAccessStore;
using GamingEntities;
using GamingEntities.Entities;

namespace GamingStore
{
    public partial class FrmCargo : Form
    {
        List<Cargo> _listado = null;
        public FrmCargo()
        {
            InitializeComponent();
        }

        private void FrmCargo_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listado = CargoBL.Instance.SelectAll();
            dgvCargo.DataSource = _listado;
            
            //dgvCargo.DataSource = _listado;
        }

        private void dgvCargo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
