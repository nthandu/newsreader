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
            // Can be sourced from an http source in a real time app.
            return new List<string>()
            {
                "https://feeds.bbci.co.uk/news/uk/rss.xml",
                "https://feeds.bbci.co.uk/news/technology/rss.xml"
            };
        }
    }
}
