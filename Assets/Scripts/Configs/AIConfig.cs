using UnityEngine;

namespace PixelGame.Configs
{
    [CreateAssetMenu(fileName = "AIConfig", menuName = "Configs/AI")]
    public class AIConfig:ScriptableObject
    {
        public float UpdateFrameRate;
        public float NextWayPointDistance;
        public Transform[] waypoints;
    }
}
