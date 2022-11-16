// <copyright file="FeedBaseViewModel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using Drastic.Feed.Models;

namespace Drastic.Feed.UI.ViewModels
{
    /// <summary>
    /// Feed Base View Model.
    /// </summary>
    public class FeedBaseViewModel : BaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedBaseViewModel"/> class.
        /// </summary>
        /// <param name="services"><see cref="IServiceProvider"/>/.</param>
        public FeedBaseViewModel(IServiceProvider services)
            : base(services)
        {
            this.AddNewFeedListItemCommand = new AsyncCommand<string>(
            async (item) => await this.AddOrUpdateNewFeedListItemAsync(item),
            (item) => string.IsNullOrEmpty(item) is false,
            this.ErrorHandler);
        }

        /// <summary>
        /// Gets the UpdateFeedListItem.
        /// </summary>
        public AsyncCommand<string> AddNewFeedListItemCommand { get; private set; }

        /// <summary>
        /// Adds New Feed List.
        /// </summary>
        /// <param name="feedUri">The Feed Uri.</param>
        /// <returns>Task.</returns>
        public async Task<FeedListItem?> AddOrUpdateNewFeedListItemAsync(string feedUri)
        {
            try
            {
                (var feed, var feedListItems) = await this.Feed.ReadFeedAsync(feedUri);
                var item = this.Context.GetFeedListItem(new Uri(feedUri));
                if (item is null)
                {
                    item = feed;
                }

                if (item is null || feedListItems is null)
                {
                    // TODO: Handle error. It shouldn't be null.
                    return null;
                }

                var result = this.Context.AddOrUpdateFeedListItem(item);

                foreach (var feedItem in feedListItems)
                {
                    feedItem.FeedListItemId = item.Id;
                    this.Context.AddOrUpdateFeedItem(feedItem);
                    this.SendFeedUpdateRequest(item, feedItem);
                }

                this.SendFeedListUpdateRequest(item);

                return item;
            }
            catch (Exception ex)
            {
                this.ErrorHandler.HandleError(ex);
            }

            return null;
        }
    }
}