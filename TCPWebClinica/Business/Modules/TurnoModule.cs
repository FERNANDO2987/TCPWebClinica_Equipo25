using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class TurnoModule : ITurnoModule
    {
        private readonly IAccesoDatos _accesoDatos;

        public TurnoModule(IAccesoDatos accesoDatos) 
        {
           _accesoDatos = accesoDatos;
        }

        public Turno agregarTurno(Turno turno)
        {
            try
            {
                // Set the stored procedure and parameters
                _accesoDatos.setearConsulta("AgregarTurno");
                _accesoDatos.setearParametro("@Id", turno.Id.ToString()); // Assuming Id is provided for updates, else should be set to a default value
                _accesoDatos.setearParametro("@FechaTurno", turno.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"));
                _accesoDatos.setearParametro("@IdMedico", turno.Medico.Id.ToString());
                _accesoDatos.setearParametro("@IdPaciente", turno.Paciente.Id.ToString());
                _accesoDatos.setearParametro("@IdEspecialidad", turno.Especialidad.Id.ToString());
                _accesoDatos.setearParametro("@Observaciones", turno.Observaciones);
                _accesoDatos.setearParametro("@IdEstadoTurno", turno.Estado.Id.ToString());
                _accesoDatos.setearParametro("@IdObraSocial", turno.ObraSocial.Id.ToString());

                //_accesoDatos.setearParametro("@Activo", obraSocial.Activo.ToString());
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

        public bool eliminarTurno(int id)
        {
            throw new NotImplementedException();
        }

        public List<Turno> listarTurnos()
        {
            var result = new List<Turno>();
            try
            {
                _accesoDatos.setearConsulta("ObtenerTurnos");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    Turno aux = new Turno();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Paciente = new Paciente();
                    aux.Paciente.Id = (int)_accesoDatos.Lector["IdPaciente"];
                    aux.Medico = new Medico();
                    aux.Medico.Id = (int)_accesoDatos.Lector["IdMedico"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Id = (int)_accesoDatos.Lector["IdEspecialidad"];
                    aux.Observaciones = (string)_accesoDatos.Lector["Observaciones"];
                    aux.FechaHora = (DateTime)_accesoDatos.Lector["FechaTurno"];
                    aux.Estado = new EstadoTurno();
                    aux.Estado.Id = (int)_accesoDatos.Lector["IdEstadoTurno"];
                    aux.ObraSocial = new ObraSocial();
                    aux.ObraSocial.Id = (int)_accesoDatos.Lector["IdObraSocial"];



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
