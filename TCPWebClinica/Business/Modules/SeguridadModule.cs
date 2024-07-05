using Business.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules
{
    public static class SeguridadModule
    {
        public static bool sesionActiva(object user)
        {
            Usuario usuario = user != null ? (Usuario)user : null;
            if (!(usuario != null && usuario.Id != 0))
                return false;
            else 
                return true;
        }

        public static bool esAdmin(object user)
        {
            Usuario usuario = null;
            if (sesionActiva(user))
            {
                usuario = (Usuario)user;
                //if (usuario.Rol.Id== 1)
                if (usuario.Rol.Descripcion.ToLower().Trim() == "admin") 
                        return true;
                    else return false;
            }
            return false;
        }
        public static bool esRecepcionista(object user)
        {
            Usuario usuario = null;
            if (sesionActiva(user))
            {
                usuario = (Usuario)user;
                //if (usuario.Rol.Id == 2)
                if (usuario.Rol.Descripcion.ToLower().Trim() == "recepcionista")
                    return true;
                else return false;
            }
            return false;
        }
        public static bool esMedico(object user)
        {
            Usuario usuario = null;
            if (sesionActiva(user))
            {
                usuario = (Usuario)user;
                //if (usuario.Rol.Id == 3)
                if (usuario.Rol.Descripcion.ToLower().Trim() == "medico")
                    return true;
                else return false;
            }
            return false;
        }
    }
}
