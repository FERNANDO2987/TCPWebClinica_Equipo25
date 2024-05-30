using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
     public interface IEspecialidadModule
    {
        List<Especialidad> listarEspecialidad();
        Especialidad agregarEspecialidad(Especialidad especialidad);
        bool eliminarEspecilidad(int id);
        void modificarEspecilidad(Especialidad especialidad);

    }
}
