using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class RolModule : IRolModule
    {
        private readonly IAccesoDatos _accesoDatos;
        public RolModule(IAccesoDatos accesoDatos) 
        {
            _accesoDatos = accesoDatos;
        }
        public List<Rol> listarRoles()
        {
            var result = new List<Rol>();
            try
            {
                _accesoDatos.setearConsulta("ObtenerRol");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    Rol aux = new Rol();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Descripcion = (string)_accesoDatos.Lector["Descripcion"];


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

        public Rol ObtenerRolPorId(int id)
        {
            var result = new Rol();
            try
            {
                _accesoDatos.setearConsulta("ObtenerRolPorId");

                _accesoDatos.setearParametro("@Id", id.ToString());

                _accesoDatos.ejecutarLectura();

                if (_accesoDatos.Lector.Read())
                {
                    result.Id = (int)_accesoDatos.Lector["Id"];
                    result.Descripcion = (string)_accesoDatos.Lector["Descripcion"];
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
    }
}

