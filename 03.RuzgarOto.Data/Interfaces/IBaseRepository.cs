using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.RuzgarOto.Data.Interfaces
{
	public interface IBaseRepository<T> where T : class,new()
	{
		public int Add(T entity);
		public int Update(T entity);
		public int Delete(T entity);
		public T GetById(int id);
		public IEnumerable<T> GetAll(bool isTracking = true);

		public IQueryable<T> Query(string sql);
		int SaveChanges();
	}
}
