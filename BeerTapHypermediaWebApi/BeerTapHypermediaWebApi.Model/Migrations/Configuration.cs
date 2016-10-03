namespace BeerTapHypermediaWebApi.Model.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BeerTapHypermediaWebApi.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<BeerTapHypermediaWebApi.Model.KegContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BeerTapHypermediaWebApi.Model.KegContext"; ;
        }

        protected override void Seed(BeerTapHypermediaWebApi.Model.KegContext context)
        {
            //  This method will be called after migrating to the latest version.

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
