using Dominio;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio;

namespace Web.Pages
{
    public class CentrosModel : PageModel
    {
        public List<CentroSalud> Centros { get; set; } = new List<CentroSalud>();
        public string? Error { get; set; }

        public void OnGet()
        {
            try
            {
                CentroSaludNegocio negocio = new CentroSaludNegocio();
                Centros = negocio.Listar();
            }
            catch (Exception ex)
            {
                Error = "No se pudieron cargar los centros: " + ex.Message;
            }
        }
    }
}