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
    public partial class FrmEmpleado : Form
    {
        List<Empleado> _listado = null;
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listado = EmpleadoBL.Instance.SelectAll();
            dgvEmpleado.DataSource = _listado;
        }
    }
}
