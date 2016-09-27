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
    public enum KegState
    {
        /// <summary>
        /// Keg State is New
        /// </summary>
        New,
        /// <summary>
        /// Keg State is Going Down
        /// </summary>
        GoingDown,
        /// <summary>
        /// Keg State is Almost Empty
        /// </summary>
        AlmostEmpty,
        /// <summary>
        /// Keg State is Dry
        /// </summary>
        Dry
    }
}
