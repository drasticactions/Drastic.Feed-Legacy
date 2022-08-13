// <copyright file="FeedReaderTests.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using Drastic.Feed.Services;

namespace Drastic.Feed.Rss.FeedReader.Tests
{
    /// <summary>
    /// FeedReader Tests.
    /// </summary>
    [TestClass]
    public class FeedReaderTests
    {
        /// <summary>
        /// Generic Feed Service.
        /// </summary>
        private IFeedService feed;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedReaderTests"/> class.
        /// </summary>
        public FeedReaderTests()
        {
            this.feed = new FeedReaderService();
        }

        /// <summary>
        /// Get Feed.
        /// </summary>
        /// <param name="feed">Test feed URL.</param>
        /// <returns>Task.</returns>
        [DataRow("https://devblogs.microsoft.com/dotnet/feed/")]
        [DataTestMethod]
        public async Task GetFeed(string feed)
        {
            (var feedList, var feedItemsList) = await this.feed.ReadFeedAsync(feed);
            Assert.IsNotNull(feedList);
            Assert.IsNotNull(feedItemsList);
        }
    }
}