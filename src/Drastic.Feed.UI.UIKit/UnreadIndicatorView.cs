// <copyright file="UnreadIndicatorView.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using ObjCRuntime;

namespace Drastic.Feed.UI.UIKit
{
	public class UnreadIndicatorView : UIView
    {
        public UnreadIndicatorView()
        {
        }

        public UnreadIndicatorView(NSCoder coder) : base(coder)
        {
        }

        public UnreadIndicatorView(CGRect frame) : base(frame)
        {
        }

        protected UnreadIndicatorView(NSObjectFlag t) : base(t)
        {
        }

        protected internal UnreadIndicatorView(NativeHandle handle) : base(handle)
        {
        }
    }
}