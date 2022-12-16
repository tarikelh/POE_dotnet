using _3_ClientMVC.Dtos;
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
    public class ApiUser
    {
        private string BASE_URL = "http://localhost:56038/api/";

        public async Task<List<User>> GetAllUserAsync()
        {
            using (var reponse = await HttpClientHelper.ApiClient.GetAsync(BASE_URL+"Users"))
            {
                if (reponse.IsSuccessStatusCode)
                {
                    List<User> lst = await reponse.Content.ReadAsAsync<List<User>>();
                    return lst;
                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }
        }

        public async Task<Uri> AddUserAsync(User u)
        {
            using (var reponse = await HttpClientHelper.ApiClient.PostAsJsonAsync(BASE_URL+"Users/Save", u))
            {
                reponse.EnsureSuccessStatusCode();
                return reponse.Headers.Location;
            }
        }

        public async Task<User> FindByIdAsync(int id)
        {
            using (var reponse = await HttpClientHelper.ApiClient.GetAsync(BASE_URL+$"Users/{id}"))
            {
                if (reponse.IsSuccessStatusCode)
                {
                    return await reponse.Content.ReadAsAsync<User>();
                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }
        }

        public async Task<HttpStatusCode> UpdateUserAsync(User u)
        {
            using (var reponse = await HttpClientHelper.ApiClient.PutAsJsonAsync(BASE_URL + "Users/Update", u))
            {
                return reponse.StatusCode;
            }
        }

        public async Task<HttpStatusCode> DeleteUserAsync(int id)
        {
            using (var reponse = await HttpClientHelper.ApiClient.DeleteAsync(BASE_URL + $"Users/Delete/{id}"))
            {
                return reponse.StatusCode;
            }
        }

        public async Task<HttpStatusCode> CheckLoginAsync(LoginDTO loginDto)
        {
            using (var reponse = await HttpClientHelper.ApiClient.PostAsJsonAsync(BASE_URL + "check-login", loginDto))
            {
                return reponse.StatusCode;
            }
        }
    }
}