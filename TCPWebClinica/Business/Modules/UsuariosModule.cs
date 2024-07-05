using Business.AccesoSQL;
using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class UsuariosModule : IUsuariosModule
    {
        private readonly IAccesoDatos _accesoDatos;
        public UsuariosModule(IAccesoDatos accesoDatos)
        {
            _accesoDatos = accesoDatos;
        }
        public Usuario agregarUsuario(Usuario usuario)
        {

            try
            {
                _accesoDatos.setearConsulta("AgregarUsuario");

                // Asegurarse de que el ID siempre se proporciona. Si no hay ID, asumimos que es una nueva inserción.
                _accesoDatos.setearParametro("@Id", usuario.Id.ToString());
                _accesoDatos.setearParametro("@Nombre", usuario.Nombre);
               _accesoDatos.setearParametro("@Contraseña", usuario.Contraseña);
               _accesoDatos.setearParametro("@Email", usuario.Email);
                   _accesoDatos.setearParametro("@RolId", usuario.Rol.Id.ToString());
                // Execute the query
                _accesoDatos.ejecutarLectura();

                // Verifica si la lectura tiene filas y obtiene el ID generado
                if (_accesoDatos.Lector.HasRows)
                {
                    while (_accesoDatos.Lector.Read())
                    {
                        var idValue = _accesoDatos.Lector[0];
                        if (idValue is int idInt)
                        {
                            usuario.Id = idInt;
                        }
                        else if (idValue is decimal idDecimal)
                        {
                            usuario.Id = (int)idDecimal;
                        }
                        else if (idValue is long idLong)
                        {
                            usuario.Id = (int)idLong;
                        }
                        else
                        {
                            throw new InvalidOperationException("Tipo de ID desconocido.");
                        }
                    }
                }




            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                throw new Exception("Error de conexión de SQL: " + ex.Message, ex);
            }
            finally
            {
                // Ensure the connection is closed
                _accesoDatos.cerrarConexion();
            }

            return usuario;

        }

        public bool eliminarUsuario(int id)
        {

           
            try
            {
                
                _accesoDatos.setearConsulta("EliminarUsuario");
                _accesoDatos.setearParametro("@Id", id.ToString()); // Convertir el ID a string
               
                _accesoDatos.ejecutarLectura(); // Ejecutar la acción de eliminación

                if (_accesoDatos.Lector.Read())
                {
                    bool resultado = _accesoDatos.Lector.GetBoolean(0);
                    return resultado;
                }

                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                _accesoDatos.cerrarConexion(); // Asegurarnos de cerrar la conexión
            }
        }

        public List<Usuario> listarUsuarios()
        {
            var result = new List<Usuario>();
            try
            {
                _accesoDatos.setearConsulta("ObtenerUsuario");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Nombre = (string)_accesoDatos.Lector["Nombre"];
                    aux.Contraseña = (string)_accesoDatos.Lector["Contraseña"];
                    aux.Email = (string)_accesoDatos.Lector["Email"];
                    aux.Rol = new Rol(); 
                    aux.Rol.Id = (int)_accesoDatos.Lector["RolId"];

                    result.Add(aux);

                }

                return result;


            }
            catch (Exception ex)
            {

                throw new Exception("Error de conexion a SQL: " + ex.Message);
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }


        public bool Login(Usuario usuario)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            Usuario aux = new Usuario();
            Rol rol = new Rol();
            RolModule rolModule = new RolModule(accesoDatos);
            try
            {
                _accesoDatos.setearConsulta("Log_in");
                _accesoDatos.setearParametro("@nombre", usuario.Nombre);
                _accesoDatos.setearParametro("@pass", usuario.Contraseña);
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    
                    usuario.Id = (int)_accesoDatos.Lector["Id"];
                    usuario.Email = (string)_accesoDatos.Lector["Email"];
                    usuario.Rol = new Rol();
                    usuario.Rol.Id = (int)_accesoDatos.Lector["RolId"];
                    rol = rolModule.listarRoles().Find(x => x.Id == usuario.Rol.Id);
                    usuario.Rol.Descripcion = rol.Descripcion;
                    return true;
                }

                return false;


            }
            catch (Exception ex)
            {

                throw new Exception("Error de conexion a SQL: " + ex.Message);
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }
    }
}
