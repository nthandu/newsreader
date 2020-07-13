using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using NewsReader.Services.Models;

namespace NewsReader.Services.Interfaces
{
    public interface INewsReaderService
    {
        /// <summary>
        /// Returns the news feed from available sources.
        /// </summary>
        /// <returns></returns>
        Task<IList<Feed>> GetNewsFeedAsync();
    }
}
