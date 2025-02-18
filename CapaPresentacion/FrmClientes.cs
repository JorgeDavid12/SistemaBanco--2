using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        /*    
        public void MtdMostrarClientes()
        {
            CD_Clientes cd_clientes = new CD_Clientes();
            DataTable dtClientes = cd_clientes.MtMostrarClientes();
            dgvClientes.DataSource = dtClientes;
        }
        */

        public void MtdMostrarClientes()
        {
            CD_Clientes cd_clientes = new CD_Clientes();
            DataTable dtMostrarClientes = cd_clientes.MtMostrarClientes();
            dgvClientes.DataSource = dtMostrarClientes;
        }

        private void mtdLimpiarTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = -1; 
                    ((ComboBox)c).Text = string.Empty; 
                }
                else if (c.HasChildren)
                {
                    mtdLimpiarTextBoxes(c);
                }
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            MtdMostrarClientes();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mtdLimpiarTextBoxes(this);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigoCliente.Text) || !int.TryParse(txtCodigoCliente.Text, out int codigo))
                {
                    MessageBox.Show("Ingrese un código de cliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CD_Clientes cp_classClientes = new CD_Clientes();

                //int codigo = int.Parse(txtCodigoCliente.Text);
                string nombre = txtNombres.Text;
                string Direccion = txtDireccion.Text;
                string Departamento = txtDepartamento.Text;
                string Pais = txtPais.Text;
                string categoria = cboxCategoria.Text;
                string Estado = cboxEstado.Text;

                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(Direccion) ||
            string.IsNullOrEmpty(Departamento) || string.IsNullOrEmpty(Pais) ||
            string.IsNullOrEmpty(categoria) || string.IsNullOrEmpty(Estado))
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de actualizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int vCantidadRegistros = cp_classClientes.CP_mtdActualizarClientes(codigo, nombre, Direccion, Departamento, Pais, categoria, Estado);
                MtdMostrarClientes();

                if (vCantidadRegistros > 0)
                {
                    MessageBox.Show("Registros Actualizado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MtdMostrarClientes();
                }
                else
                {
                    MessageBox.Show("No se encontró codigo!!", "Error actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex){ 
                MessageBox.Show(ex.StackTrace, "error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CD_Clientes cD_Clientes = new CD_Clientes();

            try
            {
                cD_Clientes.CP_mtdAgregarClientes(txtNombres.Text, txtDireccion.Text, txtDepartamento.Text, txtPais.Text, cboxCategoria.Text, cboxEstado.Text);
                MtdMostrarClientes();
                MessageBox.Show("El Cliente se agrego con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CD_Clientes cp_classClientes = new CD_Clientes();

            string codigo = txtCodigoCliente.Text;
            int vCantidadRegistros = cp_classClientes.CP_mtdEliminarClientes(codigo);
            MtdMostrarClientes();

            if (vCantidadRegistros > 0)
            {
                MessageBox.Show("Registro Eliminado!!", "Correcto!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontró codigo!!", "Error eliminacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
