using Business.AccesoSQL;
using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class PacienteModule : IPacienteModule
    {
        private readonly IAccesoDatos _accesoDatos;
        public PacienteModule(IAccesoDatos accesoDatos)
        {
            _accesoDatos = accesoDatos;
        }

        public bool ExisteHistoriaClinica(int historiaClinica)
        {
            bool existe = false;
            AccesoDatos _accesoDatos = new AccesoDatos();

            try
            {
                _accesoDatos.setearConsulta("SELECT COUNT(*) FROM Pacientes WHERE HC = @HC");
                _accesoDatos.setearParametro("@HC", historiaClinica.ToString());

                _accesoDatos.ejecutarLectura();
                if (_accesoDatos.Lector.Read())
                {
                    int count = (int)_accesoDatos.Lector[0];
                    existe = count > 0;
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

            return existe;
        }



        public int GenerarHistoriaClinicaUnica()
        {
            int nuevaHC;
            bool existe;

            do
            {
                // Generar una nueva HC
                nuevaHC = new Random().Next(1, 1000000); // Generar un número entero aleatorio
                existe = ExisteHistoriaClinica(nuevaHC);
            } while (existe);

            return nuevaHC;
        }




        public Paciente agregarPaciente(Paciente paciente)
        {
            try
            {
                // Generar y asignar una HC única al paciente
                paciente.HistoriaClinica = GenerarHistoriaClinicaUnica();

                _accesoDatos.setearConsulta("AgregarPaciente");

                // Asegurarse de que el ID siempre se proporciona. Si no hay ID, asumimos que es una nueva inserción.
                _accesoDatos.setearParametro("@Id", paciente.Id.ToString());
                _accesoDatos.setearParametro("@HC", paciente.HistoriaClinica.ToString());
                _accesoDatos.setearParametro("@Nombre", paciente.Nombre);
                _accesoDatos.setearParametro("@Apellido", paciente.Apellido);
                _accesoDatos.setearParametro("@Documento", paciente.Documento.ToString());
                _accesoDatos.setearParametro("@FechaNacimiento", paciente.FechaNacimeinto.ToString());
                _accesoDatos.setearParametro("@Celular", paciente.Celular);
                _accesoDatos.setearParametro("@Email", paciente.Email);
                _accesoDatos.setearParametro("@Sexo", paciente.Sexo);
                _accesoDatos.setearParametro("@IdObraSocial", paciente.ObraSocial.Id.ToString());
                // Execute the query
                _accesoDatos.ejecutarAccion();

                // Verifica si la lectura tiene filas y obtiene el ID generado
                if (_accesoDatos.Lector.HasRows)
                {
                    while (_accesoDatos.Lector.Read())
                    {
                        var idValue = _accesoDatos.Lector[0];
                        if (idValue is int idInt)
                        {
                            paciente.Id = idInt;
                        }
                        else if (idValue is decimal idDecimal)
                        {
                            paciente.Id = (int)idDecimal;
                        }
                        else if (idValue is long idLong)
                        {
                            paciente.Id = (int)idLong;
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

            return paciente;
        }

        public bool eliminarPaciente(int id)
        {
            try
            {

                _accesoDatos.setearConsulta("EliminarPaciente");
                _accesoDatos.setearParametro("@Id", id.ToString()); // Convertir el ID a string

                _accesoDatos.ejecutarLectura(); // Ejecutar la acción de eliminación

                if (_accesoDatos.Lector.Read())
                {
                    bool resultado = _accesoDatos.Lector.GetBoolean(0);
                    return resultado;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                _accesoDatos.cerrarConexion(); // Asegurarnos de cerrar la conexión
            }
        }

        public List<Paciente> listarPacientes()
        {
            var result = new List<Paciente>();
            try
            {
                _accesoDatos.setearConsulta("LeerPacientes");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.HistoriaClinica = (int)_accesoDatos.Lector["HC"];
                    aux.Nombre = (string)_accesoDatos.Lector["Nombre"];
                    aux.Apellido = (string)_accesoDatos.Lector["Apellido"];
                    aux.Documento = (int)_accesoDatos.Lector["Documento"];
                    aux.FechaNacimeinto = (DateTime)_accesoDatos.Lector["FechaNacimiento"];
                    aux.Celular = (string)_accesoDatos.Lector["Celular"];
                    aux.Email = (string)_accesoDatos.Lector["Email"]; 
                    aux.Sexo = (string)_accesoDatos.Lector["Sexo"];
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
