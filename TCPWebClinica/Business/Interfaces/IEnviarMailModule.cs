using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
     public interface IEnviarMailModule
    {
        void EnviarEmail();
        void ArmarCorreo(string emailDestino, string asunto, string cuerpo);
    }
}
