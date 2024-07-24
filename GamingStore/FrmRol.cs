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
    public partial class FrmRol : Form
    {
        List<Rol> _listado = null;
        public FrmRol()
        {
            InitializeComponent();
        }

        private void FrmRol_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listado = RolBL.Instance.SelectAll();
            dgvRol.DataSource = _listado;
        }
    }
}
