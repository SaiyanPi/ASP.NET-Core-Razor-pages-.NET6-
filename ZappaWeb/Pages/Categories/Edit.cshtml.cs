using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZappaWeb.Data;
using ZappaWeb.Model;

namespace ZappaWeb.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet( int id)
        {
            Category = _db.Categories.Find(id);
            //Category = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category = _db.Categories.SingleOrDefault(u=>u.Id==id);
            //Category = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost()
        {
            
            if (Category.Name == Category.DisplayOrder.ToString()) //custom validation(server side, by default .net core doesn't display custom validation on client side)
            {
                ModelState.AddModelError("Category.Name", "DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid) //server side validation
            {
                _db.Categories.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully.";
               
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}
