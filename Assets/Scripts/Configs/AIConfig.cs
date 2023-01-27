using System;
using UnityEngine;

namespace PixelGame.Configs
{
    [Serializable]
    public struct AIConfig
    {
        public float UpdateFrameRate;
        public float MinSqrDistance;
        public Transform[] waypoints;
    }
}
