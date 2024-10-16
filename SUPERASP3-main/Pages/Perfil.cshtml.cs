using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eco_life.Models;
using Microsoft.AspNetCore.Http;

namespace Eco_life.Pages
{
    public class PerfilModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PerfilModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Cadastros1? Usuario { get; set; }

        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToPage("/LoginUsuario");
            }

            Usuario = _context.Cadastros1.FirstOrDefault(u => u.ID_User.ToString() == userId);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostExcluirConta()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToPage("/Index");
            }

            var usuario = _context.Cadastros1.FirstOrDefault(u => u.ID_User.ToString() == userId);
            if (usuario != null)
            {
                _context.Cadastros1.Remove(usuario);
                _context.SaveChanges();
                HttpContext.Session.Clear();
                TempData["SuccessMessage"] = "Conta excluída com sucesso.";
                return RedirectToPage("/Index");
            }

            TempData["ErrorMessage"] = "Erro ao excluir a conta. Usuário não encontrado.";
            return Page();
        }
    }
}