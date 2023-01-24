using Pathfinding;
using PixelGame.Interfaces;
using PixelGame.Model.StateMachines;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractAIEnemyModel<ILogicAI> : IUnit
    {
        public StateMachine UnitMovementSM { get; set; }
        public State IdleState { get; set; }

        private ComponentsModel _unitComponents;
        private SpriteRenderer _spriteRenderer;
        private ILogicAI _logicAI;


        public ComponentsModel UnitComponents { get => _unitComponents; }
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; }
        
        public ILogicAI LogicAI { get => _logicAI; }

        public Vector2 CurrentVelocity { get; set; }

        public Vector2 WorkVelocity { get; set; }

        public AbstractAIEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer, ILogicAI logicAI) 
        {
            _unitComponents = components;
            _spriteRenderer = spriteRenderer;
            _logicAI = logicAI;
        }

        public abstract void Rotate(Vector3 target);

        public abstract void RecalculatePath(Vector3 target);

    }
}
