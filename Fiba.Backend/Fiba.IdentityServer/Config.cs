// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
	public static class Config
	{
		public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
		{
			new IdentityResources.OpenId(),
			new IdentityResources.Profile(),
			new IdentityResources.Address(),
			new IdentityResources.Email()
		};

		public static IEnumerable<ApiScope> ApiScopes =>
			 new ApiScope[]
			 {
				new ApiScope("fiba.api", "Fiba Api")
			 };

		public static IEnumerable<Client> Clients =>
			 new Client[]
			 {
					new Client
					{
						ClientId = "fiba.frontend",
						ClientName = "Fiba - Frontend - Angular",
						AllowedGrantTypes = GrantTypes.Code,
						RequirePkce = true,
						RequireClientSecret = false,
						AllowedScopes = { "openid", "profile", "fiba.api" },
						RedirectUris = {"http://localhost:4200/auth-callback"},
						PostLogoutRedirectUris = {"http://localhost:4200/"},
						AllowedCorsOrigins = {"http://localhost:4200"},
						AllowAccessTokensViaBrowser = true,
						AccessTokenLifetime = 3600
					}				
			 };
	}
}