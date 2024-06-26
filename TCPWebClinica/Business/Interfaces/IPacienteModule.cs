﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IPacienteModule
    {
        List<Paciente> listarPacientes();
        Paciente agregarPaciente(Paciente paciente);
        bool eliminarPaciente(int id);
        List<Paciente> BuscarPacientePorCriterio(string criterio);
        Paciente ObtenerPacientePorId(int id);

    }
}
