using System;
using System.Threading.Tasks;

namespace Fiba.DAL.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		Task<int> SaveChangesAsync();
	}
}
