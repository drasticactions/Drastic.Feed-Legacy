// <copyright file="ITemplateService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using Drastic.Feed.Models;

namespace Drastic.Feed.Services
{
    /// <summary>
    /// Template Service.
    /// Used for templating feed items into views
    /// that can work better for a given device or application.
    /// </summary>
    public interface ITemplateService
    {
        /// <summary>
        /// Renders a given Feed Item into an HTML string.
        /// </summary>
        /// <param name="feedListItem"><see cref="FeedListItem"/>.</param>
        /// <param name="item"><see cref="FeedItem"/>.</param>
        /// <returns>Html String.</returns>
        public Task<string> RenderFeedItemAsync(FeedListItem feedListItem, FeedItem item);
    }
}