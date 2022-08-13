// <copyright file="SmartReaderParserService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using Drastic.Feed.Models;
using Drastic.Feed.Services;

namespace Drastic.Feed.Parser.SmartReader
{
    /// <summary>
    /// Smart Reader Parser Service.
    /// </summary>
    public class SmartReaderParserService : IArticleParserService
    {
        /// <summary>
        /// Parse a feed item to an Article by rendering its contents.
        /// </summary>
        /// <param name="item"><see cref="FeedItem."/>.</param>
        /// <returns>Article.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <see cref="FeedItem.Link"/> is null or empty.</exception>
        public Task<global::SmartReader.Article> ParseFeedItemToArticle(FeedItem item)
        {
            if (item.Link is null || string.IsNullOrEmpty(item.Link))
            {
                throw new ArgumentNullException($"{item.Title} has no Link");
            }

            return global::SmartReader.Reader.ParseArticleAsync(item.Link);
        }

        /// <inheritdoc/>
        public async Task<string> ParseFeedItem(FeedItem item)
        {
            var article = await this.ParseFeedItemToArticle(item);
            return article?.Content ?? string.Empty;
        }
    }
}