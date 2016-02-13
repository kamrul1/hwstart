using System.ComponentModel;
using System.Runtime.CompilerServices;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel: INotifyPropertyChanged
    {
        protected RestaurantContext Repository { get; private set; }

        public ViewModel()
        {
            LoadData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void LoadData()
        {
            //this.Repository = new RestaurantContext();
            //await this.Repository.InitializeContextAsync();

            this.Repository = await RestaurantContextFactory.GetRestaurantContextAsync();

            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();
    }
}
