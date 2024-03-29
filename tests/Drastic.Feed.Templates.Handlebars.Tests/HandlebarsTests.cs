﻿// <copyright file="HandlebarsTests.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using Drastic.Feed.Models;
using Drastic.Feed.Services;

namespace Drastic.Feed.Templates.Handlebars.Tests
{
    /// <summary>
    /// Handlebars Test.
    /// </summary>
    [TestClass]
    public class HandlebarsTests
    {
        private ITemplateService templates;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandlebarsTests"/> class.
        /// </summary>
        public HandlebarsTests()
        {
            this.templates = new HandlebarsTemplateService();
        }

        /// <summary>
        /// Render Template Html.
        /// </summary>
        /// <returns>Task.</returns>
        [TestMethod]
        public async Task RenderTemplate()
        {
            var feedListItem = new FeedListItem()
            {
                Name = "Testing",
                Link = "https://testing.com",
            };
            var feedItem = new FeedItem();
            feedItem.Title = "Test Item";
            feedItem.PublishingDate = DateTime.UtcNow;
            feedItem.Author = "Test Author";
            feedItem.Content = @"<b>Test</b>";
            feedItem.Description = "Test Description";
            feedItem.Link = "https://devblogs.microsoft.com/dotnet/dotnet-maui-preview-14/";
            var html = await this.templates.RenderFeedItemAsync(feedListItem, feedItem);
            Assert.IsNotNull(html);
            Assert.IsNotNull(feedItem.Html);
        }
    }
}