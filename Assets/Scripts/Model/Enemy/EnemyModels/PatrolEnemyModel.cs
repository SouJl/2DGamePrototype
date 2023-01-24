using PixelGame.Interfaces;
using PixelGame.Model.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace PixelGame.Model
{
    public class PatrolEnemyModel : AbstractAIEnemyModel<ILogicAI<List<Transform>>>
    {
        public PatrolEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer, ILogicAI<List<Transform>> logicAI) : base(components, spriteRenderer, logicAI)
        {

        }

        public override void RecalculatePath(Vector3 target)
        {
            if (LogicAI.ReachedEndOfPath) 
            {
                LogicAI.OnPathComplete(LogicAI.Path);
            }
        }

        public override void Rotate(Vector3 target)
        {
            if (UnitComponents.RgdBody.velocity.x > 0)
            {
                UnitComponents.Transform.localScale = new Vector3(1f, 1f, 1f);
            }
            else
            {
                UnitComponents.Transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }

    }
}
