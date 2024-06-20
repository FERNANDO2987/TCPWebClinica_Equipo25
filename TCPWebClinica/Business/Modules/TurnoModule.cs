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
                _accesoDatos.setearParametro("@FechaHora", turno.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"));
                _accesoDatos.setearParametro("@MedicoId", turno.Medico.Id.ToString());
                _accesoDatos.setearParametro("@PacienteId", turno.Paciente.Id.ToString());
                _accesoDatos.setearParametro("@EspecialidadId", turno.Especialidad.Id.ToString());
                _accesoDatos.setearParametro("@Observaciones", turno.Observaciones ?? throw new ArgumentException("Las Observaciones no puede ser null o vacío.", nameof(turno.Observaciones)));
                _accesoDatos.setearParametro("@EstadoId", turno.Estado.Id.ToString());
                _accesoDatos.setearParametro("@ObraSocialId", turno.ObraSocial.Id.ToString());

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
            throw new NotImplementedException();
        }
    }
}
