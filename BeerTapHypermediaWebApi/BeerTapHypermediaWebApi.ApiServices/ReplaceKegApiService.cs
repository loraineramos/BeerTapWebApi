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
    public class ReplaceKegApiService : IReplaceKegApiService
    {
        private readonly KegContext _con = new KegContext();

        public Task<ReplaceKeg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            Keg keg = new Keg();
            ReplaceKeg replaceKeg = new ReplaceKeg();
            try
            {

                if (id != 0)
                {
                    keg = _con.Kegs.Where(w => w.KegId.Equals(id.ToString())).FirstOrDefault();
                    keg.KegMl = 1000;
                    keg.KegState = KegState.New;
                    _con.Entry(keg).State = EntityState.Modified;
                    _con.SaveChanges();

                    replaceKeg.Id = keg.Id;
                    replaceKeg.KegId = keg.KegId;
                    replaceKeg.KegMl = keg.KegMl;
                    replaceKeg.KegState = keg.KegState;
                }
            }
            catch (Exception ex)
            {

                string exMsg = ex.Message;
            }
            return Task.FromResult(replaceKeg);

        }

        public Task<IEnumerable<ReplaceKeg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {

            List<ReplaceKeg> kegList = new List<ReplaceKeg>();
            try
            {
                List<Keg> tempkegList = _con.Kegs.ToList();
                foreach (Keg keg in tempkegList)
                {
                    keg.KegMl = 1000;
                    keg.KegState = KegState.New;
                    _con.Entry(keg).State = EntityState.Modified;
                    _con.SaveChanges();
                    ReplaceKeg repKeg = new ReplaceKeg() { Id = keg.Id, KegId = keg.KegId, KegMl = keg.KegMl, KegState = keg.KegState };
                    kegList.Add(repKeg);
                }
            }
            catch (Exception ex)
            {

                string exMsg = ex.Message;
            }
            return Task.FromResult<IEnumerable<ReplaceKeg>>(kegList);
        }

        public Task<ResourceCreationResult<ReplaceKeg, int>> CreateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ReplaceKeg> UpdateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<ReplaceKeg, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
