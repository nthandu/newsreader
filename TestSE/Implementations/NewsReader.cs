using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using NewsReader.Services.Interfaces;
using NewsReader.Services.Models;

namespace NewsReader.Services.Implementations
{
    public class NewsReader : INewsReader
    {
        #region Private Members

        IFeedSourceProvider _feedSourceProvider;
        IFeedReaderService _feedReaderService;

        #endregion

        #region Constructor

        public NewsReader(IFeedSourceProvider feedSourceProvider, IFeedReaderService feedReaderService)
        {
            _feedSourceProvider = feedSourceProvider;
            _feedReaderService = feedReaderService;
        }

        #endregion

        #region INewsReader implementation

        public async Task<IList<Feed>> GetNewsFeedAsync()
        {
            var feedToReturn = new List<Feed>();
            var feedSources = _feedSourceProvider.GetSources();
            foreach (var feedSource in feedSources)
            {
                var feed = await _feedReaderService.GetFeedAsync(feedSource);
                feedToReturn.Add(feed);
            }
            return feedToReturn;
        }

        #endregion

    }
}
