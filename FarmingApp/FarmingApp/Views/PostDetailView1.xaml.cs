using FarmingApp.Models;
using FarmingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FarmingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailView1 : ContentPage
    {
        public PostDetailViewModel viewModel;
        public PostDetailView1()
        {
            InitializeComponent();
            BindingContext = viewModel = new PostDetailViewModel();
        }

        private async void NavigateToPostDetailsPageView(object sender, EventArgs e)
        {
            try
            {
              //  var detailsPage = new PostDetailPageView();


              //  var selectedPost = ((ListView)sender).SelectedItem as Post;

               // viewModel.SendPostMessageCommand.Execute(selectedPost);

               // await Navigation.PushModalAsync(detailsPage);
            }
            catch (Exception exc)
            {
                throw;
            }
        }
    }
}