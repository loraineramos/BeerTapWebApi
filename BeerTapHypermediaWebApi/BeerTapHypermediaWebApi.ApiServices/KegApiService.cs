using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi.Services.Security;
using BeerTapHypermediaWebApi.ApiServices.Security;
using BeerTapHypermediaWebApi.Model;
using Castle.Components.DictionaryAdapter;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.Common;
using System.Net;
using Castle.MicroKernel.ModelBuilder.Descriptors;

namespace BeerTapHypermediaWebApi.ApiServices
{
    public class KegApiService : IKegApiService
    {
        private KegContext _con = new KegContext();
        readonly IApiUserProvider<BeerTapHypermediaWebApiApiUser> _userProvider;

        public KegApiService(IApiUserProvider<BeerTapHypermediaWebApiApiUser> userProvider)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
        }

        public Task<ResourceCreationResult<Keg, int>> CreateAsync(Keg resource, IRequestContext context,
            CancellationToken cancellation)
        {
            Keg keg = new Keg();
            int officeId = 0;
            try
            {
                if (resource != null)
                {
                    bool officeidToken = context.UriParameters.GetByName<int>("kegOfficeId").HasValue;
                    if (officeidToken) { officeId = context.UriParameters.GetByName<int>("kegOfficeId").Value; }
                    keg = resource;
                    keg.KegOfficeId = officeId;
                    _con.Kegs.Add(keg);
                    _con.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                string exMsg = ex.Message;
            }

            return Task.FromResult(new ResourceCreationResult<Keg, int>(keg));
        }


        public Task DeleteAsync(ResourceOrIdentifier<Keg, int> input, IRequestContext context,
            CancellationToken cancellation)
        {
            try
            {

                if (input.Id != 0)
                {
                    Keg keg = _con.Kegs.FirstOrDefault(w => w.KegId.Equals(input.Id));
                    _con.Kegs.Attach(keg);
                    _con.Entry(keg).State = EntityState.Deleted;
                    _con.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string exMsg = ex.Message;
            }

            return Task.FromResult(input);
        }


        public Task<Keg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            Keg keg = new Keg();
            int officeId = 0;
            try
            {
                bool officeidToken = context.UriParameters.GetByName<int>("kegOfficeId").HasValue;
                if (officeidToken) { officeId = context.UriParameters.GetByName<int>("kegOfficeId").Value; }
                keg = _con.Kegs.FirstOrDefault(w => w.KegOfficeId.Equals(officeId) && w.KegId.Equals(id));
            }
            catch (Exception ex)
            {

                string exMsg = ex.Message;
            }
            return Task.FromResult(keg);
        }

        public Task<IEnumerable<Keg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            List<Keg> kegList = new List<Keg>();
            int officeId = 0;
            try
            {
                bool officeidToken = context.UriParameters.GetByName<int>("kegOfficeId").HasValue;
                if (officeidToken) { officeId = context.UriParameters.GetByName<int>("kegOfficeId").Value; }

                if (officeidToken)
                {
                    kegList = _con.Kegs.Where(w => w.KegOfficeId.Equals(officeId)).ToList();

                }


            }
            catch (Exception ex)
            {

                string exMsg = ex.Message;
            }
            return Task.FromResult<IEnumerable<Keg>>(kegList);
        }


        public Task<Keg> UpdateAsync(Keg resource, IRequestContext context, CancellationToken cancellation)
        {
            Keg origKeg = new Keg();
            try
            {
                origKeg = _con.Kegs.FirstOrDefault(w => w.KegId.Equals(resource.Id));

                if (origKeg != null && origKeg.KegMl > 0)
                {
                    int kegMl =
                        _con.Kegs.Where(w => w.KegId.Equals(origKeg.KegId)).Select(s => s.KegMl).FirstOrDefault();
                    if (kegMl >= resource.KegMl)
                    {

                        int remainMl = kegMl - resource.KegMl;
                        origKeg.KegMl = remainMl;
                        origKeg.KegState = KegHelper.GetKegState(remainMl);
                    }

                }

                // Save changes
                _con.Entry(origKeg).State = EntityState.Modified;
                _con.SaveChanges();

            }
            catch (Exception ex)
            {
                string exMsg = ex.Message;
            }

            return Task.FromResult(origKeg);
        }


    }
}
