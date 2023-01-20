using Pathfinding;
using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface ILogicAI
    {
        Path Path { get; }

        Seeker Seeker { get; }

        float NextWayPointDistance { get; }

        int CurrentWayPoint { get; }

        float UpdateFrameRate { get; }

        bool ReachedEndOfPath { get; set; }

        void OnPathComplete(Path path);

        Vector2 CalculatePath(Vector2 fromPosition);

    }
}
