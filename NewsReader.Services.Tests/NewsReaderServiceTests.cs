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
            feedSourceProvider.Setup(s => s.GetSources()).Returns(new List<string>() { "some link", "link two" });
            var readerService = new Mock<Interfaces.IFeedReaderService>();
            readerService.Setup(s => s.GetFeedAsync(It.IsAny<string>())).ReturnsAsync(new Feed()
            {
                Items = GetMockFeedItems()
            });
            var newsReaderService = new NewsReaderService(feedSourceProvider.Object, readerService.Object);
            var feeds = await newsReaderService.GetNewsFeedAsync();
            Assert.NotNull(feeds);
            Assert.AreEqual(4, feeds.Count);
        }

        [Test()]
        public async Task GetNewsFeedReturnsFeedOnlyWhenFeedAvailableFromSource()
        {
            var feedSourceProvider = new Mock<Interfaces.IFeedSourceProvider>();
            feedSourceProvider.Setup(s => s.GetSources()).Returns(new List<string>() { null, "link two" });
            var readerService = new Mock<Interfaces.IFeedReaderService>();
            readerService.Setup(s => s.GetFeedAsync(null)).ReturnsAsync(default(Feed));
            readerService.Setup(s => s.GetFeedAsync("link two")).ReturnsAsync(new Feed()
            {
                Items = GetMockFeedItems()
            });
            var newsReaderService = new NewsReaderService(feedSourceProvider.Object, readerService.Object);
            var feeds = await newsReaderService.GetNewsFeedAsync();
            Assert.NotNull(feeds);
            Assert.AreEqual(2, feeds.Count);
        }

        [Test()]
        public async Task GetNewsFeedAlwaysReturnsLatestItemsAtTop()
        {
            var feedSourceProvider = new Mock<Interfaces.IFeedSourceProvider>();
            feedSourceProvider.Setup(s => s.GetSources()).Returns(new List<string>() { "some link" });
            var readerService = new Mock<Interfaces.IFeedReaderService>();
            readerService.Setup(s => s.GetFeedAsync(It.IsAny<string>())).ReturnsAsync(new Feed()
            {
                Items = GetMockFeedItems()
            });
            var newsReaderService = new NewsReaderService(feedSourceProvider.Object, readerService.Object);
            var feeds = await newsReaderService.GetNewsFeedAsync();
            Assert.NotNull(feeds);
            Assert.AreEqual(2, feeds.Count);
            Assert.AreEqual("T2", feeds[0].Title);
        }

        private List<FeedItem> GetMockFeedItems()
        {
            return new List<FeedItem>() {
                    new FeedItem() { Title= "T1", PublishingDate = DateTime.Now.AddHours(-4) },
                    new FeedItem() { Title= "T2", PublishingDate = DateTime.Now.AddHours(-1) }
            };
        }
    }
}
