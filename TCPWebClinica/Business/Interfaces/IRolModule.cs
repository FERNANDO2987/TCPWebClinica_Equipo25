﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
     public interface IRolModule
    {
        List<Rol> listarRoles();
        Rol ObtenerRolPorId(int id);
    }
}
