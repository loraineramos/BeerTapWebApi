using System;
using BeerTapHypermediaWebApi.Model.Enum;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;

namespace BeerTapHypermediaWebApi.Model
{
    /// <summary>
    /// A Sample Resource, used as a placeholder. To be removed after real-world API resources have been added.
    /// </summary>
    public class Keg : IStatefulResource<KegState>, IIdentifiable<int>, IStatefulKeg
    //IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// Unique Identifier for the BeerKeg
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// This is the Id of the Keg
        /// </summary>
        public string KegId { get; set; }
        /// <summary>
        /// Keg ML for the BeerKeg
        /// </summary>
        public int KegMl { get; set; }

        /// <summary>
        /// Description for the Beer
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// State of the Beer Keg
        /// </summary>
	    public KegState KegState { get; set; }

        ///// <summary>
        ///// State of the Kegs Offices
        ///// </summary>
        //public KegOfficeState KegOfficeState { get; }
        ///// <summary>
        ///// Office of the Keg
        ///// </summary>
        //public KegOffice KegOffice { get; set; }
    }


}
