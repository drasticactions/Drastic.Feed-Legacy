// <copyright file="IArticleParserService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using Drastic.Feed.Models;

namespace Drastic.Feed.Services
{
    /// <summary>
    /// Article Parser Service.
    /// Parse a full HTML page into a different layout.
    /// Can be used with <see cref="ITemplateService"/>.
    /// </summary>
    public interface IArticleParserService
    {
        /// <summary>
        /// Parse the feed item into a custom page or string.
        /// </summary>
        /// <param name="item"><see cref="FeedItem"/>.</param>
        /// <returns>String.</returns>
        Task<string> ParseFeedItem(FeedItem item);
    }
}