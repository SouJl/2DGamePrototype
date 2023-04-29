using PixelGame.Tool.PlayerSearch;
using UnityEditor;
using UnityEngine;

namespace PixelGame.Components.Core
{
    internal interface IPlayerDetectionComponent
    {
        Transform PlayerCheckTransform { get; }
        Transform HandlerTransform { get; }
        IPlayerDetectionData Config { get; }
    }

    internal class PlayerDetectionComponent : MonoBehaviour, IPlayerDetectionComponent
    { 
        [SerializeField] private Transform _playerCheckTransform;
        [SerializeField] private PlayerDetectionConfig _config;
        [SerializeField] private Transform _handlerTransform;

        [SerializeField] private bool _showRangeDistance = true;
        [SerializeField] private bool _showRangeLabels = false;

        public Transform PlayerCheckTransform => _playerCheckTransform;

        public Transform HandlerTransform => _handlerTransform;

        public IPlayerDetectionData Config => _config;

        private Vector2 _labelOffset = new Vector2(0, 0.1f);

        private void OnValidate()
        {
            _handlerTransform = gameObject.transform;
        }


        public virtual void OnDrawGizmos()
        {
            if (_showRangeDistance && (_config && _playerCheckTransform))
            {
                Gizmos.color = Color.red;
               
                Gizmos.DrawWireSphere(_playerCheckTransform.position + (Vector3)(_handlerTransform.right * _config.CloseActionDistance), 0.3f); 
                Gizmos.DrawWireSphere(_playerCheckTransform.position + (Vector3)(_handlerTransform.right * _config.MinCheckDistance), 0.3f);            
                Gizmos.DrawWireSphere(_playerCheckTransform.position + (Vector3)(_handlerTransform.right * _config.MaxCheckDistance), 0.3f);

                if (_showRangeLabels)
                {
                    Handles.Label(_playerCheckTransform.position + (Vector3)((Vector2)_handlerTransform.right * _config.CloseActionDistance + _labelOffset), "CloseAction");
                    Handles.Label(_playerCheckTransform.position + (Vector3)((Vector2)_handlerTransform.right * _config.MinCheckDistance + _labelOffset), "MinRange");
                    Handles.Label(_playerCheckTransform.position + (Vector3)((Vector2)_handlerTransform.right * _config.MaxCheckDistance + _labelOffset), "MaxRange");
                }
            }
        }
    }
}
