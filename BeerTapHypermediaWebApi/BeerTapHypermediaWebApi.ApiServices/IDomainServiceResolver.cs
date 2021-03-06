﻿using System;
using BeerTapHypermediaWebApi.Services;

namespace BeerTapHypermediaWebApi.ApiServices
{
	public interface IDomainServiceResolver
	{
		IDomainService Resolve(Type requestedServiceType);

		TService Resolve<TService>()
			where TService : IDomainService;
	}
}

namespace BeerTapHypermediaWebApi.Services
{
	/// <summary> 
	/// Represents a specific domain service / repository used in IApiApplicationService implementations 
	/// </summary> 
	public interface IDomainService
	{
	}
}
