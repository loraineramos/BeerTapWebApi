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
    public class ReplaceKeg : IStatelessResource, IIdentifiable<int>
    //IStatefulResource<KegState>, IIdentifiable<int>, IStatefulKeg
    {
        /// <summary>
        /// Unique ID if the Office
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Keg Id
        /// </summary>
        public string KegId { get; set; }
        /// <summary>
        /// Keg Ml
        /// </summary>
        public int KegMl { get; set; }

        /// <summary>
        /// Keg State
        /// </summary>
        public KegState KegState { get; set; }
    }
}
