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
    public class PostDetailViewModel : INotifyPropertyChanged
    {
        private Post _selectedPost;

        public Post SelectedPost
        {
            get { return _selectedPost; }
            set
            {
                _selectedPost = value;
                OnPropertyChanged();
            }
        }


        private Post _postList;

        public Post post
        {
            get { return _postList; }
            set
            {
                _postList = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddPostCommand { get; set; }
            
        public ICommand EditPostCommand { get; set; }

        public ICommand DeletePostCommand { get; set; }

        public PostDetailViewModel()
        {
            _selectedPost = new Post();

            var dataServices = new DataPostServices();

           // AddPostCommand = new RelayCommand(async () => await dataServices.AddCategoriesAsync(SelectedPost));

          //  EditPostCommand = new RelayCommand(async () => await dataServices.EditPostAsync(SelectedPost));

          //  DeletePostCommand = new RelayCommand(async () => await dataServices.DeleteEmmployeeAsync(SelectedPost));

            Messenger.Default.Register<Post>(this, OnPostMessageReceived);
        }

        private void OnPostMessageReceived(Post Post)
        {
            SelectedPost = Post;
            DownloadDataAsync(Post.Id);
        }

    
        private async Task DownloadDataAsync(int Id)
        {
            try
            {
               

                post = await new DataPostServices().GetPostById(Id);
                post.Comments = await new DataUserCommentService().GetCommentByPostId(Id);
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
