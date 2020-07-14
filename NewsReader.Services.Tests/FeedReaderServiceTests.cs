using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NewsReader.Services.Tests
{
    [TestFixture]
    public class FeedReaderServiceTests
    {
        public FeedReaderServiceTests()
        {
        }

        [Test]
        public async Task GetFeedAsyncReturnsNullWhenSourceIsNull()
        {
            var feedReaderService = new Implementations.FeedReaderService();
            var feed = await feedReaderService.GetFeedAsync(null);
            Assert.Null(feed);
        }

        [Test]
        public async Task GetFeedAsyncReturnsNullWhenSourceIsInvalid()
        {
            var feedReaderService = new Implementations.FeedReaderService();
            var feed = await feedReaderService.GetFeedAsync("some invalid link");
            Assert.Null(feed);
        }

        [Test]
        public async Task GetFeedAsyncReturnsFeedWhenSourceIsValid()
        {
            var feedReaderService = new Implementations.FeedReaderService();
            var feed = await feedReaderService.GetFeedAsync(TestData.BbcUKNewsFeed);
            Assert.NotNull(feed);
            Assert.NotNull(feed.Title);
            Assert.AreEqual(TestData.BbcNewsFeedTitle, feed.Title);
        }


    }
}
