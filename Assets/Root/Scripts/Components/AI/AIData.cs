using System;

namespace PixelGame.Components.AI
{
    internal interface IAIData
    {
        float UpdateFrameRate { get; }
        float MinSqrDistance { get; }

    }


    [Serializable]
    internal class AIData : IAIData
    {
        public float UpdateFrameRate = 0.5f;

        public float MinSqrDistance = 0.25f;

        float IAIData.UpdateFrameRate => UpdateFrameRate;

        float IAIData.MinSqrDistance => MinSqrDistance;
    }
}
