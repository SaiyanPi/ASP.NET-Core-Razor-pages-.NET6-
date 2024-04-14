using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZappaWeb.Data;
using ZappaWeb.Model;

namespace ZappaWeb.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            
            if (Category.Name == Category.DisplayOrder.ToString()) //custom validation(server side, by default .net core doesn't display custom validation on client side)
            {
                ModelState.AddModelError("Category.Name", "DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid) //server side validation
            {
                await _db.Categories.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully.";
               
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
