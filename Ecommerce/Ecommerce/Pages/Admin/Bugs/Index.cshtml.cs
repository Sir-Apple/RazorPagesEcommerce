using Ecommerce.DataAccess.Data;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ecommerce.Pages.Admin.Bugs
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Bug> Bugs { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Bugs = _db.Bug;
        }
    }
}
