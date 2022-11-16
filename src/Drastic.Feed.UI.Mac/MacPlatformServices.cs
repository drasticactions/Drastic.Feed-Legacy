// <copyright file="MacPlatformServices.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using Drastic.Feed.UI.Services;

namespace Drastic.Feed.UI.Mac
{
    public class MacPlatformServices : IPlatformService
    {
        /// <inheritdoc/>
        public Task OpenBrowserAsync(string url)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task ShareUrlAsync(string url)
        {
            throw new NotImplementedException();
        }
    }
}