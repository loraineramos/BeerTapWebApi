using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTapHypermediaWebApi.Model.Helper
{
    public class ServiceUtil : ResponseUtility, IServiceUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="jObjectString"></param>
        /// <returns></returns>
        public string Post(string url, string jObjectString)
        {
            return PostWebResponseString(url, jObjectString);
        }
    }
}
