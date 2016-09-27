using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Http;
using BeerTapHypermediaWebApi.Model;
using BeerTapHypermediaWebApi.WebApi.Infrastructure;

namespace BeerTapHypermediaWebApi.WebApi
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
            //Database.SetInitializer<KegContext>(new DbMigrationsConfiguration<KegContext>());
			BootStrapper.Initialize(GlobalConfiguration.Configuration);
		}
	}
}