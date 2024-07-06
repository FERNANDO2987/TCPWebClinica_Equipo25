    using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class MedicoModule : IMedicoModule
    {
        private readonly IAccesoDatos _accesoDatos;
        public MedicoModule(IAccesoDatos accesoDatos) 
        {
          _accesoDatos = accesoDatos;
        }   
        public Medico agregarMedico(Medico medico)
        {
            try
            {
                _accesoDatos.setearConsulta("AgregarMedico");

                // Asegurarse de que el ID siempre se proporciona. Si no hay ID, asumimos que es una nueva inserción.
                _accesoDatos.setearParametro("@Id", medico.Id.ToString());
                _accesoDatos.setearParametro("@Nombre", medico.Nombre);
                _accesoDatos.setearParametro("@Apellido", medico.Apellido);
                _accesoDatos.setearParametro("@Email", medico.Email);

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
                            medico.Id = idInt;
                        }
                        else if (idValue is decimal idDecimal)
                        {
                            medico.Id = (int)idDecimal;
                        }
                        else if (idValue is long idLong)
                        {
                            medico.Id = (int)idLong;
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

            return medico;
        }

        public bool eliminarMedico(int id)
        {

            try
            {

                _accesoDatos.setearConsulta("EliminarMedico");
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

        public List<Medico> listarMedicos()
        {
            var result = new List<Medico>();
            try
            {
                _accesoDatos.setearConsulta("ObtenerMedico");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    Medico aux = new Medico();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Nombre = (string)_accesoDatos.Lector["Nombre"];
                    aux.Apellido = (string)_accesoDatos.Lector["Apellido"];
                    aux.Email = (string)_accesoDatos.Lector["Email"];
                  

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

