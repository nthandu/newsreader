using System;
using System.Collections.Generic;
using NewsReader.Services.Interfaces;

namespace NewsReader.Services.Implementations
{
    public class FeedSourceProvider : IFeedSourceProvider
    {
        public FeedSourceProvider()
        {
        }

        public IList<string> GetSources()
        {
            return new List<string>()
            {
                "https://feeds.bbci.co.uk/news/uk/rss.xml",
                "https://feeds.bbci.co.uk/news/technology/rss.xml"
            };
        }
    }
}
