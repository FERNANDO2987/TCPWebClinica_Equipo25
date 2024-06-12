using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IEstadoTurno
    {
        List<EstadoTurno> listarEstadosTurno();
        EstadoTurno agregarEstadoTurno(EstadoTurno turno);
        bool eliminarEstadoTurno(int id);

    }
}
