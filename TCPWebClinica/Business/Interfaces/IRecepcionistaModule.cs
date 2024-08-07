﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRecepcionistaModule
    {
        List<Recepcionista> listarRecepcionistas();
        Recepcionista agregaRecepcionista(Recepcionista recepcionista);
        bool eliminarRecepcionista(int id);

    }
}