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
           

            try
            {
                // Set the stored procedure and parameters
                _accesoDatos.setearConsulta("AgregarEspecilidad");
                _accesoDatos.setearParametro("@Id", especialidad.Id.ToString()); // Assuming Id is provided for updates, else should be set to a default value
                _accesoDatos.setearParametro("@Nombre", especialidad.Nombre ?? throw new ArgumentException("La descripción de la categoría no puede ser nula o vacía.", nameof(especialidad.Nombre)));


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
                            especialidad.Id = idInt;
                        }
                        else if (idValue is decimal idDecimal)
                        {
                            especialidad.Id = (int)idDecimal;
                        }
                        else if (idValue is long idLong)
                        {
                            especialidad.Id = (int)idLong;
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

            return especialidad;
        }


        public bool eliminarEspecilidad(int id)
        {
            try
            {
                _accesoDatos.setearConsulta("EliminarEspecialidad");
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

        public List<Especialidad> listarEspecilidadPorMedico(int idMedico)
        {
            var result = new List<Especialidad>();
            try
            {
                _accesoDatos.setearConsulta("ObtenerEspecialidadPorMedico");
                _accesoDatos.setearParametro("@idMedico", idMedico.ToString());
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
                throw new Exception("Error al obtener los horarios de trabajo por médico: " + ex.Message);
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }


    }
}
