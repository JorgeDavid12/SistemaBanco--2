using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDCuentas
    {
        CD_Conexion conexion = new CD_Conexion();

        public DataTable MtMostrarCuentas()
        {
            string QryMostrarCuentas = "uspCuentasMostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarCuentas, conexion.MtdAbrirConexion());
            DataTable dtMostrarCuentas = new DataTable();
            adapter.Fill(dtMostrarCuentas);
            conexion.MtdCerrarConexion();
            return dtMostrarCuentas;
        }

        public void CP_mtdAgregarCuentas(string CodigoCliente, string NumeroCuenta, string TipoCuenta, decimal Saldo, DateTime FechaApertura, string Estado)
        {

            //string Usp_crear = "uspCuentasCrear";
            //SqlCommand cmd_InsertarCuentas = new SqlCommand(Usp_crear, conexion.MtdAbrirConexion());
            //cmd_InsertarCuentas.CommandType = CommandType.StoredProcedure;

            //cmd_InsertarCuentas.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
            //cmd_InsertarCuentas.Parameters.AddWithValue("@NumeroCuenta", NumeroCuenta);
            //cmd_InsertarCuentas.Parameters.AddWithValue("@TipoCuenta", TipoCuenta);
            //cmd_InsertarCuentas.Parameters.AddWithValue("@Saldo", Saldo);
            //cmd_InsertarCuentas.Parameters.AddWithValue("@FeachaApertura", FeachaApertura);
            //cmd_InsertarCuentas.Parameters.AddWithValue("@Estado", Estado);
            //cmd_InsertarCuentas.ExecuteNonQuery();


            string Usp_crear = "uspCuentasCrear";

            using (SqlConnection conn = conexion.MtdAbrirConexion()) // Asegura que la conexión se cierre
            using (SqlCommand cmd = new SqlCommand(Usp_crear, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CodigoCliente", CodigoCliente);
                cmd.Parameters.AddWithValue("@NumeroCuenta", NumeroCuenta);
                cmd.Parameters.AddWithValue("@TipoCuenta", TipoCuenta);
                cmd.Parameters.AddWithValue("@Saldo", Saldo);
                cmd.Parameters.AddWithValue("@FechaApertura", FechaApertura);
                cmd.Parameters.AddWithValue("@Estado", Estado);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
