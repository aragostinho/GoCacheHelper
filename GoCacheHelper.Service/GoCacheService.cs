using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GoCacheHelper.Service
{
    public class GoCacheService : IGoCache
    {
        const string goCacheKey = "";
        string goCacheUrlAPI = @"https://api.gocache.com.br/v1/cache/{0}";
        string mainDomain = @"";

        public GoCacheService()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }


        public GoCacheResponse Remove(string url)
        {
            string[] urls = new string[1];
            urls[0] = url;
            return Remove(urls);
        }

        public GoCacheResponse Remove(string[] urls)
        {

            Uri URIGoCache = new Uri(string.Format(goCacheUrlAPI, mainDomain));
            GoCacheResponse returnResponse = new GoCacheResponse();
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("GoCache-Token", goCacheKey);


            string urlsString = $"urls[1]={urls[0]}";
            for (int i = 1; i < urls.Length; i++)
                urlsString = urlsString + $"&urls[{i + 1}]={urls[i]}";


            HttpRequestMessage messageCachedObject = new HttpRequestMessage()
            {
                Method = HttpMethod.Delete,
                RequestUri = URIGoCache,
                Content = new StringContent(urlsString)
            };
            Task<HttpResponseMessage> responseRemoveCache = httpClient.SendAsync(messageCachedObject);
            if (responseRemoveCache != null)
            {
                HttpResponseMessage responseMessage = responseRemoveCache.Result;
                returnResponse.CacheExpired = responseMessage.StatusCode == HttpStatusCode.OK || responseMessage.StatusCode == HttpStatusCode.Accepted;
                returnResponse.Response = responseMessage.ReasonPhrase;
            }
            return returnResponse;
        }

        public bool IsCached(string url)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("GoCache-Token", goCacheKey);

            Task<HttpResponseMessage> responseGetUnCachedObject = httpClient.GetAsync(url);
            HttpResponseHeaders headerUnCachedObject = responseGetUnCachedObject.Result.Headers;
            if (headerUnCachedObject.Contains("X-GoCache-CacheStatus"))
            {
                var cacheStatus = headerUnCachedObject.GetValues("X-GoCache-CacheStatus").First();
                if (cacheStatus == "HIT")
                    return true;
            }
            return false;
        }




    }
}
