using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace BeerTapHypermediaWebApi.ApiServices.Security
{

	public class BeerTapHypermediaWebApiApiUser : ApiUser<UserAuthData>
	{
		public BeerTapHypermediaWebApiApiUser(string name, Option<UserAuthData> authData)
			: base(authData)
		{
			Name = name;
		}

		public string Name { get; private set; }

	}

	public class BeerTapHypermediaWebApiUserFactory : ApiUserFactory<BeerTapHypermediaWebApiApiUser, UserAuthData>
	{
		public BeerTapHypermediaWebApiUserFactory() :
			base(new HttpRequestDataStore<UserAuthData>())
		{
		}

		protected override BeerTapHypermediaWebApiApiUser CreateUser(Option<UserAuthData> auth)
		{
			return new BeerTapHypermediaWebApiApiUser("BeerTapHypermediaWebApi user", auth);
		}
	}

}
