using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using BeerTapHypermediaWebApi.ApiServices.Security;

namespace BeerTapHypermediaWebApi.WebApi.Handlers
{
	public class PutYourApiSafeNameUserContextProvidingHandler
			: ApiSecurityContextProvidingHandler<BeerTapHypermediaWebApiApiUser, NullUserContext>
	{

		public PutYourApiSafeNameUserContextProvidingHandler(
			IStoreDataInHttpRequest<BeerTapHypermediaWebApiApiUser> apiUserInRequestStore)
			: base(new BeerTapHypermediaWebApiUserFactory(), CreateContextProvider(), apiUserInRequestStore)
		{
		}

		static ApiUserContextProvider<BeerTapHypermediaWebApiApiUser, NullUserContext> CreateContextProvider()
		{
			return
				new ApiUserContextProvider<BeerTapHypermediaWebApiApiUser, NullUserContext>(_ => new NullUserContext());
		}
	}
}