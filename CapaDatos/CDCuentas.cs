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

        public int CP_mtdActualizarCuentas(int Codigo, string NumeroCuenta, string TipoCuenta, decimal Saldo, DateTime FechaApertura, string Estado)
        {
            /* int vContarRegistrosAfectados = 0;

             string vUspActualizarClientes = "usp_clientes_editar";
             SqlCommand commActualizarClientes = new SqlCommand(vUspActualizarClientes, db_conexion.MtdAbrirConexion());
             commActualizarClientes.CommandType = CommandType.StoredProcedure;

             commActualizarClientes.Parameters.AddWithValue("@Codigo", Codigo);
             commActualizarClientes.Parameters.AddWithValue("@Nombre", Nombre);
             commActualizarClientes.Parameters.AddWithValue("@Direccion", Direccion);
             commActualizarClientes.Parameters.AddWithValue("@Departamento", Departamento);
             commActualizarClientes.Parameters.AddWithValue("@Pais", Pais);
             commActualizarClientes.Parameters.AddWithValue("@Categoria", Categoria);
             commActualizarClientes.Parameters.AddWithValue("@Estado", Estado);

             vContarRegistrosAfectados = commActualizarClientes.ExecuteNonQuery();

             // 🔴 Asegurarse de cerrar la conexión después de usarla
             db_conexion.MtdCerrarConexion();
             return vContarRegistrosAfectados;*/

            int vContarRegistrosAfectados = 0;
            string vUspActualizarCuentas = "uspCuentasEditar";

            using (SqlConnection conn = conexion.MtdAbrirConexion())
            {
                using (SqlCommand commActualizarCuentas = new SqlCommand(vUspActualizarCuentas, conn))
                {
                    commActualizarCuentas.CommandType = CommandType.StoredProcedure;

                    commActualizarCuentas.Parameters.AddWithValue("@CodigoCuenta", Codigo);
                    commActualizarCuentas.Parameters.AddWithValue("@NumeroCuenta", NumeroCuenta);
                    commActualizarCuentas.Parameters.AddWithValue("@TipoCuenta", TipoCuenta);
                    commActualizarCuentas.Parameters.AddWithValue("@Saldo", Saldo);
                    commActualizarCuentas.Parameters.AddWithValue("@FechaApertura", FechaApertura);
                    commActualizarCuentas.Parameters.AddWithValue("@Estado", Estado);

                    // ⚠️ Cambiar ExecuteNonQuery() por ExecuteScalar()
                    object result = commActualizarCuentas.ExecuteScalar();
                    vContarRegistrosAfectados = result != null ? Convert.ToInt32(result) : 0;
                }
            }

            return vContarRegistrosAfectados;
        }

        public int CP_mtdEliminarCuentas(int codigo)
        {
            int vCantidadRegistrosEliminados = 0;

            string vUspEliminarCuentas = "uspCuentasEliminar";
            SqlCommand commEliminarCuentas = new SqlCommand(vUspEliminarCuentas, conexion.MtdAbrirConexion());
            commEliminarCuentas.CommandType = CommandType.StoredProcedure;

            commEliminarCuentas.Parameters.AddWithValue("@CodigoCuenta", codigo);

            vCantidadRegistrosEliminados = commEliminarCuentas.ExecuteNonQuery();
            return vCantidadRegistrosEliminados;
        }
    }
}
