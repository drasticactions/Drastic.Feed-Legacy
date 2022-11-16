// <copyright file="AppDispatcher.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using Drastic.Feed.UI.Services;

namespace Drastic.Feed.UI.Mac
{
    /// <summary>
    /// App Dispatcher.
    /// </summary>
    public class AppDispatcher : NSObject, IAppDispatcher
    {
        /// <inheritdoc/>
        public bool Dispatch(Action action)
        {
            this.InvokeOnMainThread(action);
            return true;
        }
    }
}