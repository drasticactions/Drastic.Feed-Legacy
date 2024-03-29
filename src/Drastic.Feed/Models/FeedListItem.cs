﻿// <copyright file="FeedListItem.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace Drastic.Feed.Models
{
    /// <summary>
    /// Feed List Item.
    /// </summary>
    public class FeedListItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedListItem"/> class.
        /// </summary>
        public FeedListItem()
        {
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the feed name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the feed description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the feed Language.
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// Gets or sets the last updated date.
        /// </summary>
        public DateTime? LastUpdatedDate { get; set; }

        /// <summary>
        /// Gets or sets the feed image uri.
        /// </summary>
        public Uri? ImageUri { get; set; }

        /// <summary>
        /// Gets or sets the Feed Uri.
        /// </summary>
        public Uri? Uri { get; set; }

        /// <summary>
        /// Gets or sets the feed image.
        /// </summary>
        public byte[]? Image { get; set; }

        /// <summary>
        /// Gets or sets the Feed Link.
        /// </summary>
        public string? Link { get; set; }
    }
}