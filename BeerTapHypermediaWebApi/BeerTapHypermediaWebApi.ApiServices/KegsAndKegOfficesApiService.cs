using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeerTapHypermediaWebApi.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapHypermediaWebApi.ApiServices
{
    public class KegsAndKegOfficesApiService : IKegsAndKegOfficesApiService
    {
        KegContext _con = new KegContext();

        public Task<IEnumerable<KegAndKegOffice>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            List<KegAndKegOffice> kegOfficeList = new List<KegAndKegOffice>();
            KegAndKegOffice kegOffice = new KegAndKegOffice();
            List<Keg> keg = new List<Keg>();
            int officeId = 0;
            int kegId = 0;
            try
            {
                bool officeidToken = context.UriParameters.GetByName<int>("kegOfficeId").HasValue;
                if (officeidToken) { officeId = context.UriParameters.GetByName<int>("kegOfficeId").Value; }

                bool kegIdToken = context.UriParameters.GetByName<int>("kegId").HasValue;
                if (kegIdToken) { kegId = context.UriParameters.GetByName<int>("kegId").Value; }
                if (officeidToken && !kegIdToken)
                {
                    keg = new List<Keg>();
                    keg = _con.Kegs.Where(w => w.KegOfficeId.Equals(officeId)).ToList();
                    foreach (Keg tempKeg in keg)
                    {
                        kegOffice = new KegAndKegOffice();
                        kegOffice.Keg = tempKeg;
                        kegOfficeList.Add(kegOffice);
                    }
                }
                else
                {
                    keg = new List<Keg>();
                    keg = _con.Kegs.Where(w => w.KegOfficeId.Equals(officeId) && w.KegId.Equals(kegId)).ToList();
                    foreach (Keg tempKeg in keg)
                    {
                        kegOffice = new KegAndKegOffice();
                        kegOffice.Keg = tempKeg;
                        kegOfficeList.Add(kegOffice);
                    }
                }


            }
            catch (Exception ex)
            {

                string exMsg = ex.Message;
            }
            return Task.FromResult<IEnumerable<KegAndKegOffice>>(kegOfficeList);
        }
    }
}
