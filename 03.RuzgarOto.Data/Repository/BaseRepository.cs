using _02.RuzgarOto.Model;
using _03.RuzgarOto.Data.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace _03.RuzgarOto.Data.Repository
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
	{
		protected readonly RuzgarOtoDbContext ruzgarOtoDbContext;

		public BaseRepository(RuzgarOtoDbContext ruzgarOtoDbContext)
		{
			this.ruzgarOtoDbContext = ruzgarOtoDbContext;
		}

		public int Add(T entity)
		{
			var i = this.ruzgarOtoDbContext.Set<T>().Add(entity);
			if (i.State == EntityState.Added)
			{
				return 1;
			}
			else
				return 0;
		}

		public int Delete(T entity)
		{
			var state = this.ruzgarOtoDbContext.Set<T>().Remove(entity);
			if (state.State == EntityState.Deleted)
			{ return 1; }
			return 0;
		}

		public IEnumerable<T> GetAll(bool isTracking = true)
		{
			IEnumerable<T> track;
			if (isTracking)
			{
				track = this.ruzgarOtoDbContext.Set<T>().ToList();
			}
			else
				track = this.ruzgarOtoDbContext.Set<T>().AsNoTracking().ToList();

			return track;
		}
       
        public T GetById(int id)
		{
			return this.ruzgarOtoDbContext.Set<T>().Find(id)!;
		}

        public IQueryable<T> Query(string sql)
        {
            return this.ruzgarOtoDbContext.Set<T>().FromSqlRaw(sql);
        }

        public int SaveChanges()
		{
			return this.ruzgarOtoDbContext.SaveChanges();
		}

		public int Update(T entity)
		{
			var state = this.ruzgarOtoDbContext.Update(entity);
			if (state.State == EntityState.Modified)
			{
				return 1;
			}
			return 0;
		}
	}
}
