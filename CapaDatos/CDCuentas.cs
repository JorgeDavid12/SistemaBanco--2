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
    }
}
