using System;
using CodeHollow.FeedReader;
using NewsReader.Services.Models;

namespace NewsReader.Services.Extensions
{
    public static class FeedItemExtensions
    {
        /// <summary>
        /// Returns NewsItem from FeedItem.
        /// </summary>
        /// <param name="feedItem"></param>
        /// <param name="category"></param>
        /// <returns><see cref="NewsItem"/></returns>
        public static NewsItem ToNewsItem(this FeedItem feedItem, string category)
        {
            return new NewsItem()
            {
                Category = category,
                Description = feedItem.Description,
                Link = feedItem.Link,
                ThumbnailUrl = null,
                Title = feedItem.Title,
                PublishedDate = feedItem.PublishingDate
            };
        } 
    }
}
