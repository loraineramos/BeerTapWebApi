using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BeerTapHypermediaWebApi.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class KegContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Keg> Kegs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<KegOffice> KegOffices { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public KegContext() : base ("KegContext")
        //{
        //    Database.SetInitializer<KegContext>(new KegContextInitializer());
        //    //new KegContextInitializer().Seed();
        //}
    }
}
