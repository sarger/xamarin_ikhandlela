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
    public partial class MainPageView : ContentPage
    {
        public PostCategoriesViewModel viewModel;
        public MainPageView()
        {
            InitializeComponent();
                 BindingContext = viewModel = new PostCategoriesViewModel();
        }

        private async void NavigateToDetailsPageView(object sender, EventArgs e)
        {
            try
            {
                var detailsPage = new PostsPageView();


                var selectedPostCategory = ((ListView)sender).SelectedItem as PostCategory;

                viewModel.SendPostCategoryMessageCommand.Execute(selectedPostCategory);

                await Navigation.PushModalAsync(detailsPage);
            }
            catch (Exception exc)
            {
                throw;
            }
        }

        private async void NavigateToDetailsPage(object sender, EventArgs e)
        {
            try
            {
                var detailsPage = new PostsPageView();

                await Navigation.PushModalAsync(detailsPage);
            }
            catch (Exception exc)
            {
                throw;
            }
        }
    }
}