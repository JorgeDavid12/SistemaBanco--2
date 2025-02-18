using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmCuentas : Form
    {
        public FrmCuentas()
        {
            InitializeComponent();
        }

        public void MtdMostrarCuentas()
        {
            CDCuentas cd_cuentas = new CDCuentas();
            DataTable dtMostrarCuentas = cd_cuentas.MtMostrarCuentas();
            dgvClientes.DataSource = dtMostrarCuentas;
        }

        private void FrmCuentas_Load(object sender, EventArgs e)
        {
            MtdMostrarCuentas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CDCuentas cD_Cuentas = new CDCuentas();

            try
            {
                cD_Cuentas.CP_mtdAgregarCuentas(txtCodigoClientes.Text, txtNumeroC.Text, cboxTipoC.Text, decimal.Parse(txtSaldo.Text), DateTime.Parse(txtFechaApertura.Text), cboxEstado.Text);
                MtdMostrarCuentas();
                MessageBox.Show("El Cliente se agrego con exito", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoCuentas.Text = dgvClientes.SelectedCells[0].Value.ToString();
            txtCodigoClientes.Text = dgvClientes.SelectedCells[1].Value.ToString();
            txtNumeroC.Text = dgvClientes.SelectedCells[2].Value.ToString();
            cboxTipoC.Text = dgvClientes.SelectedCells[3].Value.ToString();
            txtSaldo.Text = dgvClientes.SelectedCells[4].Value.ToString();
            txtFechaApertura.Text = dgvClientes.SelectedCells[5].Value.ToString();
            cboxEstado.Text = dgvClientes.SelectedCells[6].Value.ToString();
        }
    }
}
