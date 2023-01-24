using UnityEngine;

namespace PixelGame.Interfaces
{
    public interface ILogicAI<T>
    {
        T Path { get; }

        float NextWayPointDistance { get; }

        int CurrentWayPoint { get; }

        float UpdateFrameRate { get; }

        bool ReachedEndOfPath { get; set; }

        void OnPathComplete(T path);

        Vector2 CalculatePath(Vector2 fromPosition);

    }
}
