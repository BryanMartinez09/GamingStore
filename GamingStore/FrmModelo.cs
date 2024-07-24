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
    public partial class FrmModelo : Form
    {
        List<Modelo> _listado = null;
        public FrmModelo()
        {
            InitializeComponent();
        }

        private void FrmModelo_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listado = ModeloBL.Instance.SelectAll();
            dgvModelo.DataSource = _listado;

            //dgvCargo.DataSource = _listado;
        }
    }
}
