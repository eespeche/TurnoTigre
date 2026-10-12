using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class CentroSaludNegocio
    {
        private readonly CentroSaludDatos datos = new CentroSaludDatos();

        public List<CentroSalud> Listar()
        {
            return datos.Listar();
        }
    }
}