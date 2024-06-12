using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public class TurnoModule : ITurnoModule
    {
        private readonly IAccesoDatos _accesoDatos;

        public TurnoModule(IAccesoDatos accesoDatos) 
        {
           _accesoDatos = accesoDatos;
        }

        public Turno agregarTurno(Turno turno)
        {
            throw new NotImplementedException();
        }

        public bool eliminarTurno(int id)
        {
            throw new NotImplementedException();
        }

        public List<Turno> listarTurnos()
        {
            throw new NotImplementedException();
        }
    }
}
