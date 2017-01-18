using System;
using System.Data.Services.Client;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using DataBoundPhoneApp.Duris4eDb;
using DataBoundPhoneApp.ViewModels;
using Microsoft.Phone.Controls;

namespace DataBoundPhoneApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly DataServiceCollection<holidays> _collection;

        public MainPage()
        {
            InitializeComponent();
            DataContext = App.ViewModel;

            var db = new Duris4eEntities(new Uri("http://develop.kibabiba.ru/Duris4eDataService.svc"));
            var query = from h in db.holidays select h;
            _collection = new DataServiceCollection<holidays>();
            _collection.LoadCompleted += CollectionLoadCompleted;
            _collection.LoadAsync(query);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }        

        private void CollectionLoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (_collection.Continuation != null)
                {
                    _collection.LoadNextPartialSetAsync();
                }
                else
                {
                    LayoutRoot.DataContext = _collection;
                    if (_collection.Count == 0)
                    {
                        MessageBox.Show("Data could not be returned from the data service.");
                    }
                }
            }
            else
            {
                MessageBox.Show(e.Error.ToString());
            }
        }

        private void MainLongListSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Если выбранный элемент равен NULL (ничего не выбрано), никакие действия не требуются
            if (MainLongListSelector.SelectedItem == null)
                return;

            MessageBox.Show((MainLongListSelector.SelectedItem as holidays).desc);
            // Переход на новую страницу
            //NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (MainLongListSelector.SelectedItem as ItemViewModel).ID, UriKind.Relative));

            // Сброс выбранного элемента в NULL (ничего не выбрано)
            MainLongListSelector.SelectedItem = null;
        }
    }
}