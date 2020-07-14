using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    public class NewsItemListViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;
        private const string _categoryAll = "ALL";
        private string _selectedCategory;
        private IList<NewsItem> _items;

        public ObservableCollection<NewsItem> NewsItems { get; set; }

        public string SelectedCategory
        {
            get { return _selectedCategory; }
            set { SetProperty(ref _selectedCategory, value, onChanged: OnSelectedCategoryChanged); }
        }

        public ObservableCollection<string> FilerSource { get; set; }

        public ICommand NewsItemSelectedCommand { get; set; }

        public NewsItemListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            NewsItems = new ObservableCollection<NewsItem>();
            FilerSource = new ObservableCollection<string>();
            NewsItemSelectedCommand = new Command(async (object obj) => await OnNewsItemSelected(obj));
        }

        public async Task Init()
        {
            var newsReaderService = DependencyService.Resolve<INewsReaderService>();
            _items = await newsReaderService.GetNewsFeedAsync();
            // TODO: GetNewsFeedAsync need to retun the model with items and categories.
            // At the moment, its returning list of items. So we are extracting the categories from the news items.
            SetFilterSource(_items);
            FilterItemsByCategory(_categoryAll);
        }

        private void SetFilterSource(IList<NewsItem> items)
        {
            
            var categories = items.Select(news => news.Category).Distinct();
            FilerSource.Clear();
            FilerSource.Add(_categoryAll);
            SelectedCategory = _categoryAll;
            foreach (var item in categories)
            {
                FilerSource.Add(item);
            }
        }

        private async Task OnNewsItemSelected(object obj)
        {
            if (!(obj is NewsItem newsItem))
                return;

            await _navigation.PushAsync(new NewsDetails(newsItem.Link));
        }

        private void OnSelectedCategoryChanged()
        {
            FilterItemsByCategory(SelectedCategory);
        }

        private void FilterItemsByCategory(string selectedCategory)
        {
            NewsItems.Clear();

            // Ideally the filtering should be happening on the services level
            // Pass in the category to service layer which filters the news items and returns the results.

            var filteredItems = _items.AsQueryable();

            if (selectedCategory != null &&
                selectedCategory!=_categoryAll)
            {
                filteredItems = filteredItems.Where(news => news.Category == selectedCategory);
            }

            foreach (var item in filteredItems)
            {
                NewsItems.Add(item);
            }
        }
    }
}
