using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
     public interface IObraSocialModule
    {
        List<ObraSocial> listarObraSociales();
        ObraSocial agregarObraSocial(ObraSocial obraSocial);
        bool eliminarObraSocial(int id);
        void modificarObraSocial(ObraSocial obraSocial);

    }
}
