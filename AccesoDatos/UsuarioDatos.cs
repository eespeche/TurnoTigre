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


    }
}
