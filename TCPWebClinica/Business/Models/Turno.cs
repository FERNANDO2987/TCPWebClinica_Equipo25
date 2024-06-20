using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
     public class Turno
    {

        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public Medico Medico { get; set; } //Relacion con el Medico
        public Paciente Paciente { get; set; } //Relacion con el Paciente
        public Especialidad Especialidad { get; set; } //Relacion con la Especilaidad
        public string Observaciones { get; set; }
        public EstadoTurno Estado { get; set; } //Relacion con el Estado del Turno
        public ObraSocial ObraSocial { get; set; }  // Relación con ObraSocial


        // Propiedades adicionales para obtener fecha y hora separadas
        public DateTime Fecha => FechaHora.Date;
        public TimeSpan Hora => FechaHora.TimeOfDay;

    }
}
