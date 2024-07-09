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
    public class DiaTrabajoModule : IDiaTrabajoModule
    {
        private readonly IAccesoDatos _accesoDatos;
        private readonly IMedicoModule _medicoModule;
        public DiaTrabajoModule(IAccesoDatos accesoDatos, IMedicoModule medicoModule)
        {

            _accesoDatos = accesoDatos;
            _medicoModule = medicoModule;
        }

        public DiaTrabajo AgregarHorariosYDiasDeTrabajo(DiaTrabajo diaTrabajo)
        {
            try
            {
               

                _accesoDatos.setearConsulta("AgregarHorariosYDiasDeTrabajo");

                // Asegurarse de que el ID siempre se proporciona. Si no hay ID, asumimos que es una nueva inserción.
                _accesoDatos.setearParametro("@Id", diaTrabajo.Id.ToString());
                _accesoDatos.setearParametro("@MedicoId", diaTrabajo.Medico.Id.ToString());
                _accesoDatos.setearParametro("@DiaSemana", ((int)diaTrabajo.Dia).ToString()); // Convertir a string
                _accesoDatos.setearParametro("@HoraInicio", diaTrabajo.HoraInicio.ToString());
                _accesoDatos.setearParametro("@HoraFin", diaTrabajo.HoraFin.ToString());

                _accesoDatos.ejecutarLectura();


                // Verifica si la lectura tiene filas y obtiene el ID generado
                if (_accesoDatos.Lector.HasRows)
                {
                    while (_accesoDatos.Lector.Read())
                    {
                        var idValue = _accesoDatos.Lector[0];
                        if (idValue is int idInt)
                        {
                            diaTrabajo.Id = idInt;
                        }
                        else if (idValue is decimal idDecimal)
                        {
                            diaTrabajo.Id = (int)idDecimal;
                        }
                        else if (idValue is long idLong)
                        {
                            diaTrabajo.Id = (int)idLong;
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
                throw new Exception("Error de conexión de SQL: " + ex.Message, ex);
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }

            return diaTrabajo;
        }

        public List<DiaTrabajo> HorarioTrabajo()
        {
            return ObtenerHorarioTrabajoMedico();
        }


        public List<DiaTrabajo> ObtenerHorarioTrabajoMedico()
        {
            var result = new List<DiaTrabajo>();
            try
            {
                _accesoDatos.setearConsulta("ObtenerMedicosXHorariosDeTrabajo");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    DiaTrabajo aux = new DiaTrabajo();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Medico = new Medico();
                    aux.Medico.Id = (int)_accesoDatos.Lector["MedicoId"];
                    aux.Dia = (DayOfWeek)(int)_accesoDatos.Lector["DiaSemana"];
                    aux.HoraInicio = (TimeSpan)_accesoDatos.Lector["HoraInicio"];
                    aux.HoraFin = (TimeSpan)_accesoDatos.Lector["HoraFin"];


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

        public List<DiaTrabajo> ObtenerHorarioTrabajoMedicoPorMedico(int medicoId)
        {
            var result = new List<DiaTrabajo>();
            try
            {
                _accesoDatos.setearConsulta("ObtenerMedicosXHorariosDeTrabajoPorMedico");
                _accesoDatos.setearParametro("@MedicoId", medicoId.ToString());
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    DiaTrabajo aux = new DiaTrabajo();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Medico = new Medico();
                    aux.Medico.Id = (int)_accesoDatos.Lector["MedicoId"];
                    aux.Dia = (DayOfWeek)(int)_accesoDatos.Lector["DiaSemana"];
                    aux.HoraInicio = (TimeSpan)_accesoDatos.Lector["HoraInicio"];
                    aux.HoraFin = (TimeSpan)_accesoDatos.Lector["HoraFin"];

                    result.Add(aux);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener horario de trabajo del médico: " + ex.Message);
            }
            finally
            {
                _accesoDatos.cerrarConexion();
            }
        }


        public void SeleccionarHorariosTrabajo()
        {
            try
            {
                // Limpiamos los horarios anteriores del médico
                var medicos = _medicoModule.listarMedicos();
                foreach (var medico in medicos)
                {
                    // Obtener y limpiar los horarios de trabajo actuales del médico
                    var horariosActuales = ObtenerHorarioTrabajoMedicoPorMedico(medico.Id);
                    foreach (var horario in horariosActuales)
                    {
                       //EliminarHorarioTrabajo(horario.Id);
                    }
                }

                // Añadimos nuevos horarios (ejemplo)
                foreach (var medico in medicos)
                {
                    AgregarHorariosYDiasDeTrabajo(new DiaTrabajo { Medico = medico, Dia = DayOfWeek.Monday, HoraInicio = new TimeSpan(9, 0, 0), HoraFin = new TimeSpan(17, 0, 0) });
                    AgregarHorariosYDiasDeTrabajo(new DiaTrabajo { Medico = medico, Dia = DayOfWeek.Wednesday, HoraInicio = new TimeSpan(13, 0, 0), HoraFin = new TimeSpan(20, 0, 0) });
                    AgregarHorariosYDiasDeTrabajo(new DiaTrabajo { Medico = medico, Dia = DayOfWeek.Friday, HoraInicio = new TimeSpan(8, 0, 0), HoraFin = new TimeSpan(12, 0, 0) });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al seleccionar horarios de trabajo: " + ex.Message, ex);
            }
        }

    }
}
