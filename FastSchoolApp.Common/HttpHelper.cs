using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FastSchoolApp.Common
{
    /// <summary>
    /// 发送Http请求的帮助类
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// 请求的编码类型
        /// </summary>
        private static readonly Encoding UTF8Encoding = Encoding.UTF8;

        /// <summary>
        /// httpclient发送get请求
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <param name="authorization">登陆成功后拿到的key</param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public async static Task<string> HttpClientGetAsync(string url, string authorization = null, string contentType = "application/json")
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            HttpClient httpClient = new HttpClient(httpClientHandler);
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", authorization);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/json"));
            var httpResutl = await httpClient.GetStringAsync(url);
            return httpResutl;
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <param name="authorization">登陆成功后拿到的key</param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public async static Task<string> HttpWebRequestGetAsync(string url, string authorization = null, string contentType = "application/json")
        {
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = contentType;
            webRequest.Headers.Add("Authorization", authorization);
            var result = string.Empty;
            using (var response = (HttpWebResponse)webRequest.GetResponse())
            using (var streamRead = new StreamReader(response.GetResponseStream(), UTF8Encoding))
            {
                result = await streamRead.ReadToEndAsync();
            }
            return result;
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <param name="postData">请求的参数，json格式</param>
        /// <param name="authorization">登陆成功后拿到的key</param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static async Task<string> HttpPost(string url, string postData, string authorization = null, string contentType = "application/json")
        {
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.Method = "post";
            var bydas = Encoding.UTF8.GetBytes(postData);
            webRequest.ContentLength = bydas.Length;
            webRequest.Headers.Add("Authorization", authorization);
            string content = string.Empty;
            using (var stream = await webRequest.GetRequestStreamAsync())
            {
                stream.Write(bydas, 0, bydas.Length);
                using (HttpWebResponse myResponse = (HttpWebResponse)webRequest.GetResponse())
                using (StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8))
                {
                    content = await reader.ReadToEndAsync();
                }
            }
            return content;
        }

        /// <summary>
        /// put请求
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <param name="postData">请求的参数，json格式</param>
        /// <param name="authorization">登陆成功后拿到的key</param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static async Task<string> HttpPut(string url, string postData, string authorization = null, string contentType = "application/json")
        {
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = "application/json";
            webRequest.Method = "Put";
            var bydas = Encoding.UTF8.GetBytes(postData);
            webRequest.ContentLength = bydas.Length;
            webRequest.Headers.Add("Authorization", authorization);
            string result = string.Empty;
            using (var stream = await webRequest.GetRequestStreamAsync())
            {
                stream.Write(bydas, 0, bydas.Length);
                using (HttpWebResponse myResponse = (HttpWebResponse)webRequest.GetResponse())
                    if (myResponse.StatusCode == HttpStatusCode.OK)
                        using (StreamReader reader = new StreamReader(myResponse.GetResponseStream(), UTF8Encoding))
                        {
                            result = await reader.ReadToEndAsync();
                        }
            }
            return result;
        }

        /// <summary>
        /// delete请求
        /// </summary>
        /// <param name="url">请求的url地址</param>
        /// <param name="authorization">登陆成功后拿到的key</param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static async Task<string> HttpDelete(string url, string authorization = null, string contentType = "application/json")
        {
            HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
            webRequest.ContentType = contentType;
            webRequest.Method = "delete";
            webRequest.Headers.Add("Authorization", authorization);
            string result = string.Empty;
            using (var stream = await webRequest.GetRequestStreamAsync())
            using (HttpWebResponse myResponse = (HttpWebResponse)webRequest.GetResponse())
                if (myResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (StreamReader reader = new StreamReader(myResponse.GetResponseStream(), UTF8Encoding))
                    {
                        result = await reader.ReadToEndAsync();
                    }
                }
            return result;
        }
    }
}
