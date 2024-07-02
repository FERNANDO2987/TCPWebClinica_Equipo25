using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class RecepcionistaModule
    {
        private readonly IAccesoDatos _accesoDatos;

        public RecepcionistaModule (IAccesoDatos accesoDatos)
        {
            _accesoDatos = accesoDatos;
        }

        public Recepcionista agregaRecepcionista (Recepcionista recepcionista)
        {
            try
            {
            _accesoDatos.setearConsulta("AgregarRecepcionista");

                _accesoDatos.setearParametro("@Id", recepcionista.Id.ToString());
                _accesoDatos.setearParametro("@Nombre", recepcionista.Nombre);
                _accesoDatos.setearParametro("@Apellido", recepcionista.Apellido);
                _accesoDatos.setearParametro("@Email", recepcionista.Email);

                _accesoDatos.ejecutarAccion();


            }
            catch(Exception ex) 
            {
                throw new Exception("Error de conexión de SQL: " + ex.Message, ex);
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
            return recepcionista;
        }

        public bool eliminarRecepcionista(int id)
        {
            try
            {
                _accesoDatos.setearConsulta("EliminarRecepcionista");
                _accesoDatos.setearParametro("@Id", id.ToString());
                _accesoDatos.ejecutarLectura();

                if (_accesoDatos.Lector.Read())
                {
                    bool resultado = _accesoDatos.Lector.GetBoolean(0);
                    return resultado;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }

        }

        public List<Recepcionista> listarRecepcionistas()
        {
            var lista = new List<Recepcionista>();
            try
            {
                _accesoDatos.setearConsulta("LeerRecepcionista");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    Recepcionista aux = new Recepcionista();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Nombre = (string)_accesoDatos.Lector["Nombre"];
                    aux.Apellido = (string)_accesoDatos.Lector["Apellido"];
                    aux.Email = (string)_accesoDatos.Lector["Email"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error de conexion a la base de datos: " + ex.Message);
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }

        public Recepcionista modificarRecepcionista(Recepcionista recepcionista)
        {
            try
            {
                _accesoDatos.setearConsulta("ModificarRecepcionista");

                _accesoDatos.setearParametro("@Nombre", recepcionista.Nombre);
                _accesoDatos.setearParametro("@Apellido", recepcionista.Apellido);
                _accesoDatos.setearParametro("@Email", recepcionista.Email);

                _accesoDatos.ejecutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error de conexión a la base de datos: " + ex.Message, ex);
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
            return recepcionista;
        }
    }
}
