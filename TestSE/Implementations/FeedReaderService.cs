using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using NewsReader.Services.Interfaces;

namespace NewsReader.Services.Implementations
{
    public class FeedReaderService : IFeedReaderService
    {
        public FeedReaderService()
        {
        }

        /// <summary>
        /// Returns the items from the give feed source(url).
        /// </summary>
        /// <param name="feedSource"></param>
        /// <returns></returns>
        public async Task<IList<FeedItem>> GetFeedItemsAsync(string feedSource)
        {
            if (string.IsNullOrEmpty(feedSource))
                return null;

            try
            {
                var feed = await FeedReader.ReadAsync(feedSource);

                if (feed == null)
                    return null;

                if (feed.Items == null)
                    return null;

                return feed.Items.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Feed> GetFeedAsync(string feedSource)
        {
            if (string.IsNullOrEmpty(feedSource))
                return null;
            try
            {
                return await FeedReader.ReadAsync(feedSource);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
