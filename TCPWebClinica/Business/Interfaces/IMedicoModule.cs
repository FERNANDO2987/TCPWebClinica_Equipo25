﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IMedicoModule
    {
        List<Medico> listarMedicos();
        Medico agregarMedico(Medico medico);
        bool eliminarMedico(int id);
     

    }
}
