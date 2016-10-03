using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTapHypermediaWebApi.Model
{
    public class KegContextInitializer : DropCreateDatabaseIfModelChanges<KegContext>
    {
        /// <summary>
        /// This is to create Keg Offices when DB was first initialize
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(KegContext context)
        {
            List<Office> kegOfficeList = new List<Office>()
            {
                new Office() {KegOfficeId = 1, KegOfficeName = "Vancouver"},
                new Office() {KegOfficeId = 2, KegOfficeName = "Regina"},
                new Office() {KegOfficeId = 3, KegOfficeName = "Winnipeg"},
                new Office() {KegOfficeId = 4, KegOfficeName = "Davidson (NC)"},
                new Office() {KegOfficeId = 5, KegOfficeName = "Manila Philippines"}
            };

            foreach (Office office in kegOfficeList)
            {
                context.KegOffices.Add(office);
            }

            List<Keg> kegList = new List<Keg>()
            {
                new Keg() {KegId = 1, KegOfficeId = 1, Description = "Light Beer", KegMl = 1000, KegState = KegState.New},
                new Keg() {KegId = 2, KegOfficeId = 1,  Description = "Medium Beer", KegMl = 1000, KegState = KegState.New},
                new Keg() {KegId = 3, KegOfficeId = 1,  Description = "Heavy Beer", KegMl = 1000, KegState = KegState.New},
                new Keg() {KegId = 4, KegOfficeId = 2,  Description = "Very Heavy Beer", KegMl = 1000, KegState = KegState.New},
                new Keg() {KegId = 5, KegOfficeId = 2,  Description = "Over Beer", KegMl = 1000, KegState = KegState.New}

            };

            foreach (Keg keg in kegList)
            {
                context.Kegs.Add(keg);
            }
            context.SaveChanges();
        }
    }
}
