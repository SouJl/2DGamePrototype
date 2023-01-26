using PixelGame.Interfaces;
using PixelGame.Model.AIModels;
using PixelGame.Model.StateMachines;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model
{
    public abstract class AbstractAIEnemyModel: IUnit
    {
        public StateMachine UnitMovementSM { get; set; }
        public State IdleState { get; set; }

        private ComponentsModel _unitComponents;
        private SpriteRenderer _spriteRenderer;
        private AbstractAIModel _logicAI;


        public ComponentsModel UnitComponents { get => _unitComponents; }
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; }
        
        public AbstractAIModel LogicAI { get => _logicAI; }

        public Vector2 CurrentVelocity { get; set; }

        public Vector2 WorkVelocity { get; set; }

        public AbstractAIEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer, AbstractAIModel logicAI) 
        {
            _unitComponents = components;
            _spriteRenderer = spriteRenderer;
            _logicAI = logicAI;
        }

        public abstract void Move();

        public abstract void Rotate(Vector3 target);

        public abstract void RecalculatePath();

    }
}
