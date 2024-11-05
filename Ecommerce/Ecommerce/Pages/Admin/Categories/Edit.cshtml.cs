using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin.Categories;

[BindProperties]

public class EditModel : PageModel
{
	private readonly IUnitOfWork _unitOfWork;

	public Category Category { get; set; }

	public EditModel(IUnitOfWork unityOfWork)
	{
		_unitOfWork = unityOfWork;
	}

    public void OnGet(int id)
    {
        Category = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==id);
        //Category = _db.Category.FirstOrDefault(u => u.Id == id);
        //Category = _db.Category.SingleOrDefault(u => u.Id == id);
        //Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
    }

    public async Task<IActionResult> OnPost()
    {
        if (Category.Name == Category.DisplayOrder.ToString()) 
        {
            ModelState.AddModelError("Category.Name", "The Display Order cannot exactlly match the Name.");
        }
        if (ModelState.IsValid)
        {
			_unitOfWork.Category.Update(Category);
			_unitOfWork.Save();
			TempData["success"] = "Category updated sucessfully";
			return RedirectToPage("Index");
		}
        return Page();
    }
}
