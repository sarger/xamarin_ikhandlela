using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using FarmingApp.Models;
using FarmingApp.Services;
using Plugin.Toast;

namespace FarmingApp.ViewModels
{
    public class PostsViewModel : INotifyPropertyChanged
    {
        private PostCategory _selectedPostCategory;

        public PostCategory SelectedPostCategory
        {
            get { return _selectedPostCategory; }
            set
            {
                _selectedPostCategory = value;
                OnPropertyChanged();
            }
        }


        private List<Post> _postList;

        public List<Post> PostList
        {
            get { return _postList; }
            set
            {
                _postList = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddPostCategoryCommand { get; set; }

        public ICommand SendPostMessageCommand { get; set; }

        public ICommand EditPostCategoryCommand { get; set; }

        public ICommand DeletePostCategoryCommand { get; set; }

        public PostsViewModel()
        {
            _selectedPostCategory = new PostCategory();

            var dataServices = new DataPostCategoryServices();

            SendPostMessageCommand = new RelayCommand<Post>(SendPostMessage);

            // AddPostCategoryCommand = new RelayCommand(async () => await dataServices.AddCategoriesAsync(SelectedPostCategory));

            //  EditPostCategoryCommand = new RelayCommand(async () => await dataServices.EditPostCategoryAsync(SelectedPostCategory));

            //  DeletePostCategoryCommand = new RelayCommand(async () => await dataServices.DeleteEmmployeeAsync(SelectedPostCategory));

            Messenger.Default.Register<PostCategory>(this, OnPostCategoryMessageReceived);
        }

        private void OnPostCategoryMessageReceived(PostCategory postcategory)
        {
            SelectedPostCategory = postcategory;
            DownloadDataAsync(postcategory.Id);
        }

        private void SendPostMessage(Post post)
        {
            Messenger.Default.Send(post);
        }

        private async Task DownloadDataAsync(int Id)
        {
            try
            {
                var dataServices = new DataPostServices();

                PostList = await dataServices.GetPostByCategoryId(Id);
            }
            catch (Exception ex)
            {
                CrossToastPopUp.Current.ShowToastMessage(ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
