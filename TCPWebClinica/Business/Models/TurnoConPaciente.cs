using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class TurnoConPaciente
    {
        public int Id { get; set; }
        public string NombrePaciente { get; set; }
        public string ApellidoPaciente { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaTurno { get; set; }
        public string Especialidad { get; set; }
        public string Medico { get; set; }
        public string Descripcion { get; set; }
        public string ObraSocial { get; set; }
    }


}
