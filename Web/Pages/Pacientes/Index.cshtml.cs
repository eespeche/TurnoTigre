using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio;

namespace Web.Pages.Pacientes
{
    [Authorize(Roles = "Paciente")]
    public class IndexModel : PageModel
    {
        public List<CentroSalud> Centros { get; set; } = new();
        public List<Especialidad> Especialidades { get; set; } = new();

        public string? Error { get; set; }

        public void OnGet()
        {
            try
            {
                CentroSaludNegocio negocio = new CentroSaludNegocio();
                EspecialidadNegocio especialidad = new EspecialidadNegocio();
                Centros = negocio.Listar();
                Especialidades = especialidad.Listar();
            }
            catch (Exception)
            {
                Error = "No se pudieron cargar los centros de salud.";
                Error = "No se pudieron cargar las especialidades.";
            }
        }
    }
}