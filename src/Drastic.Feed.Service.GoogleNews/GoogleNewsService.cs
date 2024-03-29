﻿// <copyright file="GoogleNewsService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Globalization;
using Drastic.Feed.Models;
using Drastic.Feed.Services;

namespace Drastic.Feed.Service.GoogleNews
{
    /// <summary>
    /// Google News Service.
    /// </summary>
    public class GoogleNewsService
    {
        private IFeedService feedService;
        private string mainFeedUri = "https://news.google.com/rss?gl={1}&hl={0}&ceid={1}:{0}";
        private string sectiondUri = "https://news.google.com/news/rss/headlines/section/topic/{0}?ned={2}&hl={1}";

        public GoogleNewsService(IFeedService service)
        {
            if (service is null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            this.feedService = service;
        }

        public async Task<(FeedListItem? FeedList, IList<FeedItem>? FeedItemList)> ReadMainPageAsync(CultureInfo? culture = default, CancellationToken? token = default)
        {
            var (cultureName, cultureLocale) = this.GetCultureNameAndLocal(culture);

            var mainFeedFormat = string.Format(CultureInfo.InvariantCulture, this.mainFeedUri, cultureName, cultureLocale);

            return await this.feedService.ReadFeedAsync(mainFeedFormat, token);
        }

        public async Task<(FeedListItem? FeedList, IList<FeedItem>? FeedItemList)> ReadSectionAsync(NewsSections section, CultureInfo? culture = default, CancellationToken? token = default)
        {
            if (section is NewsSections.Unknown)
            {
                throw new ArgumentException(nameof(section));
            }

            var (cultureName, cultureLocale) = this.GetCultureNameAndLocal(culture);

            var sectionFeedFormat = string.Format(CultureInfo.InvariantCulture, this.sectiondUri, section.ToString().ToUpperInvariant(), cultureName, cultureLocale);

            return await this.feedService.ReadFeedAsync(sectionFeedFormat, token);
        }

        private (string CultureName, string CultureLocal) GetCultureNameAndLocal(CultureInfo? culture = default)
        {
            culture = culture ?? CultureInfo.CurrentCulture;

            var cultureNameAndLocale = culture.ToString().Split('-');

            var cultureLocale = "US";
            var cultureName = "en";

            if (cultureNameAndLocale.Length == 2)
            {
                cultureName = cultureNameAndLocale[0];
                cultureLocale = cultureNameAndLocale[1];
            }

            return (cultureName, cultureLocale);
        }
    }
}