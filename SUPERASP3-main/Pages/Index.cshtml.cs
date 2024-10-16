using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Eco_life.Models;
using System.Collections.Generic; // Necessária para IList<T>
using System.Threading.Tasks; // Necessária para async/await

namespace Eco_life.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger; // Necessária se estiver utilizando ILogger<IndexModel>
        private readonly ApplicationDbContext _context; 

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            Cadastros1 = new List<Cadastros1>();
            Produtos1 = new List<Produtos1>();
        }

        public IList<Cadastros1> Cadastros1 { get; set; }
        public IList<Produtos1> Produtos1 { get; set; }

        public async Task OnGetAsync()
        {
            Cadastros1 = await _context.Cadastros1.ToListAsync();
            Produtos1 = await _context.Produtos1.ToListAsync();
        }
    }
}