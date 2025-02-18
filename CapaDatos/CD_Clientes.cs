using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Clientes
    {
    
        CD_Conexion db_conexion = new CD_Conexion();

        public DataTable MtMostrarClientes()
        {
            string QryMostrarClientes = "usp_clientes_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarClientes,db_conexion.MtdAbrirConexion());
            DataTable dtMostrarClientes = new DataTable();
            adapter.Fill(dtMostrarClientes);
            db_conexion.MtdCerrarConexion();
            return dtMostrarClientes;
        }

        public void CP_mtdAgregarClientes(string Nombre, string Direccion, string Departamento, string Pais, string Categoria, string Estado)
        {

            string Usp_crear = "usp_clientes_crear";
            SqlCommand cmd_InsertarClientes = new SqlCommand(Usp_crear, db_conexion.MtdAbrirConexion());
            cmd_InsertarClientes.CommandType = CommandType.StoredProcedure;

            cmd_InsertarClientes.Parameters.AddWithValue("@Nombre", Nombre);
            cmd_InsertarClientes.Parameters.AddWithValue("@Direccion", Direccion);
            cmd_InsertarClientes.Parameters.AddWithValue("@Departamento", Departamento);
            cmd_InsertarClientes.Parameters.AddWithValue("@Pais", Pais);
            cmd_InsertarClientes.Parameters.AddWithValue("@Categoria", Categoria);
            cmd_InsertarClientes.Parameters.AddWithValue("@Estado", Estado);
            cmd_InsertarClientes.ExecuteNonQuery();
        }

        public int CP_mtdActualizarClientes(string Codigo, string Nombre, string Direccion, string Departamento, string Pais, string Categoria, string Estado)
        {
            int vContarRegistrosAfectados = 0;

            string vUspActualizarClientes = "usp_clientes_editar";
            SqlCommand commActualizarClientes = new SqlCommand(vUspActualizarClientes, db_conexion.MtdAbrirConexion());
            commActualizarClientes.CommandType = CommandType.StoredProcedure;

            commActualizarClientes.Parameters.AddWithValue("@Codigo", Codigo);
            commActualizarClientes.Parameters.AddWithValue("@vNombre", Nombre);
            commActualizarClientes.Parameters.AddWithValue("@Direccion", Direccion);
            commActualizarClientes.Parameters.AddWithValue("@Departamento", Departamento);
            commActualizarClientes.Parameters.AddWithValue("@Pais", Pais);
            commActualizarClientes.Parameters.AddWithValue("@vCategoria", Categoria);
            commActualizarClientes.Parameters.AddWithValue("@Estado", Estado);

            vContarRegistrosAfectados = commActualizarClientes.ExecuteNonQuery();
            return vContarRegistrosAfectados;
        }


    }
}
