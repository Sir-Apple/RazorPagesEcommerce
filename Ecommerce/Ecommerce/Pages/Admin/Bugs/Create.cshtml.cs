using Ecommerce.DataAccess.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin.Bugs;

[BindProperties]

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _db;
    [BindProperty]
    public Bug Bug { get; set; }

    public CreateModel(ApplicationDbContext db)
    {
        _db = db;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
			await _db.Bug.AddAsync(Bug);
			await _db.SaveChangesAsync();
            TempData["success"] = "Bug Type created sucessfully";
			return RedirectToPage("Index");
		}
        return Page();
    }
}
