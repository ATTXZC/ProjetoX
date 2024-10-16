using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eco_life.Models;

namespace Eco_life.Pages
{
    public class CadastrarUsuarioModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CadastrarUsuarioModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cadastros1 Usuario { get; set; } = new Cadastros1();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Verifica a validade da senha
            if (string.IsNullOrWhiteSpace(Usuario.Senha_User) || Usuario.Senha_User.Length < 6)
            {
                TempData["ErrorMessage"] = "A senha deve ter pelo menos 6 caracteres.";
                return Page();
            }

            // Verifica a validade do email
            if (string.IsNullOrWhiteSpace(Usuario.Email_User) || !IsEmailValid(Usuario.Email_User))
            {
                TempData["ErrorMessage"] = "Email inválido. Por favor, forneça um email válido.";
                return Page();
            }

            try
            {
                _context.Cadastros1.Add(Usuario);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Conta criada com sucesso!";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Erro ao criar a conta: " + ex.Message;
                return Page();
            }
        }

        private bool IsEmailValid(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
    }
}
