using _3_ClientMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace _3_ClientMVC.ApiClients
{
    public class ApiContact
    {
        //Installer le package Nuget Microsoft.AspNet.WebApi.Client

        private string BASE_URL = "http://localhost:49991/api/";

        public async Task<List<Contact>> GetAllContactAsync()
        {
            using (var reponse = await HttpClientHelper.ApiClient.GetAsync(BASE_URL+"Contacts"))
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

        public async Task<Contact> GetByIdAsync(int id)
        {
            using (var reponse = await HttpClientHelper.ApiClient.GetAsync(BASE_URL+$"Contacts/{id}"))
            {
                if (reponse.IsSuccessStatusCode)
                {
                     return await reponse.Content.ReadAsAsync<Contact>();
                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }
        }

        public async Task<Uri> InsertContactAsync(Contact c)
        {
            using (var reponse = await HttpClientHelper.ApiClient.PostAsJsonAsync(BASE_URL+"Contacts", c))
            {
                reponse.EnsureSuccessStatusCode();
                return reponse.Headers.Location;
            }
        }

        public async Task<HttpStatusCode> UpdateContactAsync(Contact c)
        {
            using (var reponse = await HttpClientHelper.ApiClient.PutAsJsonAsync(BASE_URL+"Contacts", c))
            {
                return HttpStatusCode.OK;
            }
        }

        public async Task<HttpStatusCode> DeleteContactAsync(int id)
        {
            using (var reponse= await HttpClientHelper.ApiClient.DeleteAsync(BASE_URL+$"Contacts/{id}"))
            {
                return reponse.StatusCode;
            }
        }

        public async Task<byte[]> DownloadCsvAsync()
        {
            return await HttpClientHelper.ApiClient.GetByteArrayAsync(BASE_URL + "Contacts?format=csv");
        }
    }
}