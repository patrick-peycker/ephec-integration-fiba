namespace Fiba.BL.Interfaces
{
	public interface IFibaActors
	{
		IGuestActor GuestActor { get; }
		IAuthenticatedActor AuthenticatedActor { get; }
	}
}
