﻿// <copyright file="FeedListItemExtensions.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using CodeHollow.FeedReader;
using Drastic.Feed.Models;

namespace Drastic.Feed.Rss.FeedReader
{
    /// <summary>
    /// Feed List Item Extensions.
    /// </summary>
    public static class FeedListItemExtensions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedListItem"/> class.
        /// </summary>
        /// <param name="feed"><see cref="Feed"/>.</param>
        /// <param name="feedUri">Original Feed Uri.</param>
        /// <returns><see cref="Core.FeedListItem"/>.</returns>
        public static FeedListItem ToFeedListItem(this CodeHollow.FeedReader.Feed feed, string feedUri)
        {
            return new FeedListItem()
            {
                Name = feed.Title,
                Uri = new Uri(feedUri),
                Link = feed.Link,
                ImageUri = string.IsNullOrEmpty(feed.ImageUrl) ? null : new Uri(feed.ImageUrl),
                Description = feed.Description,
                Language = feed.Language,
                LastUpdatedDate = feed.LastUpdatedDate,
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedItem"/> class.
        /// </summary>
        /// <param name="item"><see cref="CodeHollow.FeedReader.FeedItem"/>.</param>
        /// <param name="feedListItem"><see cref="FeedListItem"/>.</param>
        /// <param name="imageUrl">Image Url.</param>
        /// <returns><see cref="Core.FeedItem"/>.</returns>
        public static Drastic.Feed.Models.FeedItem ToFeedItem(this CodeHollow.FeedReader.FeedItem item, FeedListItem feedListItem, string? imageUrl = "")
        {
            return new Drastic.Feed.Models.FeedItem()
            {
                RssId = item.Id,
                FeedListItemId = feedListItem.Id,
                Title = item.Title,
                Link = item.Link,
                Description = item.Description,
                PublishingDate = item.PublishingDate,
                Author = item.Author,
                Content = item.Content,
                ImageUrl = imageUrl,
            };
        }
    }
}