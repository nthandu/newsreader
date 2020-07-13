using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using NewsReader.Services.Interfaces;
using NewsReader.Services.Models;
using NewsReader.Views;
using Xamarin.Forms;

namespace NewsReader.ViewModels
{
    /// <summary>
    /// ViewModel for the NewsListView.
    /// </summary>
    public class NewsItemListViewModel
    {
        private readonly INavigation _navigation;

        public ObservableCollection<NewsItem> NewsItems { get; set; }

        public ICommand NewsItemSelectedCommand { get; set; }

        public NewsItemListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            NewsItems = new ObservableCollection<NewsItem>();
            NewsItemSelectedCommand = new Command(async (object obj) => await OnNewsItemSelected(obj));
        }

        public async Task Init()
        {
            var newsReaderService = DependencyService.Resolve<INewsReaderService>();
            var items = await newsReaderService.GetNewsFeedAsync();
            foreach (var item in items)
            {
                NewsItems.Add(item);
            }
        }

        private async Task OnNewsItemSelected(object obj)
        {
            if (!(obj is NewsItem newsItem))
                return;

            await _navigation.PushAsync(new NewsDetails(newsItem.Link));
        }
    }
}
