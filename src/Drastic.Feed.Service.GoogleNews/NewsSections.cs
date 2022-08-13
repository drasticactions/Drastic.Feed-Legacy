// <copyright file="NewsSections.cs" company="Drastic Actions">
// Copyright (c) Drastic Actions. All rights reserved.
// </copyright>

namespace Drastic.Feed.Service.GoogleNews
{
    public enum NewsSections
    {
        /// <summary>
        /// Unknown.
        /// Will throw as an error.
        /// </summary>
        Unknown,

        /// <summary>
        /// Business.
        /// </summary>
        Business,

        /// <summary>
        /// Health.
        /// </summary>
        Health,

        /// <summary>
        /// Nation.
        /// </summary>
        Nation,

        /// <summary>
        /// Science.
        /// </summary>
        Science,

        /// <summary>
        /// Sports.
        /// </summary>
        Sports,

        /// <summary>
        /// Technology.
        /// </summary>
        Technology,

        /// <summary>
        /// World.
        /// </summary>
        World,
    }
}