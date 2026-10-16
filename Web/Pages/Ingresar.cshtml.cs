using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio;
using System.ComponentModel.DataAnnotations;

namespace Web.Pages
{
    public class IngresarModel : PageModel
    {

        [BindProperty]
        [Required(ErrorMessage = "Ingresá tu correo.")]
        [EmailAddress(ErrorMessage = "El correo no es válido.")]
        public string Correo { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "Ingresá una contraseña.")]
        public string Contrasena { get; set; } = string.Empty;

        public string? Error { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost ()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = negocio.ValidarUsuario(Correo, Contrasena);

                if (usuario.Rol == "Paciente")
                {
                    //Falta la pagina Index de pacientes
                    return RedirectToPage("/Pacientes/Index");
                }

                //Aca falta tener armado los demas roles
                else
                {
                    return RedirectToPage("/Ingresar");
                }

            }
            catch (Exception ex) 
            {
                Error = ex.Message;
                return Page();

            }
        }

    }
}