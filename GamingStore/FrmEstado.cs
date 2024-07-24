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
    public partial class FrmEstado : Form
    {
        List<Estado> _listado = null;

        public FrmEstado()
        {
            InitializeComponent();
        }

        private void FrmEstado_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listado = EstadoBL.Instance.SelectAll();
            dgvEstado.DataSource = _listado;
        }

    }
}
