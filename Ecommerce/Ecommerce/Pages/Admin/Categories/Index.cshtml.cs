using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public IEnumerable <Category> Categories { get; set; }

		public IndexModel(IUnitOfWork unityOfWork)
		{
			_unitOfWork = unityOfWork;
		}
		public void OnGet()
        {
            Categories = _unitOfWork.Category.GetAll();
        }
    }
}
