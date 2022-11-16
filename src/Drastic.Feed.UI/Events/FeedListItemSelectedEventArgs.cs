// <copyright file="FeedListItemSelectedEventArgs.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drastic.Feed.Models;

namespace Drastic.Feed.UI
{
    public class FeedListItemSelectedEventArgs : EventArgs
    {
        private readonly FeedListItem feedItem;

        public FeedListItemSelectedEventArgs(FeedListItem item)
        {
            this.feedItem = item;
        }

        public FeedListItem FeedListItem => this.feedItem;
    }
}
