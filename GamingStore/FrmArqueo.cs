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
    public partial class FrmArqueo : Form
    {
        List<Arqueo> _listado = null;
        public FrmArqueo()
        {
            InitializeComponent();
        }

        private void FrmArqueo_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listado = ArqueoBL.Instance.SelectAll();
            dgvArqueo.DataSource = _listado;
        }
    }
}
