using Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio;

namespace Web.Pages
{
    public class EspecialidadesModel : PageModel
    {
        public List<Especialidad> Especialidades { get; set; } = new List<Especialidad>();
        public string? Error { get; set; }

        public void OnGet()
        {
            try
            {
                EspecialidadNegocio negocio = new EspecialidadNegocio();
                Especialidades = negocio.Listar();
            }
            catch (Exception ex)
            {
                Error = "No se pudieron cargar las especialidades: " + ex.Message;
            }
        }
    }
}