using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermediaWebApi.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class KegAndKegOffice : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Unique Identifier of KegAndKegOffice
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Keg in KegOffice
        /// </summary>
        public Keg Keg { get; set; }
    }
}
