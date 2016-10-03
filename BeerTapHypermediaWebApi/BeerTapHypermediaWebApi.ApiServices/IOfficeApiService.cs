using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapHypermediaWebApi.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapHypermediaWebApi.ApiServices
{
    public interface IOfficeApiService :
        IGetAResourceAsync<Office, int>,
        IGetManyOfAResourceAsync<Office, int>,
        ICreateAResourceAsync<Office, int>,
        IUpdateAResourceAsync<Office, int>,
        IDeleteResourceAsync<Office, int>
    {
    }
}
