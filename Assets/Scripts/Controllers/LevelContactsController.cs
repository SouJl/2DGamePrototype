using PixelGame.View;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Controllers
{
    public class LevelContactsController : IDisposable
    {
        private LevelObjectView _controlUnit;
        private LevelObjectView _levelEndZone;
        private List<LevelObjectView> _deathZones;
        private Vector3 _startPostion;

        public LevelContactsController(LevelObjectView controlUnit, LevelObjectView levelEnd, List<LevelObjectView> deathZones, Vector3 startPostion)
        {
            _controlUnit = controlUnit;
            _levelEndZone = levelEnd;
            _deathZones = deathZones;
            _startPostion = startPostion;

            _controlUnit.OnLevelObjectContact += OnLevelObjectContact;
        }

        private void OnLevelObjectContact(LevelObjectView levelObject)
        {
            if (_deathZones.Contains(levelObject))
            {
                _controlUnit.Transform.position = _startPostion;
            }

            if (_levelEndZone == levelObject)
            {
                Debug.Log("Level End!");
            }
        }

        public void Dispose()
        {
            _controlUnit.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}
