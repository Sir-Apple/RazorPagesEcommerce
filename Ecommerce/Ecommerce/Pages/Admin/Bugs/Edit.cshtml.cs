using Ecommerce.DataAccess.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin.Bugs;

[BindProperties]

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty]
    public Bug Bug { get; set; }

    public EditModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet(int id)
    {
		Bug = _db.Bug.Find(id);
		//Category = _db.Category.FirstOrDefault(u => u.Id == id);
		//Category = _db.Category.SingleOrDefault(u => u.Id == id);
		//Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
	}

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
			_db.Bug.Update(Bug);
			await _db.SaveChangesAsync();
			TempData["success"] = "Bug Type updated sucessfully";
			return RedirectToPage("Index");
		}
        return Page();
    }
}
