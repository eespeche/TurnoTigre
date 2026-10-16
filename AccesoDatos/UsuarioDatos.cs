using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class UsuarioDatos
    {

        public bool ExisteEmail(string email)
        {
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM USUARIO WHERE email = @email");
                datos.setearParametro("@email", email);

                return datos.obtenerId() > 0;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Usuario BuscarUsuarioPorEmail(string email)
        {
            ConexionDB datos = new ConexionDB();
            try
            {
                datos.setearConsulta(@"SELECT id_usuario, nombre_usuario, password_hash, email, rol, activo
                                     FROM USUARIO
                                     WHERE email = @email");
                datos.setearParametro("@email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = (int)datos.Lector["id_usuario"];
                    usuario.NombreUsuario = (string)datos.Lector["nombre_usuario"];
                    usuario.PasswordHash = (string)datos.Lector["password_hash"];
                    usuario.Email = (string)datos.Lector["email"];
                    usuario.Rol = (string)datos.Lector["rol"];
                    usuario.Activo = (bool)datos.Lector["activo"];

                    return usuario;
                }

                return null;

            }
            finally {
                datos.cerrarConexion();
            }
        }


    }
}
