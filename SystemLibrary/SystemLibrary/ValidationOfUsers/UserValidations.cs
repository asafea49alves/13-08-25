using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemLibrary.Entities;

namespace SystemLibrary.ValidationOfUsers
{
    public class UserValidations
    {
        public Usuario validationUser(Usuario usuario, List<Usuario> usuarios)
        {
            foreach (var usuarioSet in usuarios)
            {
                if (usuario == usuarioSet)
                {
                    return null;
                }
            }
            return usuario;
        }
    }
}
