using Pathfinding;

namespace PixelGame.Interfaces
{
    public interface ILogicAI
    {
        Path Path { get; }
        Seeker Seeker { get; }

        float NextWayPintDistance { get; }
        int CurrentWayPoint { get; }

        float UpdateFrameRate { get; }

        bool ReachedEndOfPath { get; set; }

        void OnPathComplete(Path path);

        void UpdatePath();

        void Update(float time);
    }
}
