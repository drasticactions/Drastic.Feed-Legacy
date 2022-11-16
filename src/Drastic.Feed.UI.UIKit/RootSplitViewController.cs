using System;
using Drastic.Feed.UI.ViewModels;
using Drastic.Feed.UI.Tools;

namespace Drastic.Feed.UI.UIKit
{
    public class RootSplitViewController : UISplitViewController
    {
        private ArticleViewController articleViewController;
        private TimelineViewController timelineViewController;
        private FeedViewController feedViewController;
        private IServiceProvider services;

        public RootSplitViewController(IServiceProvider services)
            : base(UISplitViewControllerStyle.TripleColumn)
        {
            this.services = services;
            this.FeedListVM = services.ResolveWith<FeedListViewModel>();
            this.FeedItemListVM = services.ResolveWith<FeedItemListViewModel>();
            this.PreferredDisplayMode = UISplitViewControllerDisplayMode.TwoBesideSecondary;
            this.articleViewController = new ArticleViewController();
            this.timelineViewController = new TimelineViewController(this.FeedItemListVM);
            this.feedViewController = new FeedViewController(this.FeedListVM);
            this.articleViewController.FeedArticleVM = this.FeedArticleVM = services.ResolveWith<FeedArticleViewModel>(this.articleViewController.FeedWebview);

            this.SetViewController(this.articleViewController, UISplitViewControllerColumn.Secondary);
            this.SetViewController(this.timelineViewController, UISplitViewControllerColumn.Supplementary);
            this.SetViewController(this.feedViewController, UISplitViewControllerColumn.Primary);

            this.PrimaryBackgroundStyle = UISplitViewControllerBackgroundStyle.Sidebar;
            this.FeedListVM.OnFeedListItemSelected += this.FeedListVM_OnFeedListItemSelected;
            this.FeedItemListVM.OnFeedItemSelected += FeedItemListVM_OnFeedItemSelected;
        }

        private async void FeedItemListVM_OnFeedItemSelected1(object? sender, FeedItemSelectedEventArgs e)
        {
            if (e.FeedListItem is not null)
            {
                await this.FeedArticleVM.UpdateFeedItem(e.FeedListItem, e.FeedItem);
            }
        }

        private async void FeedListVM_OnFeedListItemSelected(object? sender, FeedListItemSelectedEventArgs e)
        {
            await this.FeedItemListVM.GetCachedFeedItemsCommand.ExecuteAsync(e.FeedListItem);
        }

        private async void FeedItemListVM_OnFeedItemSelected(object? sender, FeedItemSelectedEventArgs e)
        {
            await this.articleViewController.FeedArticleVM?.UpdateFeedItem(e.FeedListItem, e.FeedItem);
        }

        /// <summary>
        /// Gets the Feed List VM.
        /// </summary>
        public FeedListViewModel FeedListVM { get; private set; }

        /// <summary>
        /// Gets the Feed Item List VM.
        /// </summary>
        public FeedItemListViewModel FeedItemListVM { get; private set; }

        /// <summary>
        /// Gets the Feed Article FM.
        /// </summary>
        public FeedArticleViewModel FeedArticleVM { get; private set; }
    }
}