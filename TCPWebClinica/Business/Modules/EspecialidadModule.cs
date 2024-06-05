using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class EspecialidadModule : IEspecialidadModule
    {
        private readonly IAccesoDatos _accesoDatos;

        public EspecialidadModule(IAccesoDatos accesoDatos)
        {
            _accesoDatos = accesoDatos;
            listarEspecialidad();
        }
        public Especialidad agregarEspecialidad(Especialidad especialidad)
        {
            throw new NotImplementedException();
        }

        public bool eliminarEspecilidad(int id)
        {
            throw new NotImplementedException();
        }

        public List<Especialidad> listarEspecialidad()
        {
            var result = new List<Especialidad>();
            try
            {
                _accesoDatos.setearConsulta("ObtenerEspecialidad");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    Especialidad aux = new Especialidad();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Nombre = (string)_accesoDatos.Lector["Nombre"];


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

        public void modificarEspecilidad(Especialidad especialidad)
        {
            throw new NotImplementedException();
        }
    }
}
