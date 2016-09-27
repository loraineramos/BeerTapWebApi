using System;
using BeerTapHypermediaWebApi.Model;
using BeerTapHypermediaWebApi.Model.Enum;
using IQ.Platform.Framework.WebApi;
using BeerTapHypermediaWebApi.Model.Helper;

namespace BeerTapHypermediaWebApi.ApiServices
{
    public interface IKegApiService :
       IGetAResourceAsync<Keg,int>,
        IGetManyOfAResourceAsync<Keg, int>,
        ICreateAResourceAsync<Keg, int>,
        IUpdateAResourceAsync<Keg, int>,
        IDeleteResourceAsync<Keg, int>
        


    {
    }
}
