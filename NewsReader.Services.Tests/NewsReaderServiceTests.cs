using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeHollow.FeedReader;
using Moq;
using NewsReader.Services.Implementations;
using NUnit.Framework;

namespace NewsReader.Services.Tests
{
    [TestFixture()]
    public class NewsReaderServiceTests
    {
        public NewsReaderServiceTests()
        {
        }

        [Test()]
        public async Task GetNewsFeedReturnsFeedWhenValidSourceProvided()
        {
            var feedSourceProvider = new Mock<Interfaces.IFeedSourceProvider>();
            feedSourceProvider.Setup(s => s.GetSources()).Returns(new List<string>() { "some link","link two"});
            var readerService = new Mock<Interfaces.IFeedReaderService>();
            readerService.Setup(s => s.GetFeedAsync(It.IsAny<string>())).ReturnsAsync(new Feed());
            var newsReaderService = new NewsReaderService(feedSourceProvider.Object, readerService.Object);
            var feeds = await newsReaderService.GetNewsFeedAsync();
            Assert.NotNull(feeds);
            Assert.AreEqual(2, feeds.Count);
        }

        [Test()]
        public async Task GetNewsFeedReturnsFeedOnlyWhenFeedAvailableFromSource()
        {
            var feedSourceProvider = new Mock<Interfaces.IFeedSourceProvider>();
            feedSourceProvider.Setup(s => s.GetSources()).Returns(new List<string>() { null, "link two" });
            var readerService = new Mock<Interfaces.IFeedReaderService>();
            readerService.Setup(s => s.GetFeedAsync(null)).ReturnsAsync(default(Feed));
            readerService.Setup(s => s.GetFeedAsync("link two")).ReturnsAsync(new Feed());
            var newsReaderService = new NewsReaderService(feedSourceProvider.Object, readerService.Object);
            var feeds = await newsReaderService.GetNewsFeedAsync();
            Assert.NotNull(feeds);
            Assert.AreEqual(1, feeds.Count);
        }


    }
}
