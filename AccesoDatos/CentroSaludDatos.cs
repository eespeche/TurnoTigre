using Dominio;

namespace AccesoDatos
{
    public class CentroSaludDatos
    {
        public List<CentroSalud> Listar()
        {
            List<CentroSalud> lista = new List<CentroSalud>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta(
                    "SELECT id_centro, codigo, nombre, direccion, localidad " +
                    "FROM CENTRO_SALUD ORDER BY nombre");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    CentroSalud centro = new CentroSalud();
                    centro.IdCentro  = (int)datos.Lector["id_centro"];
                    centro.Codigo    = (string)datos.Lector["codigo"];
                    centro.Nombre    = (string)datos.Lector["nombre"];
                    centro.Direccion = (string)datos.Lector["direccion"];
                    centro.Localidad = (string)datos.Lector["localidad"];

                    lista.Add(centro);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}