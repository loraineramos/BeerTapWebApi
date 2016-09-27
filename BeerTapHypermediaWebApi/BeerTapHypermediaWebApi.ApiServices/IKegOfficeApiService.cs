using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapHypermediaWebApi.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapHypermediaWebApi.ApiServices
{
    public interface IKegOfficeApiService :
        IGetAResourceAsync<KegOffice, int>,
        IGetManyOfAResourceAsync<KegOffice, int>,
        ICreateAResourceAsync<KegOffice, int>,
        IUpdateAResourceAsync<KegOffice, int>,
        IDeleteResourceAsync<KegOffice, int>
    {
    }
}
