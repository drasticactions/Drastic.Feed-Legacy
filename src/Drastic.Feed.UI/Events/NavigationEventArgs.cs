// <copyright file="NavigationEventArgs.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drastic.Feed.UI
{
    public class NavigationEventArgs : EventArgs
    {
        public NavigationEventArgs(Type type, object? arguments)
        {
            this.Type = type;
            this.Arguments = arguments;
        }

        public Type Type { get; }

        public object? Arguments { get; }
    }
}
