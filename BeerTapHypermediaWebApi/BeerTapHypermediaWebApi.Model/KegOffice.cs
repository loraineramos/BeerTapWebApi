﻿using BeerTapHypermediaWebApi.Model.Enum;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTapHypermediaWebApi.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class KegOffice : IStatelessResource, IIdentifiable<int>
    {
        /// <summary>
        /// This is the Unique Identifier of the Keg Office
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This is the Id of the Keg Offices
        /// </summary>
        public string KegOfficeId { get; set; }

        /// <summary>
        /// This is the state of the Keg Offices
        /// </summary>
        public KegOfficeState KegOfficeState { get; set; }

        /// <summary>
        /// This is the Office Name of the Keg Offices
        /// </summary>
        public string KegOfficeName { get; set; }
        /// <summary>
        /// This is the Beer Keg in the Office
        /// </summary>
        public Keg Keg { get; set; }

    
    }


}