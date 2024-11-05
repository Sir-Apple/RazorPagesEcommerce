using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
		private readonly ICategoryRepository _dbCategory;
		public IEnumerable <Category> Categories { get; set; }

		public IndexModel(ICategoryRepository dbCategory)
		{
			_dbCategory = dbCategory;
		}
		public void OnGet()
        {
            Categories = _dbCategory.GetAll();
        }
    }
}
