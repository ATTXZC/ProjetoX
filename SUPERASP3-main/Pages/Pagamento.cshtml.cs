using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eco_life.Pages
{
    public class PagamentoModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public PagamentoModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
