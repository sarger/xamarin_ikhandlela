using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestfulApplication.Models;
using RestfulApplication.XamarinForms.Models;
using RestfulApplication.XamarinForms.Services;

namespace RestfulApplication.Clients.Core.Services
{
    public class DataPostCategoryServices
    {

       

        public async Task<List<PostCategory>> GetEmployeesAsync()
        {
            var httpClient = new HttpClient();

            try
            {
                var url = Settings.GetBaseURL(UrlAction.GetAllCategory.Value);

                var jsonResponse = await httpClient.GetStringAsync(url);

                var employeesList = await JsonConvert.DeserializeObjectAsync<List<PostCategory>>(jsonResponse);

                return employeesList;  
            }
            catch(Exception exc)
            {
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

                var employeesList = await JsonConvert.DeserializeObjectAsync<List<PostCategory>>(jsonResponse);

                return employeesList;
            }
            catch (Exception exc)
            {
            }

            return null;
        }


        public async Task AddEmployeeAsync(PostCategory employee)
        {
            var httpClient = new HttpClient();

            var url = Settings.GetBaseURL(UrlAction.AddCategory.Value);

            var jsonEmployee = await JsonConvert.SerializeObjectAsync(employee);

            HttpContent httpContent = new StringContent(jsonEmployee);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.PostAsync(new Uri(url), httpContent);
        }

        public async Task DeleteEmmployeeAsync(PostCategory employee)
        {
            var httpClient = new HttpClient();

            var url = Settings.GetBaseURL(UrlAction.DeleteCategory.Value);

            var response = await httpClient.DeleteAsync(Settings.GetBaseURL(url) + employee.Id);
        }

        public async Task EditEmployeeAsync(PostCategory employee)
        {
            var httpClient = new HttpClient();
            
            var jsonEmployee = await JsonConvert.SerializeObjectAsync(employee);

            var httpContent = new StringContent(jsonEmployee);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            httpClient.DefaultRequestHeaders.Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var url = Settings.GetBaseURL(UrlAction.EditCategory.Value);

            var response = await httpClient.PutAsync(Settings.GetBaseURL(url) + employee.Id, httpContent);
        }
    }
}
