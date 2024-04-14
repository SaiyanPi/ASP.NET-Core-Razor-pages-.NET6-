using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZappaWeb.Data;
using ZappaWeb.Model;

namespace ZappaWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IEnumerable<Category> Caategories { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            Caategories = _context.Categories;
        }
    }
}
