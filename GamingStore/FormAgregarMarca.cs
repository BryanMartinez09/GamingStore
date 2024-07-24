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
using GamingEntities.Entities;

namespace GamingStore
{
    public partial class FormAgregarMarca : Form
    {
        int id = 0;
        public FormAgregarMarca()
        {
            InitializeComponent();
            UpdateGrid();
        }

        //Edit
        public FormAgregarMarca(Marca entity)
        {
            InitializeComponent();
            UpdateGrid();
            textBoxNombre.Text = entity.Nombre;
            comboBoxEstadoId.SelectedValue = entity.EstadoId;
            id = entity.MarcaId;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxNombre.Text == "")
            {
                errorProvider1.SetError(textBoxNombre, "El campo es requerido");
                return;
            }
            errorProvider1.Clear();

            Marca entity = new Marca()
            {
                Nombre = textBoxNombre.Text.Trim(),
                EstadoId = (int)comboBoxEstadoId.SelectedValue
            };

            if (MarcaBL.Instance.Insert(entity))
            {
                MessageBox.Show("El registro se almaceno con exito!", "COnfirmacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al guarda el registro", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();

        }



        private void UpdateGrid()
        {
            comboBoxEstadoId.DisplayMember = "Nombre";
            comboBoxEstadoId.ValueMember = "EstadoId";
            comboBoxEstadoId.DataSource = EstadoBL.Instance.SelectAll();
        }

        private void FormAgregarMarca_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
