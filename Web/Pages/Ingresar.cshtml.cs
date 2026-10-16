using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Negocio;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuario usuario = negocio.ValidarUsuario(Correo, Contrasena);

                if (usuario.Rol == "Paciente")
                {
                    var datosUsuario = new List<Claim>
                    {
                        new Claim(
                            ClaimTypes.NameIdentifier,
                            usuario.IdUsuario.ToString()),

                        new Claim(ClaimTypes.Name, usuario.Email),

                        new Claim(ClaimTypes.Role, usuario.Rol)
                    };

                    var identidad = new ClaimsIdentity(
                        datosUsuario,
                        CookieAuthenticationDefaults.AuthenticationScheme);

                    var usuarioAutenticado = new ClaimsPrincipal(identidad);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        usuarioAutenticado);

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