using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace UILibrary.Helpers
{
    public class ApiHelper
    {
        // HttpClient will be opened one per application
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            // ApiClient.BaseAddress = new Uri("http://xkcd.com"); but we do 

            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // use json
        }
    }
}
