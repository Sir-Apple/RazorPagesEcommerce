﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		//GET ALL, GET By ID FIRST OR DEFAULT, ADD, REMOVE, REMOVERANGE

		void Add(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entity);
		IEnumerable<T> GetAll();

		T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null);
	}
}
