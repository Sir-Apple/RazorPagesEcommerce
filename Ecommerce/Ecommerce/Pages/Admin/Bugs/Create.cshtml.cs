using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin.Bugs;

[BindProperties]

public class CreateModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public Bug Bug { get; set; }

    public CreateModel(IUnitOfWork unitOfWork)
    {
		_unitOfWork = unitOfWork;
    }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
			_unitOfWork.Bug.Add(Bug);
			_unitOfWork.Save();
            TempData["success"] = "Bug Type created sucessfully";
			return RedirectToPage("Index");
		}
        return Page();
    }
}
