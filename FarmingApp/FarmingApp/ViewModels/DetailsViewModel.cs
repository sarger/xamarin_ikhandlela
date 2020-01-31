﻿using System;
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

namespace FarmingApp.ViewModels
{
    public class DetailsViewModel : INotifyPropertyChanged
    {
        private PostCategory _selectedEmployee;

        public PostCategory SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddEmployeeCommand { get; set; }

        public ICommand EditEmployeeCommand { get; set; }

        public ICommand DeleteEmployeeCommand { get; set; }

        public DetailsViewModel()
        {
            _selectedEmployee = new PostCategory();

            var dataServices = new DataPostCategoryServices();

            AddEmployeeCommand = new RelayCommand(async () => await dataServices.AddEmployeeAsync(SelectedEmployee));

            EditEmployeeCommand = new RelayCommand(async () => await dataServices.EditEmployeeAsync(SelectedEmployee));

            DeleteEmployeeCommand = new RelayCommand(async () => await dataServices.DeleteEmmployeeAsync(SelectedEmployee));

            Messenger.Default.Register<PostCategory>(this, OnEmployeeMessageReceived);
        }

        private void OnEmployeeMessageReceived(PostCategory employee)
        {
            SelectedEmployee = employee;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}