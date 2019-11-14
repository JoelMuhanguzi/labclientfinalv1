using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Collections.Generic;
using System.Net.Http;


namespace projectTest1
{

    public class Support
    {
        public enum URL_TYPE { VALUES, SWITCH };
        private static string GetUrl(URL_TYPE type)
        {
            string url = "http://serverNameAndPort/api/";
            switch (type)
            {
                case URL_TYPE.VALUES:
                    url += "values";
                    break;
                case URL_TYPE.SWITCH:
                    url += "switch";
                    break;
                default:
                    break;
            }
            return url;
        }
        public static string PostToServer(string url, List<KeyValuePair<string, string>> paramters)
        {
            var client = new HttpClient();
            var content = new FormUrlEncodedContent(paramters);
            var response = client.PostAsync(url, content).GetAwaiter().GetResult();
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return "Failed to send data to server";
            }
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
        public static string GetFromServer(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).GetAwaiter().GetResult();
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {               
                return "Failed to get data to server";
            }
            return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
        //public static string PostToServer(string url, List<KeyValuePair<string, string>> paramters, URL_TYPE type)
        //{
        //    var client = new HttpClient();
        //    var content = new FormUrlEncodedContent(paramters);
        //    var response = client.PostAsync(GetUrl(type), content).GetAwaiter().GetResult();
        //    if (response.StatusCode != System.Net.HttpStatusCode.OK)
        //    {
        //        return "Failed to send data to server";
        //    }
        //    return response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        //}
    }
}
