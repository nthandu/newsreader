using System;
using System.Collections.Generic;

namespace NewsReader.Services.Interfaces
{
    public interface IFeedSourceProvider
    {
        /// <summary>
        /// Returns list of sources for the news feed.
        /// </summary>
        /// <returns></returns>
        IList<string> GetSources();
    }
}
