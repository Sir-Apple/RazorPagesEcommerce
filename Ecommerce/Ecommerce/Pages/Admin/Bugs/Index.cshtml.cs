using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin.Bugs
{
    public class IndexModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public IEnumerable<Bug> Bugs { get; set; }

		public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
        public void OnGet()
        {
            Bugs = _unitOfWork.Bug.GetAll();
        }
    }
}
