using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fiba.DAL.Interfaces
{
	public interface IRepository<TEntity, TId> where TEntity : class
	{
		Task CreateAsync(TEntity Entity);
		IEnumerable<TEntity> Retrieve();
		Task<TEntity> RetrieveAsync(TId id);
		Task UpdateAsync(TEntity Entity);
		Task DeleteAsync(TEntity Entity);
	}
}
