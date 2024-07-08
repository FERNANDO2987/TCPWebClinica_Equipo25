using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class HorarioTrabajoModule : IHorarioTrabajoModule
    {
        private readonly IAccesoDatos _accesoDatos;
        public HorarioTrabajoModule(IAccesoDatos accesoDatos) 
        { 
            _accesoDatos = accesoDatos;
        }
        public HorarioDeTrabajo agregarHorarioTrabajo(HorarioDeTrabajo horarioDeTrabajo)
        {

            try
            {
                // Set the stored procedure and parameters
                _accesoDatos.setearConsulta("AgregarHorarioDeTrabajo");
                _accesoDatos.setearParametro("@Id", horarioDeTrabajo.Id.ToString()); // Assuming Id is provided for updates, else should be set to a default value
                _accesoDatos.setearParametro("@HorarioEntrada", horarioDeTrabajo.HoraEntrada.ToString() ?? throw new ArgumentException("Debe ingresar la Hora de Entrada.", nameof(horarioDeTrabajo.HoraEntrada)));
                _accesoDatos.setearParametro("@HorarioSalida", horarioDeTrabajo.HoraSalida.ToString() ?? throw new ArgumentException("Debe ingresar la Hora de Salida.", nameof(horarioDeTrabajo.HoraSalida)));

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
                            horarioDeTrabajo.Id = idInt;
                        }
                        else if (idValue is decimal idDecimal)
                        {
                            horarioDeTrabajo.Id = (int)idDecimal;
                        }
                        else if (idValue is long idLong)
                        {
                            horarioDeTrabajo.Id = (int)idLong;
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

            return horarioDeTrabajo;
        }

        public bool eliminarHorarioTrabajo(int id)
        {
            try
            {
                _accesoDatos.setearConsulta("EliminarHorarioDeTrabajo");
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

        public List<HorarioDeTrabajo> listarHorarioTrabajo()
        {
            var result = new List<HorarioDeTrabajo>();
            try
            {
                _accesoDatos.setearConsulta("ObtenerHorarioDeTrabajo");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    HorarioDeTrabajo aux = new HorarioDeTrabajo();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.HoraEntrada = (DateTime)_accesoDatos.Lector["HorarioEntrada"];
                    aux.HoraSalida = (DateTime)_accesoDatos.Lector["HorarioSalida"];

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

        public List<HorarioDeTrabajo> listarHorarioTrabajoPorMedico(int idMedico)
        {
            var result = new List<HorarioDeTrabajo>();
            try
            {
                _accesoDatos.setearConsulta("ListarHorarios_x_Medico");
                _accesoDatos.setearParametro("@id", idMedico.ToString());
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    HorarioDeTrabajo aux = new HorarioDeTrabajo();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.HoraEntrada = (DateTime)_accesoDatos.Lector["HorarioEntrada"];
                    aux.HoraSalida = (DateTime)_accesoDatos.Lector["HorarioSalida"];

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

        //public List<HorarioDeTrabajo> listarHorarioTrabajoPorMedico(int idMedico)
        //{
        //    var result = new List<HorarioDeTrabajo>();
        //    try
        //    {
        //        _accesoDatos.setearConsulta("ObtenerHorariosPorMedico");
        //        _accesoDatos.setearParametro("@IdMedico", idMedico.ToString());
        //        _accesoDatos.ejecutarLectura();

        //        while (_accesoDatos.Lector.Read())
        //        {
        //            HorarioDeTrabajo aux = new HorarioDeTrabajo();
        //            aux.Id = (int)_accesoDatos.Lector["Id"];
        //            aux.HoraEntrada = (DateTime)_accesoDatos.Lector["HorarioEntrada"];
        //            aux.HoraSalida = (DateTime)_accesoDatos.Lector["HorarioSalida"];

        //            result.Add(aux);
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al obtener los horarios de trabajo por médico: " + ex.Message);
        //    }
        //    finally
        //    {
        //        _accesoDatos.cerrarConexion();
        //    }
        //}

    }
}
