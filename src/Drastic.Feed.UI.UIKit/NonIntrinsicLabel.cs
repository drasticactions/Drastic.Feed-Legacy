// <copyright file="NonIntrinsicLabel.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;

namespace Drastic.Feed.UI.UIKit
{
    public class NonIntrinsicLabel : UILabel
    {
        /// <inheritdoc/>
        public override CGSize IntrinsicContentSize => new CGSize(UIView.NoIntrinsicMetric, UIView.NoIntrinsicMetric);
    }
}