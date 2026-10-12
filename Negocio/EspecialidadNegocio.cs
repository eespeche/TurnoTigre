using AccesoDatos;
using Dominio;

namespace Negocio
{
    public class EspecialidadNegocio
    {
        private readonly EspecialidadDatos datos = new EspecialidadDatos();

        public List<Especialidad> Listar()
        {
            return datos.Listar();
        }
    }
}