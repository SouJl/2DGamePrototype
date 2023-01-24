﻿using Pathfinding;
using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface ILogicAI
    {
        Path Path { get; }

        float NextWayPointDistance { get; }

        int CurrentWayPoint { get; }

        float UpdateFrameRate { get; }

        bool ReachedEndOfPath { get; set; }

        void OnPathComplete(Path p);

        Vector2 CalculatePath(Vector2 fromPosition);

    }
}
