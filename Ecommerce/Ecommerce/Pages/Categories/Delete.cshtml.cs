using Ecommerce.Data;
using Ecommerce.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Categories;

[BindProperties]

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty]
    public Category Category { get; set; }

    public DeleteModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet(int id)
    {
        Category = _db.Category.Find(id);
		//Category = _db.Category.FirstOrDefault(u => u.Id == id);
		//Category = _db.Category.SingleOrDefault(u => u.Id == id);
		//Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
	}

    public async Task<IActionResult> OnPost()
    {
        
        if (ModelState.IsValid)
        {
            var categoryFromDb = _db.Category.Find(Category.Id);
            if (categoryFromDb != null)
            {
                _db.Category.Remove(categoryFromDb);
            }
			_db.Category.Update(Category);
			await _db.SaveChangesAsync();
			return RedirectToPage("Index");
		}
        return Page();
    }
}
