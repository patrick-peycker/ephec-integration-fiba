namespace Fiba.DAL.Interfaces
{
	public interface IFibaUnitOfWork : IUnitOfWork
	{
		ISeasonRepository SeasonRepository { get; }
		IGenderRepository GenderRepository { get; }
		ITeamRepository TeamRepository { get; }
		IPlayerRepository PlayerRepository { get; }
		IMatchRepository MatchRepository { get; }
	}
}
