using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeHollow.FeedReader;

namespace NewsReader.Services.Interfaces
{
    public interface IFeedReaderService
    {
        /// <summary>
        /// Returns the feed from the given source. 
        /// </summary>
        /// <param name="webUrl"></param>
        /// <returns></returns>
        Task<IList<FeedItem>> GetFeedItemsAsync(string feedSource);

        /// <summary>
        /// Returns the feed from the given source. 
        /// </summary>
        /// <param name="webUrl"></param>
        /// <returns></returns>
        Task<Feed> GetFeedAsync(string feedSource);
    }
}
