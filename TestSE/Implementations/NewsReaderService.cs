using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using NewsReader.Services.Extensions;
using NewsReader.Services.Interfaces;
using NewsReader.Services.Models;

namespace NewsReader.Services.Implementations
{
    public class NewsReaderService : INewsReaderService
    {
        #region Private Members

        IFeedSourceProvider _feedSourceProvider;
        IFeedReaderService _feedReaderService;

        #endregion

        #region Constructor

        public NewsReaderService(IFeedSourceProvider feedSourceProvider, IFeedReaderService feedReaderService)
        {
            _feedSourceProvider = feedSourceProvider;
            _feedReaderService = feedReaderService;
        }

        #endregion

        #region INewsReader implementation

        public async Task<IList<NewsItem>> GetNewsFeedAsync()
        {
            var feedToReturn = new List<NewsItem>();
            var feedSources = _feedSourceProvider.GetSources();
            foreach (var feedSource in feedSources)
            {
                var feed = await _feedReaderService.GetFeedAsync(feedSource);
                if (feed != null && feed.Items != null)
                {
                    feedToReturn.AddRange(feed.Items.Select(s => s.ToNewsItem(feed.Title)));
                }
            }
            return feedToReturn.OrderByDescending(s=>s.PublishedDate).ToList();
        }

        #endregion

    }
}
