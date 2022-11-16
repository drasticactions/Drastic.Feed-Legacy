// <copyright file="AppDispatcher.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using Drastic.Feed.UI.Services;
using Microsoft.UI.Dispatching;

namespace Drastic.Feed.UI.WinUI.Services
{
    /// <summary>
    /// App Dispatcher.
    /// </summary>
    public class AppDispatcher : IAppDispatcher
    {
        private readonly DispatcherQueue dispatcherQueue;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDispatcher"/> class.
        /// </summary>
        /// <param name="dispatcherQueue">Dispatcher Queue.</param>
        public AppDispatcher(DispatcherQueue dispatcherQueue)
        {
            this.dispatcherQueue = dispatcherQueue ?? throw new ArgumentNullException(nameof(dispatcherQueue));
        }

        /// <inheritdoc/>
        public bool Dispatch(Action action)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));
            return this.dispatcherQueue.TryEnqueue(() => action());
        }
    }
}
