using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTapHypermediaWebApi.Model
{
    public class MyKeg
    {
        /// <summary>
        /// This is a sample data to update Beer Keg
        /// </summary>
        /// <returns></returns>
        public Keg GetKeg(string kegId)
        {
            List<Keg> beerKegList = GetListOfKegs();
            return beerKegList.Where(w => w.KegId.Equals(kegId)).FirstOrDefault();
        }
        /// <summary>
        /// Sample List of Beer Kegs
        /// </summary>
        public List<Keg> GetListOfKegs()
        {
            List<Keg> kegList = new List<Keg>()
            {
                //new Keg() {Id = 1, KegId = "1", Description = "Light Beer", KegMl = 1000, KegState = KegState.New, KegOffice = GetListOfKegOffices().Where(w=> w.KegOfficeId.Equals("1")).FirstOrDefault() },
                //new Keg() { Id = 2, KegId = "2", Description = "Medium Beer", KegMl = 1000, KegState = KegState.New, KegOffice = GetListOfKegOffices().Where(w=> w.KegOfficeId.Equals("2")).FirstOrDefault()  },
                //new Keg() { Id = 3, KegId = "3", Description = "Heavy Beer", KegMl = 1000, KegState = KegState.New, KegOffice = GetListOfKegOffices().Where(w=> w.KegOfficeId.Equals("3")).FirstOrDefault()  },
                //new Keg() { Id = 4, KegId = "4", Description = "Very Heavy Beer", KegMl = 1000, KegState = KegState.New, KegOffice = GetListOfKegOffices().Where(w=> w.KegOfficeId.Equals("4")).FirstOrDefault()  },
                //new Keg() { Id = 5, KegId = "5", Description = "Over Beer", KegMl = 1000, KegState = KegState.New, KegOffice = GetListOfKegOffices().Where(w=> w.KegOfficeId.Equals("5")).FirstOrDefault()  }

            };

            return kegList;
        }
        /// <summary>
        /// this is to get the Keg office by office id
        /// </summary>
        /// <param name="kegOfficeId"></param>
        /// <returns></returns>
        public KegOffice GetKegOffice(string kegOfficeId)
        {
            List<KegOffice> kegOfficeList = GetListOfKegOffices();
            return kegOfficeList.Where(w => w.KegOfficeId.Equals(kegOfficeId)).FirstOrDefault();
        }
        /// <summary>
        /// Get the List of Kegs Offices
        /// </summary>
        /// <returns></returns>
        public List<KegOffice> GetListOfKegOffices()
        {
            List<KegOffice> kegOfficeList = new List<KegOffice>()
            {
                new KegOffice() {  Id=1, KegOfficeId="1", KegOfficeName="Vancouver" },
                new KegOffice() {  Id=1, KegOfficeId="2", KegOfficeName="Regina" },
                new KegOffice() {  Id=1, KegOfficeId="3", KegOfficeName="Winnipeg" },
                new KegOffice() {  Id=1, KegOfficeId="4", KegOfficeName="Davidson (NC)" },
                new KegOffice() {  Id=1, KegOfficeId="5", KegOfficeName="Manila Philippines" }
            };
            return kegOfficeList;
        }

    }
}
