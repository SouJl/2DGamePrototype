using System;
using UnityEngine;

namespace PixelGame.Components
{

    internal class DeathZonesComponent : MonoBehaviour
    {
        [SerializeField] private LevelObjecTriggerComponent[] _deathZones;

        public event Action OnDeathZoneContact;  
        
        private void Awake()
        {
            foreach(var zone in _deathZones)
            {
                zone.TriggerEnter += CheckDeathZone;
            }
        }

        private void CheckDeathZone(Collider2D collider)
        {
            if(collider.gameObject.tag == "Player")
            {
                OnDeathZoneContact?.Invoke();
            }
        }
    }
}
