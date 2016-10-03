using BeerTapHypermediaWebApi.Model;
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
    public static class KegHelper
    {
        /// <summary>
        /// This is to get the state of the keg based on ML
        /// </summary>
        /// <param name="kegMl"></param>
        /// <returns></returns>
        public static KegState GetKegState(int kegMl)
        {
            //0-250 ML Dry
            //251-499 AlmostEmpty
            //500-750 GoingDown
            //751-1000 New
            KegState returnKegState = KegState.Dry;

            //if (Enumerable.Range(0, 100).Contains(kegMl))
            //{
            //    returnKegState = KegState.Dry;
            //}
            if (Enumerable.Range(1, 299).Contains(kegMl))
            {
                returnKegState = KegState.AlmostEmpty;
            }
            if (Enumerable.Range(300, 749).Contains(kegMl))
            {
                returnKegState = KegState.GoingDown;
            }
            if (Enumerable.Range(750, 1000).Contains(kegMl))
            {
                returnKegState = KegState.New;
            }
            return returnKegState;
        }
    }
}
