using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
     public class Medico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public int UsuarioId { get; set; }
        public List<Especialidad> Especialidades { get; set; }
        public List<Turno> Turnos { get; set; }
        public List<HorarioDeTrabajo> HorarioDeTrabajo { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"{Apellido} {Nombre}";
            }
        }

    }
}
