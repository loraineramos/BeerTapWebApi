using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeerTapHypermediaWebApi.ApiServices.Security;
using BeerTapHypermediaWebApi.Model;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace BeerTapHypermediaWebApi.ApiServices
{
    public class OfficeApiService : IOfficeApiService
    {
        private readonly KegContext _con = new KegContext();


        public Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            Office kegOffice = new Office();
            try
            {
                kegOffice = _con.KegOffices.FirstOrDefault(w => w.KegOfficeId.Equals(id));
            }
            catch (Exception ex)
            {

                throw context.CreateHttpResponseException<Office>(ex.Message, HttpStatusCode.BadRequest);
            }
            return Task.FromResult(kegOffice);
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            List<Office> kegOfficeList = new List<Office>();
            try
            {
                kegOfficeList = _con.KegOffices.ToList();
            }
            catch (Exception ex)
            {

                throw context.CreateHttpResponseException<Office>(ex.Message, HttpStatusCode.BadRequest);
            }
            return Task.FromResult<IEnumerable<Office>>(kegOfficeList);
        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context,
            CancellationToken cancellation)
        {
            Office office = new Office();
            try
            {
                if (resource != null)
                {
                    office = resource;
                    _con.KegOffices.Add(office);
                    _con.SaveChanges();

                }

            }
            catch (Exception ex)
            {

                throw context.CreateHttpResponseException<Office>(ex.Message, HttpStatusCode.BadRequest);
            }
            return Task.FromResult(new ResourceCreationResult<Office, int>(office));
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            Office origOffice = new Office();
            if (resource != null)
            {
                origOffice = _con.KegOffices.FirstOrDefault(w => w.KegOfficeId.Equals(resource.Id));
                origOffice.KegOfficeName = resource.KegOfficeName;
                _con.Entry(origOffice).State = EntityState.Modified;
                _con.SaveChanges();
            }

            return Task.FromResult<Office>(origOffice);

        }

        public Task DeleteAsync(ResourceOrIdentifier<Office, int> input, IRequestContext context,
            CancellationToken cancellation)
        {
            try
            {
                if (input.HasResource)
                {
                    _con.KegOffices.Attach(input.Resource);
                    _con.Entry(input.Resource).State = EntityState.Deleted;
                    _con.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw context.CreateHttpResponseException<Office>(ex.Message, HttpStatusCode.BadRequest);
            }
            return Task.FromResult(input);
        }
    }
}
