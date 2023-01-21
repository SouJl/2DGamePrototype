using Pathfinding;
using PixelGame.Interfaces;
using PixelGame.Model.StateMachines;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractAIEnemyModel:IUnit
    {
        public StateMachine UnitMovementSM { get; set; }
        public State IdleState { get; set; }

        private ComponentsModel _unitComponents;
        private SpriteRenderer _spriteRenderer;
        private IMove _moveModel;
        private ILogicAI _logicAI;


        public ComponentsModel UnitComponents { get => _unitComponents; }
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; }
        
        public IMove MoveModel { get => _moveModel; }
        public ILogicAI LogicAI { get => _logicAI; }

        public AbstractAIEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer, IMove movementModel, ILogicAI logicAI) 
        {
            _unitComponents = components;
            _spriteRenderer = spriteRenderer;
            _moveModel = movementModel;
            _logicAI = logicAI;
        }

        public abstract void Rotate(Vector3 target);

        public abstract void RecalculatePath(Vector3 target);

        protected abstract void OnPathComplete(Path p);
    }
}
