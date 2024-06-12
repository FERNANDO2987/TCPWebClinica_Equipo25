using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
     public interface ITurnoModule
    {
        List<Turno> listarTurnos();
        Turno agregarTurno(Turno turno);
        bool eliminarTurno(int id);

    }
}
