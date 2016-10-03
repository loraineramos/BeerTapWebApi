using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BeerTapHypermediaWebApi.Model;

namespace BeerTapHypermediaWebApi.Model
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStatefulKeg
    {
        /// <summary>
        /// This the state of the Kegs Offices
        /// </summary>
        KegState KegState { get; }

    }
}
