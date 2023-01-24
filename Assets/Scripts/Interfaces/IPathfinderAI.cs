﻿using Pathfinding;
using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface IPathfinderAI
    {
        Path Path { get; }

        float NextWayPointDistance { get; }

        int CurrentWayPoint { get; }

        float UpdateFrameRate { get; }

        bool ReachedEndOfPath { get; set; }

        void OnPathComplete(Path path);

        Vector2 CalculatePath(Vector2 fromPosition);
    }
}
