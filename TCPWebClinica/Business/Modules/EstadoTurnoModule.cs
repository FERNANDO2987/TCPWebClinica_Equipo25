using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class EstadoTurnoModule : IEstadoTurno
    {

        private readonly IAccesoDatos _accesoDatos;
        public EstadoTurnoModule(IAccesoDatos accesoDatos)
        {
            _accesoDatos = accesoDatos;
        }
        public EstadoTurno agregarEstadoTurno(EstadoTurno turno)
        {

            try
            {
                // Set the stored procedure and parameters
                _accesoDatos.setearConsulta("AgregarEstadoTurno");
                _accesoDatos.setearParametro("@Id", turno.Id.ToString()); // Assuming Id is provided for updates, else should be set to a default value
                _accesoDatos.setearParametro("@Codigo", turno.Codigo ?? throw new ArgumentException("El codigo del Estado del Turno no puede ser null o vacío.", nameof(turno.Codigo)));
                _accesoDatos.setearParametro("@Descripcion", turno.Descripcion ?? throw new ArgumentException("La Descripcion del Estado del Turno no puede ser null o vacío.", nameof(turno.Codigo)));

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
                            turno.Id = idInt;
                        }
                        else if (idValue is decimal idDecimal)
                        {
                            turno.Id = (int)idDecimal;
                        }
                        else if (idValue is long idLong)
                        {
                            turno.Id = (int)idLong;
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

            return turno;
        }

        public bool eliminarEstadoTurno(int id)
        {
            try
            {

                _accesoDatos.setearConsulta("EliminarEstadoTurno");
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

        public List<EstadoTurno> listarEstadosTurno()
        {
            var result = new List<EstadoTurno>();
            try
            {
                _accesoDatos.setearConsulta("ObtenerEstadosTurno");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    EstadoTurno aux = new EstadoTurno();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Codigo = (string)_accesoDatos.Lector["Codigo"];
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
    }
}
