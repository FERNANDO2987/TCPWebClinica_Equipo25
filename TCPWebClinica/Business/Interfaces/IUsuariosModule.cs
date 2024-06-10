using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
     public interface IUsuariosModule
    {
        List<Usuario> listarUsuarios();
        Usuario agregarUsuario(Usuario usuario);
        bool eliminarUsuario(int id);
       

    }
}
