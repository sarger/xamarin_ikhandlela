using FarmingApp.Helper;
using FarmingApp.Models;
using Newtonsoft.Json;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FarmingApp.Services
{
    public class DataPostCategoryServices
    {


        public async Task<List<PostCategory>> GetPostCategorysAsync()
        {
            var httpClient = new HttpClient();

            try
            {
                var url = Settings.GetBaseURL(UrlAction.GetAllCategory.Value);

                var jsonResponse = await httpClient.GetStringAsync(url);

               
                var postcategoriesList = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<PostCategory>>(jsonResponse));


                return postcategoriesList;
            }
            catch (Exception exc)
            {
                CrossToastPopUp.Current.ShowToastMessage(exc.Message);
            }

            return null;
        }

        public async Task<List<PostCategory>> GetPostCategoryById(int Id)
        {
            var httpClient = new HttpClient();

            try
            {
                var url = Settings.GetBaseURL(UrlAction.GetCategoryById.Value);

                var jsonResponse = await httpClient.GetStringAsync(url);

                var postcategoriesList = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<PostCategory>>(jsonResponse));


                return postcategoriesList;
            }
            catch (Exception exc)
            {

                CrossToastPopUp.Current.ShowToastMessage(exc.Message);
            }

            return null;
        }


        public async Task AddPostCategoryAsync(PostCategory postcategory)
        {
            var httpClient = new HttpClient();

            var url = Settings.GetBaseURL(UrlAction.AddCategory.Value);
            
            var jsonPostCategory = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(postcategory));
            
            HttpContent httpContent = new StringContent(jsonPostCategory);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync(new Uri(url), httpContent);
        }

        public async Task DeleteEmmployeeAsync(PostCategory postcategory)
        {
            var httpClient = new HttpClient();

            var url = Settings.GetBaseURL(UrlAction.DeleteCategory.Value);

            var response = await httpClient.DeleteAsync(Settings.GetBaseURL(url) + postcategory.Id);
        }

        public async Task EditPostCategoryAsync(PostCategory postcategory)
        {
            var httpClient = new HttpClient();

           // var jsonPostCategory = await JsonConvert.SerializeObjectAsync(postcategory);
            var jsonPostCategory = await  Task.Factory.StartNew(() => JsonConvert.SerializeObject(postcategory));

            var httpContent = new StringContent(jsonPostCategory);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var url = Settings.GetBaseURL(UrlAction.EditCategory.Value);

            var response = await httpClient.PutAsync(Settings.GetBaseURL(url) + postcategory.Id, httpContent);
        }
    }

}
