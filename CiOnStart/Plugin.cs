// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CiOnStart
{
    using System;
    using Exiled.API.Enums;
    using Exiled.API.Features;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc />
        public override string Author => "Build";

        /// <inheritdoc />
        public override PluginPriority Priority => PluginPriority.Higher;

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 1, 0);

        /// <inheritdoc />
        public override Version Version { get; } = new Version(1, 0, 1);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            Exiled.Events.Handlers.Player.ChangingRole += eventHandlers.OnChangingRole;
            Exiled.Events.Handlers.Server.WaitingForPlayers += eventHandlers.OnWaitingForPlayers;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.ChangingRole -= eventHandlers.OnChangingRole;
            Exiled.Events.Handlers.Server.WaitingForPlayers -= eventHandlers.OnWaitingForPlayers;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}