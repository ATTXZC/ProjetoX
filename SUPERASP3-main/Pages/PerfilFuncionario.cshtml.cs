using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eco_life.Models;
using Microsoft.AspNetCore.Http;

namespace Eco_life.Pages
{
    public class PerfilFuncionarioModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public PerfilFuncionarioModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Funcionario1? Funcionario { get; set; }

        public IActionResult OnGet()
        {
            var funcionarioId = HttpContext.Session.GetString("FuncionarioId");
            if (string.IsNullOrEmpty(funcionarioId))
            {
                return RedirectToPage("/LoginFuncionario");
            }

            Funcionario = _context.Funcionarios1.FirstOrDefault(f => f.Id_Funcionario.ToString() == funcionarioId);

            if (Funcionario == null)
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
            var funcionarioId = HttpContext.Session.GetString("FuncionarioId");
            if (string.IsNullOrEmpty(funcionarioId))
            {
                return RedirectToPage("/Index");
            }

            var funcionario = _context.Funcionarios1.FirstOrDefault(f => f.Id_Funcionario.ToString() == funcionarioId);
            if (funcionario != null)
            {
                _context.Funcionarios1.Remove(funcionario);
                _context.SaveChanges();
                HttpContext.Session.Clear();
                TempData["SuccessMessage"] = "Conta excluída com sucesso.";
                return RedirectToPage("/Index");
            }

            TempData["ErrorMessage"] = "Erro ao excluir a conta. Funcionário não encontrado.";
            return Page();
        }
    }
}