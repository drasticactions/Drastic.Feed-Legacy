// <copyright file="IAppDispatcher.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drastic.Feed.UI.Services
{
    public interface IAppDispatcher
    {
        bool Dispatch(Action action);
    }
}
