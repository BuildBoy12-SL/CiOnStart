// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CiOnStart
{
    using System.Collections.Generic;
    using Exiled.Events.EventArgs;
    using Respawning;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;
        private readonly Queue<RoleType> spawnQueue = new Queue<RoleType>();
        private bool isChi;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnChangingRole(ChangingRoleEventArgs)"/>
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (isChi && ev.NewRole == RoleType.FacilityGuard)
                ev.NewRole = spawnQueue.Dequeue();
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnWaitingForPlayers()"/>
        public void OnWaitingForPlayers()
        {
            isChi = Exiled.Loader.Loader.Random.Next(100) < plugin.Config.CiChance;
            if (isChi)
            {
                SpawnableTeamHandlerBase chaosSpawnHandler = RespawnWaveGenerator.SpawnableTeams[SpawnableTeamType.ChaosInsurgency];
                chaosSpawnHandler.GenerateQueue(spawnQueue, chaosSpawnHandler.MaxWaveSize);
            }
        }
    }
}