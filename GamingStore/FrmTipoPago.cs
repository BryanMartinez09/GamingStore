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
    public partial class FrmTipoPago : Form
    {
        List<TipoPago> _listado = null;

        public FrmTipoPago()
        {
            InitializeComponent();
        }

        private void FrmTipoPago_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listado = TipoPagoBL.Instance.SelectAll();
            dgvTipPago.DataSource = _listado;

        }
    }
}
