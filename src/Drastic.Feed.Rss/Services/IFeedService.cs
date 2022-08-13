// <copyright file="IFeedService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using Drastic.Feed.Models;

namespace Drastic.Feed.Services
{
    /// <summary>
    /// Feed Service.
    /// The base of handling RSS feeds and other lists.
    /// </summary>
    public interface IFeedService
    {
        /// <summary>
        /// Read a given feed URL.
        /// </summary>
        /// <param name="feedUri">The Feed URI.</param>
        /// <param name="token">Optional Cancelation Token.</param>
        /// <returns><see cref="FeedListItem"/> and <see cref="FeedItem"/>.</returns>
        Task<(FeedListItem? FeedList, IList<FeedItem>? FeedItemList)> ReadFeedAsync(string feedUri, CancellationToken? token = default);
    }
}