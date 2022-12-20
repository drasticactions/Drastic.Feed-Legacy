// <copyright file="HandlebarsTemplateService.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Reflection;
using Drastic.Feed.Models;
using Drastic.Feed.Services;
using HandlebarsDotNet;

namespace Drastic.Feed.Templates.Handlebars
{
    /// <summary>
    /// Handlebars Template Service.
    /// </summary>
    public class HandlebarsTemplateService : ITemplateService
    {
        private HandlebarsTemplate<object, object> feedItemTemplate;
        private IArticleParserService? articleParser;
        private byte[] placeholderImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandlebarsTemplateService"/> class.
        /// This uses the default template HTML.
        /// </summary>
        /// <param name="articleParser">Optional Article Parser.</param>
        /// <param name="placeholderImage">Optional placeholder image. Used if the image from <see cref="FeedListItem.Image"/> is empty.</param>
        public HandlebarsTemplateService(IArticleParserService? articleParser = default, byte[]? placeholderImage = default)
        {
            this.placeholderImage = placeholderImage ?? new byte[0];
            this.articleParser = articleParser;
            this.feedItemTemplate = HandlebarsDotNet.Handlebars.Compile(HandlebarsTemplateService.GetResourceFileContentAsString("Templates.feeditem.html.hbs"));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HandlebarsTemplateService"/> class.
        /// </summary>
        /// <param name="templateHtml">Handlebars Template HTML.</param>
        /// <param name="articleParser">Optional Article Parser.</param>
        /// <param name="placeholderImage">Optional placeholder image. Used if the image from <see cref="FeedListItem.Image"/> is empty.</param>
        public HandlebarsTemplateService(string templateHtml, IArticleParserService? articleParser = default, byte[]? placeholderImage = default)
        {
            this.placeholderImage = placeholderImage ?? new byte[0];
            this.articleParser = articleParser;
            this.feedItemTemplate = HandlebarsDotNet.Handlebars.Compile(templateHtml);
        }

        /// <inheritdoc/>
        public async Task<string> RenderFeedItemAsync(FeedListItem feedListItem, FeedItem item)
        {
            if (item.Link is null)
            {
                throw new ArgumentNullException(nameof(item.Link));
            }

            if (this.articleParser is not null)
            {
                item.Html = await this.articleParser.ParseFeedItem(item);
            }

            return item.Html = this.feedItemTemplate.Invoke(new { FeedListItem = feedListItem, FeedItem = item, Image = Convert.ToBase64String(feedListItem.Image ?? this.placeholderImage) });
        }

        private static string GetResourceFileContentAsString(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            if (assembly is null)
            {
                return string.Empty;
            }

            var resourceName = "Drastic.Feed.Templates.Handlebars." + fileName;

            string? resource = null;
            using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream is null)
                {
                    return string.Empty;
                }

                using StreamReader reader = new StreamReader(stream);
                resource = reader.ReadToEnd();
            }

            return resource ?? string.Empty;
        }
    }
}