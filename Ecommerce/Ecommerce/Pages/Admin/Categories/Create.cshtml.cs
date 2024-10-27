using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin.Categories;

[BindProperties]

public class CreateModel : PageModel
{
    private readonly ICategoryRepository _dbCategory;
    [BindProperty]
    public Category Category { get; set; }

    public CreateModel(ICategoryRepository dbCategory)
    {
		_dbCategory = dbCategory;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString()) 
        {
            ModelState.AddModelError("Category.Name", "The Display Order cannot exactlly match the Name.");
        }
        if (ModelState.IsValid)
        {
			_dbCategory.Add(Category);
			_dbCategory.Save();
            TempData["success"] = "Category created sucessfully";
			return RedirectToPage("Index");
		}
        return Page();
    }
}
