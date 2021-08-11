namespace Fiba.BL.Interfaces
{
	public interface IFibaActors
	{
		IGuestActor GuestActor { get; }
		IAdministratorActor AdministratorActor { get; }
		ISuperAdministratorActor SuperAdministratorActor { get; }
	}
}
