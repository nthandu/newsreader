using System;
namespace NewsReader.Services.Models
{
    /// <summary>
    /// Represents a news item.
    /// </summary>
    public class NewsItem
    {
        public NewsItem()
        {
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public string ThumbnailUrl { get; set; }

        public string Category { get; set; }

        public DateTime? PublishedDate { get; set; }
    }
}
