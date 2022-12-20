// <copyright file="FeedReaderService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using AngleSharp.Html.Parser;
using Drastic.Feed.Models;
using Drastic.Feed.Services;

namespace Drastic.Feed.Rss.FeedReader
{
    /// <summary>
    /// Feed Reader Service.
    /// </summary>
    public class FeedReaderService : IFeedService
    {
        private HttpClient client;
        private HtmlParser parser;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedReaderService"/> class.
        /// </summary>
        /// <param name="client">Optional HttpClient for reading the RSS and image data.</param>
        /// <param name="parser">Optional Parser for feed content.</param>
        public FeedReaderService(HttpClient? client = default, HtmlParser? parser = default)
        {
            this.client = client ?? new HttpClient();
            this.parser = parser ?? new HtmlParser();
        }

        /// <inheritdoc/>
        public async Task<(FeedListItem? FeedList, IList<FeedItem>? FeedItemList)> ReadFeedAsync(string feedUri, CancellationToken? token = default)
        {
            var cancelationToken = token ?? CancellationToken.None;

            var result = await this.client.GetStringAsync(feedUri);
            cancelationToken.ThrowIfCancellationRequested();

            var feed = CodeHollow.FeedReader.FeedReader.ReadFromString(result);
            cancelationToken.ThrowIfCancellationRequested();

            if (feed is not null)
            {
                var item = feed.ToFeedListItem(feedUri);

                if (item.Image is null && item.ImageUri is not null)
                {
                    item.Image = await this.client.GetByteArrayAsync(item.ImageUri);
                    cancelationToken.ThrowIfCancellationRequested();
                }

                var feedItemList = new List<FeedItem>();

                foreach (var feedItem in feed.Items)
                {
                    using var document = await this.parser.ParseDocumentAsync(feedItem.Content);
                    var image = document.QuerySelector("img");
                    var imageUrl = string.Empty;
                    if (image is not null)
                    {
                        imageUrl = image.GetAttribute("src");
                    }

                    feedItemList.Add(feedItem.ToFeedItem(item, imageUrl));
                }

                return (item, feedItemList);
            }

            return (null, null);
        }
    }
}