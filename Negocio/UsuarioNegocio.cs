using Dominio;
using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private readonly UsuarioDatos usuarioDatos = new UsuarioDatos();

        public Usuario ValidarUsuario(string email, string contrasena)
        {

            email = email.Trim().ToLower();
            Usuario usuario = usuarioDatos.BuscarUsuarioPorEmail(email);

            if (usuario == null)
            {
                throw new Exception("El Email o la contraseña no son correctas.");
            }

            if (!BCrypt.Net.BCrypt.Verify(contrasena, usuario.PasswordHash))
            {
                throw new Exception("El Email o la contraseña no son correctas.");
            }

            if (!usuario.Activo)
            {
                throw new Exception("El usuario está deshabilitado.");
            }


            return usuario;

        }


    }
}
