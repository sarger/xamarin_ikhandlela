using FarmingApp.Helper;
using FarmingApp.Models;
using Newtonsoft.Json;
using Plugin.Toast;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FarmingApp.Services
{
    public class DataPostServices
    {


        public async Task<List<Post>> GetPostsAsync()
        {
            var httpClient = new HttpClient();

            try
            {
                var url = Settings.GetBaseURL(UrlAction.GetAllPost.Value);

                var jsonResponse = await httpClient.GetStringAsync(url);

               
                var postcategoriesList = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Post>>(jsonResponse));


                return postcategoriesList;
            }
            catch (Exception exc)
            {
                CrossToastPopUp.Current.ShowToastMessage(exc.Message);
            }

            return null;
        }

        public async Task<Post> GetPostById(int Id)
        {
            var httpClient = new HttpClient();

            try
            {
                var url = Settings.GetBaseURL(UrlAction.GetPostById.Value)+ Id;

                var jsonResponse = await httpClient.GetStringAsync(url);

                var postcategoriesList = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Post>>(jsonResponse));
                
                return postcategoriesList.FirstOrDefault();
            }
            catch (Exception exc)
            {

                CrossToastPopUp.Current.ShowToastMessage(exc.Message);
            }

            return null;
        }

        public async Task<List<Post>> GetPostByCategoryId(int Id)
        {
            var httpClient = new HttpClient();

            try
            {
                var url = Settings.GetBaseURL(UrlAction.GetPostByCategoryId.Value);

                var jsonResponse = await httpClient.GetStringAsync(url+ Id);

                var postcategoriesList = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Post>>(jsonResponse));


                return postcategoriesList;
            }
            catch (Exception exc)
            {

                CrossToastPopUp.Current.ShowToastMessage(exc.Message, Plugin.Toast.Abstractions.ToastLength.Long);
            }

            return null;
        }
        public async Task AddPostAsync(Post post)
        {
            var httpClient = new HttpClient();

            var url = Settings.GetBaseURL(UrlAction.AddPost.Value);
            
            var jsonPost = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(post));
            
            HttpContent httpContent = new StringContent(jsonPost);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync(new Uri(url), httpContent);
        }

        public async Task DeleteEmmployeeAsync(Post post)
        {
            var httpClient = new HttpClient();

            var url = Settings.GetBaseURL(UrlAction.DeletePost.Value);

            var response = await httpClient.DeleteAsync(Settings.GetBaseURL(url) + post.Id);
        }

        public async Task EditPostAsync(Post post)
        {
            var httpClient = new HttpClient();

           // var jsonPost = await JsonConvert.SerializeObjectAsync(post);
            var jsonPost = await  Task.Factory.StartNew(() => JsonConvert.SerializeObject(post));

            var httpContent = new StringContent(jsonPost);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var url = Settings.GetBaseURL(UrlAction.EditPost.Value);

            var response = await httpClient.PutAsync(Settings.GetBaseURL(url) + post.Id, httpContent);
        }
    }

}
