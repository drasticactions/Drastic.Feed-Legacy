// <copyright file="FeedWebview.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using Drastic.Feed.UI.Services;
using Microsoft.UI.Xaml.Controls;

namespace Drastic.Feed.UI.WinUI
{
    /// <summary>
    /// Rss Webview Reader.
    /// </summary>
    public class FeedWebview : WebView2, IFeedWebview
    {
        /// <inheritdoc/>
        public void SetSource(string html)
        {
            this.DispatcherQueue.TryEnqueue(async () =>
            {
                await this.EnsureCoreWebView2Async();
                this.NavigateToString(html);
            });
        }
    }
}
