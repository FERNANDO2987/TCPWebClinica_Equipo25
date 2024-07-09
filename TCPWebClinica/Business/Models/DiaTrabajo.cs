using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class DiaTrabajo
    {
        public int Id { get; set; }
        public Medico Medico { get; set; }
        public DayOfWeek Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }

       
    }
}
