using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class PacienteModule : IPacienteModule
    {
        private readonly IAccesoDatos _accesoDatos;
        public PacienteModule(IAccesoDatos accesoDatos)
        {
            _accesoDatos = accesoDatos;
        }
        public Paciente agregarPaciente(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        public bool eliminarPaciente(int id)
        {
            throw new NotImplementedException();
        }

        public List<Paciente> listarPacientes()
        {
            throw new NotImplementedException();
        }
    }
}
