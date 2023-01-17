using System;
using UnityEngine;

namespace PixelGame.Components
{
    [Serializable]
    public class SlopeDataComponent
    {      
        public float slopeCheckDistance = 0.5f;
        public float maxSlopeAngle  = 30f;
        public LayerMask layerMask;
    }
}
