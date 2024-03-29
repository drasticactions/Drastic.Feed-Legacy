﻿// <copyright file="GoogleNewsTests.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using Drastic.Feed.Rss.FeedReader;
using Drastic.Feed.Services;

namespace Drastic.Feed.Service.GoogleNews.Tests
{
    /// <summary>
    /// Google News Tests.
    /// </summary>
    [TestClass]
    public class GoogleNewsTests
    {
        private IFeedService feed;
        private GoogleNewsService googleNews;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleNewsTests"/> class.
        /// </summary>
        public GoogleNewsTests()
        {
            this.feed = new FeedReaderService();
            this.googleNews = new GoogleNewsService(this.feed);
        }

        /// <summary>
        /// Get Main Feed.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task GetMainFeed()
        {
            (var feedList, var feedItemsList) = await this.googleNews.ReadMainPageAsync();
            Assert.IsNotNull(feedList);
            Assert.IsNotNull(feedItemsList);
        }

        /// <summary>
        /// Get Section Feed.
        /// </summary>
        /// <param name="section">Section.</param>
        /// <returns>Task.</returns>
        [DataRow(NewsSections.Business)]
        [DataRow(NewsSections.Health)]
        [DataRow(NewsSections.Nation)]
        [DataRow(NewsSections.Science)]
        [DataRow(NewsSections.Sports)]
        [DataRow(NewsSections.Technology)]
        [DataRow(NewsSections.World)]
        [DataTestMethod]
        public async Task GetSectionFeed(NewsSections section)
        {
            (var feedList, var feedItemsList) = await this.googleNews.ReadSectionAsync(section);
            Assert.IsNotNull(feedList);
            Assert.IsNotNull(feedItemsList);
        }
    }
}