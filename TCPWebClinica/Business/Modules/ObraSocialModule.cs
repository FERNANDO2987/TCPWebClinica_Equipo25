using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class ObraSocialModule : IObraSocialModule
    {

        private readonly IAccesoDatos _accesoDatos;

        public ObraSocialModule(IAccesoDatos accesoDatos)
        {
            _accesoDatos = accesoDatos;

        }
        public ObraSocial agregarObraSocial(ObraSocial obraSocial)
        {
            try
            {
                // Set the stored procedure and parameters
                _accesoDatos.setearConsulta("AgregarObraSocial");
                _accesoDatos.setearParametro("@Id", obraSocial.Id.ToString()); // Assuming Id is provided for updates, else should be set to a default value
                _accesoDatos.setearParametro("@Nombre", obraSocial.Nombre ?? throw new ArgumentException("El nombre no puede ser null o vacía.", nameof(obraSocial.Nombre)));
                _accesoDatos.setearParametro("@Descripcion", obraSocial.Descripcion ?? throw new ArgumentException("La Descripcion no puede ser null o vacía.", nameof(obraSocial.Descripcion)));
                _accesoDatos.setearParametro("@Direccion", obraSocial.Direccion ?? throw new ArgumentException("La Direccion no puede ser null o vacía.", nameof(obraSocial.Direccion)));
                _accesoDatos.setearParametro("@Telefono", obraSocial.Telefono ?? throw new ArgumentException("El Telefono no puede ser null o vacía.", nameof(obraSocial.Telefono)));
                _accesoDatos.setearParametro("@Email", obraSocial.Email ?? throw new ArgumentException("El Email no puede ser null o vacía.", nameof(obraSocial.Email)));
                _accesoDatos.setearParametro("@Website", obraSocial.Website ?? throw new ArgumentException("El sitio Web no puede ser null o vacía.", nameof(obraSocial.Website)));
                _accesoDatos.setearParametro("@Activo", obraSocial.Activo.ToString());
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
                            obraSocial.Id = idInt;
                        }
                        else if (idValue is decimal idDecimal)
                        {
                            obraSocial.Id = (int)idDecimal;
                        }
                        else if (idValue is long idLong)
                        {
                            obraSocial.Id = (int)idLong;
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

            return obraSocial;
        }

        public bool eliminarObraSocial(int id)
        {
            try
            {
                _accesoDatos.setearConsulta("EliminarObraSocial");
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

        public List<ObraSocial> listarObraSociales()
        {
            var result = new List<ObraSocial>();
            try
            {
                _accesoDatos.setearConsulta("ObtenerObraSocial");
                _accesoDatos.ejecutarLectura();

                while (_accesoDatos.Lector.Read())
                {
                    ObraSocial aux = new ObraSocial();
                    aux.Id = (int)_accesoDatos.Lector["Id"];
                    aux.Nombre = (string)_accesoDatos.Lector["Nombre"];
                    aux.Descripcion = (string)_accesoDatos.Lector["Descripcion"];
                    aux.Direccion = (string)_accesoDatos.Lector["Direccion"];
                    aux.Telefono = (string)_accesoDatos.Lector["Telefono"];
                    aux.Email = (string)_accesoDatos.Lector["Email"];
                    aux.Website = (string)_accesoDatos.Lector["Website"];
                    aux.Activo = (bool)_accesoDatos.Lector["Activo"];

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
