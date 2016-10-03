using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapHypermediaWebApi.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapHypermediaWebApi.ApiServices
{
    public interface IKegsAndKegOfficesApiService : IGetManyOfAResourceAsync<KegAndKegOffice, int>
    {
    }
}
