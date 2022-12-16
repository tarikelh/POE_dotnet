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
    public class ApiProduit
    {
        private string BASE_URL = "http://localhost:62673/api/";

        public async Task<List<Produit>> GetAllProducts()
        {
            using (var reponse = await HttpClientHelper.ApiClient.GetAsync(BASE_URL+"Produits"))
            {
                if (reponse.IsSuccessStatusCode)
                {
                    List<Produit> lst = await reponse.Content.ReadAsAsync<List<Produit>>();
                    return lst;
                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }
        }

        public async Task<byte[]> GetImageProduitAsync(int id)
        {
            using (var reponse = await HttpClientHelper.ApiClient.GetAsync(BASE_URL + $"Produits/Image/{id}"))
            {
                if (reponse.IsSuccessStatusCode)
                {
                    return await reponse.Content.ReadAsByteArrayAsync();

                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }
        }

        public async Task<Produit> GetProduitById(int id)
        {
            using (var reponse = await HttpClientHelper.ApiClient.GetAsync(BASE_URL + $"Produits/{id}"))
            {
                if (reponse.IsSuccessStatusCode)
                {
                    return await reponse.Content.ReadAsAsync<Produit>();
                    
                }
                else
                {
                    throw new Exception(reponse.ReasonPhrase);
                }
            }
        }

      

        public async Task<HttpStatusCode> UpdateAsync(MultipartFormDataContent multipart)
        {
            using (var reponse = await HttpClientHelper.ApiClient.PutAsync(BASE_URL + $"Produits", multipart))
            {

                return reponse.StatusCode; 

            }
        }

        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            using (var reponse = await HttpClientHelper.ApiClient.DeleteAsync(BASE_URL + $"Produits/Delete/{id}"))
            {

                return reponse.StatusCode;

            }
        }

        public async Task<HttpStatusCode> AddProductAsync(MultipartFormDataContent multipart)
        {
            using (var reponse = await HttpClientHelper.ApiClient.PostAsync(BASE_URL + "Produits", multipart))
            {

                return reponse.StatusCode;

            }
        }
    }
}