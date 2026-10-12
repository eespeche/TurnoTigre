using Dominio;

namespace AccesoDatos
{
    public class EspecialidadDatos
    {
        public List<Especialidad> Listar()
        {
            List<Especialidad> lista = new List<Especialidad>();
            ConexionDB datos = new ConexionDB();

            try
            {
                datos.setearConsulta(
                    "SELECT id_especialidad, codigo, descripcion " +
                    "FROM ESPECIALIDAD  ORDER BY codigo");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.IdEspecialidad  = (int)datos.Lector["id_especialidad"];
                    esp.Codigo    = (string)datos.Lector["codigo"];
                    esp.Descripcion    = (string)datos.Lector["descripcion"];

                    lista.Add(esp);
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