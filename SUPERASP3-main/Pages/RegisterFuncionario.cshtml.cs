using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eco_life.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Eco_life.Pages
{
    public class RegisterFuncionarioModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterFuncionarioModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public string Name { get; set; } = string.Empty; // Inicializado para evitar warnings

        [BindProperty]
        public string Email { get; set; } = string.Empty; // Inicializado para evitar warnings

        [BindProperty]
        public string Password { get; set; } = string.Empty; // Inicializado para evitar warnings

        [BindProperty]
        public string Token { get; set; } = string.Empty; // Inicializado para evitar warnings

        public IActionResult OnPost()
        {
            // Valide o token aqui
            var user = _userManager.FindByEmailAsync(Email).Result;

            // Verifique se o usuário existe
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Usuário não encontrado.");
                return Page();
            }

            var result = _userManager.VerifyUserTokenAsync(user, "Default", "EmailConfirmation", Token).Result;

            if (result)
            {
                // Crie a conta do funcionário
                var newUser = new ApplicationUser { UserName = Email, Email = Email, Name = Name };
                var createResult = _userManager.CreateAsync(newUser, Password).Result;

                if (createResult.Succeeded)
                {
                    // Conta criada com sucesso
                    return RedirectToPage("Success");
                }
            }
            // Retornar erro caso falhe
            return Page();
        }
    }
}
