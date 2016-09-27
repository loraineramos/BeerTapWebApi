using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BeerTapHypermediaWebApi.Model.Helper
{
    public class ResponseUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strURL"></param>
        /// <param name="jObject"></param>
        /// <returns></returns>
        public string PostWebResponseString(string strURL, string jObject)
        {
            string jDoc = string.Empty;
            try
            {
                var request = WebRequest.Create(strURL);
                request.ContentType = "application/json";

                request.Method = "POST";

                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jObject);
                request.ContentLength = bytes.Length;

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                using (StreamReader responseReader = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    string objresp = responseReader.ReadToEnd();
                    jDoc = JsonConvert.DeserializeObject(objresp).ToString();
                }
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }

            return jDoc;
        }
    }
}
