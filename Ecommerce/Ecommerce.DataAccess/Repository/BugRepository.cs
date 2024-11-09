using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository
{
	public class BugRepository : Repository<Bug>, IBugRepository
	{
		private readonly ApplicationDbContext _db;
		public BugRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}      

		public void Update(Bug obj)
		{
			var objFromDb = _db.Bug.FirstOrDefault(u=> u.Id == obj.Id);
			objFromDb.Name = obj.Name;
		}
	}
}
