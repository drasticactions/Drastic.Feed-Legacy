// <copyright file="FeedWebview.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using Drastic.Feed.UI.Services;
using ObjCRuntime;
using WebKit;

namespace Drastic.Feed.UI.Mac
{
    public class FeedWebview : WebKit.WKWebView, IFeedWebview
    {
        public FeedWebview(NSCoder coder)
            : base(coder)
        {
        }

        public FeedWebview(CGRect frame, WKWebViewConfiguration configuration)
            : base(frame, configuration)
        {
        }

        protected FeedWebview(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal FeedWebview(NativeHandle handle)
            : base(handle)
        {
        }

        /// <inheritdoc/>
        public void SetSource(string html)
        {
            this.LoadHtmlString(new NSString(html), null);
        }
    }
}