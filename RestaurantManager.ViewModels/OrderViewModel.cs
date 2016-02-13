using System.Collections.Generic;
using RestaurantManager.Models;
using RestaurantManager.Extensions;
using System;
using System.Collections.ObjectModel;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {

        public DelegateCommand<MenuItem> AddMenuItemCommand { get; private set; }



        public OrderViewModel()
        {
            AddMenuItemCommand = new DelegateCommand<MenuItem>(AddMenuItem);
        }

        private void AddMenuItem(MenuItem parameter)
        {
            this.CurrentlySelectedMenuItems.Add(parameter);
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.OnPropertyChanged("MenuItems");

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };

            this.OnPropertyChanged("CurrentlySelectedMenuItems");

        }

        public ObservableCollection<MenuItem> MenuItems { get; set; }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems { get; set; }


    }
}
