using FarmingApp.Models;
using FarmingApp.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FarmingApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<PostCategory> _postcategoriesList;

        public List<PostCategory> PostCategoriesList
        {
            get { return _postcategoriesList; }
            set
            {
                _postcategoriesList = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand { get; set; }

        public ICommand SendPostCategoryMessageCommand { get; set; }

        public MainViewModel()
        {
            RefreshCommand = new RelayCommand(async () => await DownloadDataAsync());

            SendPostCategoryMessageCommand = new RelayCommand<PostCategory>(SendPostCategoryMessage);

            DownloadDataAsync();
        }

        private void SendPostCategoryMessage(PostCategory postcategory)
        {
            Messenger.Default.Send(postcategory);
        }

        private async Task DownloadDataAsync()
        {
            try
            {
                var dataServices = new DataPostCategoryServices();

                PostCategoriesList = await dataServices.GetPostCategorysAsync();
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
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
