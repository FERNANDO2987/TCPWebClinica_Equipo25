using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AccesoSQL
{
    public class AccesoDatos : IAccesoDatos
    {

        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {

            conexion = new SqlConnection("Server=NB0ZCJDX\\SQLEXPRESS01; database=TCPClinica_DB; integrated security=true");
            comando = new SqlCommand();

        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;


        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;

            try
            {

                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }

        public void setearParametro(string nombreParametro, string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException($"El valor del parámetro '{nombreParametro}' no puede ser nulo o vacío.", nameof(valor));
            }

            // Resto del código para establecer el parámetro
            comando.Parameters.AddWithValue(nombreParametro, valor);
        }

        public void SetearParametroSeguro(string nombreParametro, string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException($"El valor del parámetro '{nombreParametro}' no puede ser nulo o vacío.", nameof(valor));
            }

            setearParametro(nombreParametro, valor);
        }





    }
}
