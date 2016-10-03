using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeerTapHypermediaWebApi.Model;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

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

                string exMsg = ex.Message;
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

                string exMsg = ex.Message;
            }
            return Task.FromResult<IEnumerable<Office>>(kegOfficeList);
        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context,
            CancellationToken cancellation)
        {
            try
            {
                if(resource != null)
                _con.KegOffices.Add(resource);
                _con.SaveChanges();

            }
            catch (Exception ex)
            {

                string exMsg = ex.Message;
            }
            return Task.FromResult(new ResourceCreationResult<Office, int>(resource));
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
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

                string exMsg = ex.Message;
            }
            return Task.FromResult(input);
        }
    }
}
