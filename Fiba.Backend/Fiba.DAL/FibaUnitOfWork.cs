using Fiba.DAL.Interfaces;
using Fiba.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace Fiba.DAL
{
	public class FibaUnitOfWork : IFibaUnitOfWork
	{
		private readonly FibaDbContext fibaDbContext;

		public FibaUnitOfWork(FibaDbContext fibaDbContext)
		{
			this.fibaDbContext = fibaDbContext ?? throw new ArgumentNullException($"{nameof(fibaDbContext)} in Fiba Unit Of Work !");
		}

		public ISeasonRepository SeasonRepository { get { return new SeasonRepository(fibaDbContext); } }
		public IGenderRepository GenderRepository { get { return new GenderRepository(fibaDbContext); } }
		public ITeamRepository TeamRepository { get { return new TeamRepository(fibaDbContext); } }
		public IPlayerRepository PlayerRepository { get { return new PlayerRepository(fibaDbContext); } }

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					fibaDbContext.Dispose();
				}
			}

			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public async Task<int> SaveChangesAsync()
		{
			return await fibaDbContext.SaveChangesAsync();
		}
	}
}
