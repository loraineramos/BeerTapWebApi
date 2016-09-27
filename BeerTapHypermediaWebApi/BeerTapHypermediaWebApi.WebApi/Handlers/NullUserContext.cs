using System;

namespace BeerTapHypermediaWebApi.WebApi.Handlers
{
	public class NullUserContext : IDisposable
	{
		public void Dispose() { }
	}
}