using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _2_ClientWinform
{
    public class ApiContact
    {
        //Pour un front winform, installer le package Nuget: Microsoft.AspNet.WebApi.Client

        private string BASE_URL = "http://localhost:49991/api/";


     

        public async Task<List<Contact>> LoadContactsAsync()
           
        {
            using (HttpResponseMessage reponse = await ApiHelper.ApiClient.GetAsync(BASE_URL + "Contacts"))
            {
                if (reponse.IsSuccessStatusCode)
                {
                    List<Contact> lst = await reponse.Content.ReadAsAsync<List<Contact>>();
                    return lst;
                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }

        }

        public async Task<Uri> AddContactAsync(Contact c)
        {
            using (HttpResponseMessage reponse = await ApiHelper.ApiClient.PostAsJsonAsync(BASE_URL+"Contacts", c))
            {
                reponse.EnsureSuccessStatusCode();
                return reponse.Headers.Location;
            }
        }

        public async Task<HttpStatusCode>  DeleteContactAsync(int id)
        {
            using (var reponse = await ApiHelper.ApiClient.DeleteAsync(BASE_URL+$"Contacts/{id}"))
            {
                return reponse.StatusCode;
            }
        }

        public async Task<HttpStatusCode> UpdateContactAsync(Contact c)
        {
            using (var reponse = await ApiHelper.ApiClient.PutAsJsonAsync(BASE_URL+"Contacts", c))
            {
                return reponse.StatusCode;
            }
        }

    }
}
