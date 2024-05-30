using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
     public interface IAccesoDatos
    {
        SqlDataReader Lector { get; }
        void setearConsulta(string consulta);
        void ejecutarLectura();
        void cerrarConexion();
        void setearParametro(string nombreParametro, string valor);
        void SetearParametroSeguro(string nombreParametro, string valor);


    }
}
