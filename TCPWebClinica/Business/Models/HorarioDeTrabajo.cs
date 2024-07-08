using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class HorarioDeTrabajo
    {
        public int Id { get; set; }

        public int IdMedico { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }

        public string FechaYHora
        {
            get
            {
                return $"Entrada: {HoraEntrada.ToString("yyyy-MM-dd HH:mm:ss")}, Salida: {HoraSalida.ToString("yyyy-MM-dd HH:mm:ss")}";
            }
        }
        public string Hora
        {
            get
            {
                return $"Entrada: {HoraEntrada.ToString("HH:mm:ss")}, Salida: {HoraSalida.ToString("HH:mm:ss")}";
            }
        }

    }
}
