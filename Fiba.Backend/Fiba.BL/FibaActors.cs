﻿using Fiba.BL.Interfaces;
using Fiba.BL.UseCases.AdministratorActor;
using Fiba.BL.UseCases.Guest;
using Fiba.BL.UseCases.SuperAdministrator;
using Fiba.DAL.Interfaces;
using System;

namespace Fiba.BL
{
	public class FibaActors : IFibaActors
	{
		private readonly IFibaUnitOfWork fibaUnitOfWork;

		public FibaActors(IFibaUnitOfWork fibaUnitOfWork)
		{
			this.fibaUnitOfWork = fibaUnitOfWork ?? throw new ArgumentNullException($"{nameof(fibaUnitOfWork)} in Fiba Actors !");
		}

		public IGuestActor GuestActor { get { return new GuestActor(fibaUnitOfWork); } }
		public IAdministratorActor AdministratorActor { get { return new AdministratorActor(fibaUnitOfWork); } }
		public ISuperAdministratorActor SuperAdministratorActor { get { return new SuperAdministratorActor(fibaUnitOfWork); } }
	}
}
