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
    public class KegOfficeApiService : IKegOfficeApiService
    {
        private readonly KegContext _con = new KegContext();

        public Task<KegOffice> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            KegOffice kegOffice = new KegOffice();
            try
            {
                kegOffice = _con.KegOffices.Where(w => w.KegOfficeId.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {

                string exMsg = ex.Message;
            }
            return Task.FromResult(kegOffice);
        }

        public Task<IEnumerable<KegOffice>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            List<KegOffice> kegOfficeList = new List<KegOffice>();
            try
            {
                kegOfficeList = _con.KegOffices.ToList();
            }
            catch (Exception ex)
            {

                string exMsg = ex.Message;
            }
            return Task.FromResult<IEnumerable<KegOffice>>(kegOfficeList);
        }

        public Task<ResourceCreationResult<KegOffice, int>> CreateAsync(KegOffice resource, IRequestContext context,
            CancellationToken cancellation)
        {
            try
            {
                _con.KegOffices.Add(resource);
                _con.SaveChanges();

            }
            catch (Exception ex)
            {

                string exMsg = ex.Message;
            }
            return Task.FromResult(new ResourceCreationResult<KegOffice, int>(resource));
        }

        public Task<KegOffice> UpdateAsync(KegOffice resource, IRequestContext context, CancellationToken cancellation)
        {
            try
            {

            }
            catch (Exception ex)
            {

                string exMsg = ex.Message;
            }
            throw new Exception();
        }

        public Task DeleteAsync(ResourceOrIdentifier<KegOffice, int> input, IRequestContext context,
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
