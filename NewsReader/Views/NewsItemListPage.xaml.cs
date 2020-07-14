using System.ComponentModel;
using NewsReader.ViewModels;
using Xamarin.Forms;

namespace NewsReader.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewsItemListPage : ContentPage
    {

        NewsItemListViewModel _viewModel;

        public NewsItemListPage()
        {
            InitializeComponent();
            _viewModel = new NewsItemListViewModel(Navigation);
            BindingContext = _viewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            await _viewModel.Init();
        }
        
    }
}
