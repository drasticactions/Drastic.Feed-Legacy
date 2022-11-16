// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using CommunityToolkit.Mvvm.DependencyInjection;
using Drastic.Feed.UI.ViewModels;
using Drastic.Feed.UI.Tools;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Drastic.Feed.Models;
using Drastic.Feed.UI.Services;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Drastic.Feed.UI.WinUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.FeedListVM = Ioc.Default.ResolveWith<FeedListViewModel>();
            this.FeedItemListVM = Ioc.Default.ResolveWith<FeedItemListViewModel>();
            this.FeedArticleVM = Ioc.Default.ResolveWith<FeedArticleViewModel>(this.LocalWebview);
            this.FeedListVM.FeedListItems.CollectionChanged += this.FeedListItems_CollectionChanged;
            this.DispatcherQueue.TryEnqueue(async () => await this.FeedListVM.OnLoad());
            this.NavView.SelectionChanged += this.NavView_SelectionChanged;
            this.ArticleList.SelectionChanged += this.ArticleList_SelectionChanged;
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

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is not NavigationViewItem item)
            {
                return;
            }

            var feedItem = this.FeedListVM.FeedListItems.FirstOrDefault(n => item.Tag.ToString() == n.Id.ToString());
            if (feedItem is null)
            {
                return;
            }

            this.DispatcherQueue.TryEnqueue(async () => await this.FeedItemListVM.GetCachedFeedItemsCommand.ExecuteAsync(feedItem));
        }

        private void FeedListItems_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    if (e.NewItems is not null)
                    {
                        foreach (var item in e.NewItems)
                        {
                            var navItem = this.GenerateNavItem(item as FeedListItem);
                            this.NavView.MenuItems.Add(navItem);
                            if (this.NavView.SelectedItem is null)
                            {
                                this.NavView.SelectedItem = navItem;
                            }
                        }
                    }

                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    this.NavView.MenuItems.Clear();
                    break;
                default:
                    break;
            }
        }

        private NavigationViewItem GenerateNavItem(FeedListItem? item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (item.ImageCache is not byte[] cache)
            {
                return new NavigationViewItem() { Tag = item.Id, Content = item.Name };
            }

            var icon = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage();
            icon.SetSource(cache.ToRandomAccessStream());

            return new NavigationViewItem() { Tag = item.Id, Content = item.Name, Icon = new ImageIcon() { Source = icon } };
        }

        private async void NewFeedButton_Click(object sender, RoutedEventArgs e)
        {
            PromptDialog prompt = new PromptDialog()
            {
                XamlRoot = this.NavView.XamlRoot,
            };

            var result = await prompt.ShowAsync();
            if (result is ContentDialogResult.Primary)
            {
                var feedUri = prompt.TextBoxInput.Text;
                await this.FeedListVM.AddOrUpdateNewFeedListItemAsync(feedUri);
            }

            prompt.TextBoxInput.Text = string.Empty;
        }

        private async void ArticleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.AddedItems.FirstOrDefault() as FeedItem;
            if (item is null)
            {
                return;
            }

            await this.FeedArticleVM.UpdateFeedItem(this.FeedItemListVM.FeedListItem, item);
        }

        private void RefreshFeedButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
