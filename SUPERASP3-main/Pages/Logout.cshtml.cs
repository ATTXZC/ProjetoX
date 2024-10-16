using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eco_life.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            TempData["NomeUsuario"] = null;
            return RedirectToPage("/Index");
        }
    }
}
