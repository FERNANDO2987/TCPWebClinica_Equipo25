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
    
        }
        public Especialidad agregarEspecialidad(Especialidad especialidad)
        {
            var error = "";
            var result = new Especialidad();


            try
            {
                _accesoDatos.setearConsulta("AgregarEspecilidad");

                _accesoDatos.setearParametro("@Nombre", especialidad.Nombre ?? throw new ArgumentException("El código del artículo no puede ser nulo o vacío.", nameof(categorias.Descripcion)));

                // Ejecutar la consulta y obtener el ID generado automáticamente
                _accesoDatos.ejecutarLectura();

                if (_accesoDatos.Lector.HasRows)
                {
                    while (_accesoDatos.Lector.Read())
                    {
                        result.Id = Convert.ToInt32(_accesoDatos.Lector[0]);
                        result.Nombre= especialidad.Nombre;
                    }
                }

                

            }
            catch (Exception ex)
            {
                error = "Error de conexion de SQL " + ex.Message;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }

            return result;

        }

        public bool eliminarEspecilidad(int id)
        {
            try
            {
                _accesoDatos.setearConsulta("EliminarEspecialidad");
                _accesoDatos.setearParametro("@Id", id.ToString()); // Convertir el ID a string
                _accesoDatos.ejecutarLectura(); // Ejecutar la acción de eliminación


                return true;
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
            string error = "";

            try
            {
                _accesoDatos.setearConsulta("ModificarEspecilidad");
                _accesoDatos.setearParametro("@Id", especialidad.Id.ToString());
                _accesoDatos.setearParametro("@Nombre", especialidad.Nombre);


                _accesoDatos.ejecutarLectura();
            }
            catch (Exception ex)
            {
                error = "Error de conexion de SQL " + ex.Message;
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }
    }
}
