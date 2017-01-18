using System.Globalization;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace DataBoundPhoneApp
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            MessageBox.Show("!!!");
            //if (DataContext == null)
            //{
            //    string selectedIndex = "";
            //    if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            //    {
            //        int index = int.Parse(selectedIndex);
            //        MessageBox.Show(index.ToString(CultureInfo.InvariantCulture));
            //        //DataContext = App.ViewModel.Items[index];
            //    }
            //}
        }
    }
}