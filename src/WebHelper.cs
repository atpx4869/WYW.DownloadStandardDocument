using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WYW.DownloadStandardDocument
{
    internal class WebHelper
    {
        public static void DownloadFile(string url, string filePath)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(url, filePath);
                }
            }
            catch
            {
                Console.WriteLine($"{filePath} NOT FOUND");
            }

        }
        public static Response GetResponse(string keywords, int startPage,string condition)
        {
            int count = 50; // 每页50条记录，根据Response.count
            int startIndex = (startPage - 1) * count;
            // 访问第三页后需要验证码，但似乎结果不判断验证码
            string url = $"http://www.bzsou.cn/ibmb/solrData/search.do?searchString={keywords}&isTilu=false&isContent=false&isEnterprise=false&start={startIndex}&searchVerificationCode=3VND{condition}"; // 现行和未实施 &isActiveState=true&isUnCarryState=true
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create($"{url}");
            try
            {
                using (WebResponse wq = myReq.GetResponse())
                {
                    if (wq != null)
                    {
                        using (Stream s = wq.GetResponseStream())
                        {
                            using (StreamReader sr = new StreamReader(s, Encoding.UTF8))
                            {
                                var text = sr.ReadToEnd();
                                return JsonToObject<Response>(text);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                myReq = null;
            }
            return null;
        }

        private static T JsonToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
