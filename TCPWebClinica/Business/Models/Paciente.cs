using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
     public class Paciente
    {
        public int Id { get; set; }
        public int HistoriaClinica { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Documento { get; set; }
        public DateTime FechaNacimeinto { get; set; }
        public string Celular {  get; set; }
        public string Email {  get; set; }
        public bool Sexo { get; set; }
        public ObraSocial ObraSocial { get; set; }  // Relación con ObraSocial
        public List<Turno> Turnos { get; set; } //Relacion con Turno

        
    }
}
