// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CiOnStart
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;
    using UnityEngine;

    /// <inheritdoc />
    public class Config : IConfig
    {
        private int ciChance = 10;

        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the percentage chance that guards will spawn as chaos insurgents in a round.
        /// </summary>
        [Description("The percentage chance that guards will spawn as chaos insurgents in a round.")]
        public int CiChance
        {
            get => ciChance;
            set => ciChance = Mathf.Clamp(value, 0, 100);
        }
    }
}