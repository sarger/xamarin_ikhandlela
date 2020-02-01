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
    public partial class PostsPageView : ContentPage
    {
        public PostsViewModel viewModel;
        public PostsPageView()
        {
            InitializeComponent();
            BindingContext = viewModel = new PostsViewModel();
        }

        private async void NavigateToPostDetailsPageView(object sender, EventArgs e)
        {
            try
            {
                var postdetailPage = new PostDetailView1();
              

                var selectedPost = ((ListView)sender).SelectedItem as Post;

                viewModel.SendPostMessageCommand.Execute(selectedPost);

                await Navigation.PushModalAsync(postdetailPage);
            }
            catch (Exception exc)
            {
                throw;
            }
        }
    }
}