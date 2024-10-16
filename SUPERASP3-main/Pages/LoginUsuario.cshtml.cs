using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eco_life.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Eco_life.Pages
{
    public class LoginUsuarioModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginUsuarioModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email_User { get; set; } = string.Empty;

        [BindProperty]
        public string Senha_User { get; set; } = string.Empty;

        public string? ErrorMessage { get; set; }
        public string? Nome_User { get; set; }

        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(Email_User) || string.IsNullOrEmpty(Senha_User))
            {
                ErrorMessage = "Email ou senha não podem estar vazios.";
                return Page();
            }

            var usuario = _context.Cadastros1.FirstOrDefault(u => u.Email_User == Email_User);

            if (usuario == null)
            {
                ErrorMessage = "Essa conta não existe. Verifique o email e tente novamente.";
                return Page();
            }

            if (usuario.Senha_User != Senha_User)
            {
                ErrorMessage = "Senha incorreta. Tente novamente.";
                return Page();
            }

            HttpContext.Session.SetString("UserId", usuario.ID_User.ToString());
            HttpContext.Session.SetString("UserName", usuario.Nome_User ?? string.Empty);
            HttpContext.Session.SetString("UserEmail", usuario.Email_User ?? string.Empty);

            return RedirectToPage("/Index");
        }
    }
}