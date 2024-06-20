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
        public Paciente agregarPaciente(Paciente paciente)
        {
            try
            {
                _accesoDatos.setearConsulta("AgregarPaciente");

                // Asegurarse de que el ID siempre se proporciona. Si no hay ID, asumimos que es una nueva inserción.
                _accesoDatos.setearParametro("@Id", paciente.Id.ToString());
                _accesoDatos.setearParametro("@Apellido", paciente.Apellido);
                _accesoDatos.setearParametro("@Nombre", paciente.Nombre);
                _accesoDatos.setearParametro("@FechaNacimiento", paciente.FechaNacimeinto.ToString());
                _accesoDatos.setearParametro("@DNI", paciente.Documento.ToString());
                _accesoDatos.setearParametro("@Email", paciente.Email);
                _accesoDatos.setearParametro("@Telefono", paciente.Celular);
                _accesoDatos.setearParametro("@Sexo", paciente.Sexo);
                _accesoDatos.setearParametro("@IdObraSocial", paciente.ObraSocial.Id.ToString());
                // Execute the query
                _accesoDatos.ejecutarAccion();
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
                    aux.Apellido = (string)_accesoDatos.Lector["Apellido"];
                    aux.Nombre = (string)_accesoDatos.Lector["Nombre"];
                    aux.FechaNacimeinto = (DateTime)_accesoDatos.Lector["FechaNacimiento"];
                    aux.Documento = (string)_accesoDatos.Lector["DNI"];
                    aux.Email = (string)_accesoDatos.Lector["Email"];
                    aux.Celular = (string)_accesoDatos.Lector["Telefono"];
                    aux.Sexo = (string)_accesoDatos.Lector["Sexo"];
                    aux.ObraSocial.Nombre = (string)_accesoDatos.Lector["Nombre"];

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
