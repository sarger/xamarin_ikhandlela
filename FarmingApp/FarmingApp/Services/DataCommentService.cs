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
    public class DataUserCommentService
    {


        public async Task<List<UserComment>> GetUserCommentsAsync()
        {
            var httpClient = new HttpClient();

            try
            {
                var url = Settings.GetBaseURL(UrlAction.GetAllComments.Value);

                var jsonResponse = await httpClient.GetStringAsync(url);

               
                var postcategoriesList = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<UserComment>>(jsonResponse));


                return postcategoriesList;
            }
            catch (Exception exc)
            {
                CrossToastPopUp.Current.ShowToastMessage(exc.Message);
            }

            return null;
        }

        public async Task<UserComment> GetCommentById(int Id)
        {
            var httpClient = new HttpClient();

            try
            {
                var url = Settings.GetBaseURL(UrlAction.GetCommentById.Value)+ Id;

                var jsonResponse = await httpClient.GetStringAsync(url);

                var postcategoriesList = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<UserComment>>(jsonResponse));
                
                return postcategoriesList.FirstOrDefault();
            }
            catch (Exception exc)
            {

                CrossToastPopUp.Current.ShowToastMessage(exc.Message);
            }

            return null;
        }

        public async Task<List<UserComment>> GetCommentByPostId(int Id)
        {
            var httpClient = new HttpClient();

            try
            {
                var url = Settings.GetBaseURL(UrlAction.GetCommentsByPostId.Value);

                var jsonResponse = await httpClient.GetStringAsync(url+ Id);

                var postcategoriesList = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<UserComment>>(jsonResponse));


                return postcategoriesList;
            }
            catch (Exception exc)
            {

                CrossToastPopUp.Current.ShowToastMessage(exc.Message, Plugin.Toast.Abstractions.ToastLength.Long);
            }

            return null;
        }
        public async Task AddUserCommentAsync(UserComment UserComment)
        {
            var httpClient = new HttpClient();

            var url = Settings.GetBaseURL(UrlAction.AddComment.Value);
            
            var jsonUserComment = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(UserComment));
            
            HttpContent httpContent = new StringContent(jsonUserComment);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync(new Uri(url), httpContent);
        }

        public async Task DeleteEmmployeeAsync(UserComment UserComment)
        {
            var httpClient = new HttpClient();

            var url = Settings.GetBaseURL(UrlAction.DeleteComment.Value);

            var response = await httpClient.DeleteAsync(Settings.GetBaseURL(url) + UserComment.Id);
        }

        public async Task EditUserCommentAsync(UserComment UserComment)
        {
            var httpClient = new HttpClient();

     
            var jsonUserComment = await  Task.Factory.StartNew(() => JsonConvert.SerializeObject(UserComment));

            var httpContent = new StringContent(jsonUserComment);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var url = Settings.GetBaseURL(UrlAction.EditComment.Value);

            var response = await httpClient.PutAsync(Settings.GetBaseURL(url) + UserComment.Id, httpContent);
        }
    }

}
