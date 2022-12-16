using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _2_ClientWinform
{
    public class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitHttpClient()
        {
            ApiClient = new HttpClient();
            // apiClient.BaseAddress = new Uri(BASE_URL);

            //Fixer le content au format JSON
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
