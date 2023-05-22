using PixelGame.Components;
using PixelGame.Game.Machines;
using System;
using UnityEngine;

namespace PixelGame.Tool
{
    internal class LevelObjectsGameSystem : IGameSystemComponent
    {
        private readonly ElevatorController _elevatorController;

        public event Action OnRestart;
        public event Action<Collider2D> OnGameEnd;

        public LevelObjectsGameSystem(
            ElevatorView elevatorView, 
            DeathZonesComponent deathZones, 
            LevelObjecTriggerComponent gameEnd) 
        {
            _elevatorController = new ElevatorController(elevatorView);

            deathZones.OnDeathZoneContact += () 
                => OnRestart?.Invoke();
            gameEnd.TriggerEnter += sender 
                => OnGameEnd?.Invoke(sender);
        }

        public IExecute GetExecutable() => 
            _elevatorController;
    }
}
