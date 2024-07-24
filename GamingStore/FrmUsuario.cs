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
    public partial class FrmUsuario : Form
    {

        List<Usuario> _listado = null;

        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid() 
        {
            _listado = UsuarioBL.Instance.SelectAll();
            dgvUsuario.DataSource = _listado;
        }
    }
}
