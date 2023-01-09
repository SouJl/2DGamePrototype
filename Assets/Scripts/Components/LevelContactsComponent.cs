using PixelGame.View;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Components
{
    public class LevelContactsComponent : MonoBehaviour
    {
        [SerializeField] private Vector3 _startPostion;
        [SerializeField] private LevelObjectView _levelEndZone;
        [SerializeField] private List<Transform> _coinsPosition;
        [SerializeField] private List<LevelObjectView> _deathZones;

        public Vector3 StartPostion { get => _startPostion; }
        public LevelObjectView LevelEndZone { get => _levelEndZone; }
        public List<LevelObjectView> DeathZones { get => _deathZones; }
        public List<Transform> CoinsPosition { get => _coinsPosition; }
    }
}
