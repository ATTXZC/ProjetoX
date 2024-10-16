using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Eco_life.Models;
using Eco_life.Services;
using Microsoft.EntityFrameworkCore; 
using System.Threading.Tasks;

namespace Eco_life.Pages
{
    public class CadastrarFornecedorModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;

        public CadastrarFornecedorModel(ApplicationDbContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        [BindProperty]
        public Funcionario1 Fornecedor1 { get; set; } = new Funcionario1();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Verifica se o e-mail do fornecedor não está vazio
            if (string.IsNullOrEmpty(Fornecedor1.Email_Funcionario))
            {
                ModelState.AddModelError("", "O e-mail do fornecedor não pode estar vazio.");
                return Page();
            }

            // Verifica se o e-mail já está cadastrado
            var emailExists = await _context.Funcionarios1.AnyAsync(f => f.Email_Funcionario == Fornecedor1.Email_Funcionario);
            if (emailExists)
            {
                ModelState.AddModelError("", "Este e-mail já está cadastrado.");
                return Page();
            }

            // Verifica se o token foi fornecido
            if (!string.IsNullOrEmpty(Fornecedor1.Token))
            {
                // Gere o token, caso tenha sido fornecido
                Fornecedor1.Token = TokenGenerator.GenerateToken(); // Você deve implementar o método GenerateToken

                // Tenta enviar o email com o token
                try
                {
                    await _emailSender.SendEmailAsync(Fornecedor1.Email_Funcionario, "Seu Token de Registro", $"Seu token de registro é: {Fornecedor1.Token}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao enviar o e-mail: " + ex.Message);
                    return Page();
                }
            }
            else
            {
                Fornecedor1.Token = null; // Se não foi fornecido, armazena como nulo
            }

            // Adicione o Fornecedor1 ao contexto
            _context.Funcionarios1.Add(Fornecedor1);
            await _context.SaveChangesAsync();

            // Remover o login automático após cadastro
            TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";
            return RedirectToPage("./Index");
        }
    }
}
