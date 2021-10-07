using Game.Core.Enums;
using Game.Core.Scenarios;

namespace Game.Core.Players.Interfaces
{
    public interface IPlayer
    {
        Player Player { get; }

        PlayResponse Play(PlayRequest playRequest);

        void SetPlayer(Player player);
    }
}
