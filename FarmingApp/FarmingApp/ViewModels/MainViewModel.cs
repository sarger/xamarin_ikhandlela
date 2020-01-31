using FarmingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FarmingApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<PostCategory> _employeesList;

        public List<PostCategory> EmployeesList
        {
            get { return _employeesList; }
            set
            {
                _employeesList = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand { get; set; }

        public ICommand SendEmployeeMessageCommand { get; set; }

        public MainViewModel()
        {
            RefreshCommand = new RelayCommand(async () => await DownloadDataAsync());

            SendEmployeeMessageCommand = new RelayCommand<PostCategory>(SendEmployeeMessage);

            DownloadDataAsync();
        }

        private void SendEmployeeMessage(PostCategory postcategory)
        {
            Messenger.Default.Send(postcategory);
        }

        private async Task DownloadDataAsync()
        {
            var dataServices = new DataPostCategoryServices();

            EmployeesList = await dataServices.GetEmployeesAsync();
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
