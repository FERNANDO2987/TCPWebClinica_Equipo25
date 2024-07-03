using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class AdministradorModule
    {
        private readonly IAccesoDatos _accesoDatos;

        public AdministradorModule(IAccesoDatos accesoDatos)
        {
            _accesoDatos = accesoDatos;
        }

        public Administrador agregaAdministrador(Administrador administrador)
        {
            try
            {
                _accesoDatos.setearConsulta("AgregarAdministardor");

                _accesoDatos.setearParametro("@Id", administrador.Id.ToString());
                _accesoDatos.setearParametro("@Nombre", administrador.Nombre);
                _accesoDatos.setearParametro("@Apellido", administrador.Apellido);
                _accesoDatos.setearParametro("@Email", administrador.Email);

                _accesoDatos.ejecutarAccion();


            }
            catch (Exception ex)
            {
                throw new Exception("Error de conexión de SQL: " + ex.Message, ex);
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
            return administrador;
        }

        public bool eliminarAdministrador(int id)
        {
            try
            {
                _accesoDatos.setearConsulta("EliminarAdministrador");
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

        public List<Administrador> listarAdministrador()
        {
            var lista = new List<Administrador>();
            try
            {
                _accesoDatos.setearConsulta("LeerAdministrador");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    Administrador aux = new Administrador();
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

        public Administrador modificarAdministrador(Administrador administrador)
        {
            try
            {
                _accesoDatos.setearConsulta("ModificarAdministrador");

                _accesoDatos.setearParametro("@Nombre", administrador.Nombre);
                _accesoDatos.setearParametro("@Apellido", administrador.Apellido);
                _accesoDatos.setearParametro("@Email", administrador.Email);

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
            return administrador;
        }
    }
}
    
