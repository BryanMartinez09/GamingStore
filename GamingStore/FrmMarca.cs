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
    public partial class FormMarcas : Form
    {

        List<Estado> _listadoEstados;
        List<Marca> _listadoMarcas;
        public FormMarcas()
        {
            InitializeComponent();
        }



        private void FormMarcas_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listadoEstados = EstadoBL.Instance.SelectAll();
            _listadoMarcas = MarcaBL.Instance.SelectAll();

            var query = (from x in _listadoMarcas
                         join e in _listadoEstados on x.EstadoId equals e.EstadoId
                         select new
                         {
                             MarcaId = x.MarcaId,
                             Nombre = x.Nombre,
                             Estado = e.Nombre 
                                               //_listadoEstados.FirstOrDefault(e => e.EstadoId.Equals(x.EstadoId)).Nombre
                         }).ToList();
            dgvMarcas.DataSource = query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAgregarMarca frm = new FormAgregarMarca();
            frm.ShowDialog();
            UpdateGrid();
        }

        private void dgvMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMarcas.Rows[e.RowIndex].Cells["Editar"].Selected)
            {
                int id = (int)dgvMarcas.Rows[e.RowIndex].Cells["MarcaId"].Value;

                var entity = _listadoMarcas.FirstOrDefault(x => x.MarcaId.Equals(id));

                FormAgregarMarca frm = new FormAgregarMarca(entity);
                frm.ShowDialog();
                UpdateGrid();
            }
            else if (dgvMarcas.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = (int)dgvMarcas.Rows[e.RowIndex].Cells["MarcaId"].Value;

                DialogResult dr = MessageBox.Show("Realmente desea eliminar el registro?",
                    "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (MarcaBL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino el registro seleccionado?",
                    "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                UpdateGrid();
            }
        }
    }





    


}

