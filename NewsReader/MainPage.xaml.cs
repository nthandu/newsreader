using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsReader.Services.Interfaces;
using NewsReader.Services.Models;
using Xamarin.Forms;

namespace NewsReader
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public ObservableCollection<NewsItem> NewsItems { get; set; }

        public MainPage()
        {
            InitializeComponent();
            NewsItems = new ObservableCollection<NewsItem>();
            BindingContext = this;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            
            await SetDataSource();
        }

        private async Task SetDataSource()
        {
            var newsReaderService = DependencyService.Resolve<INewsReaderService>();
            var items = await newsReaderService.GetNewsFeedAsync();
            foreach (var item in items)
            {
                NewsItems.Add(item);
            }
        }
    }
}
