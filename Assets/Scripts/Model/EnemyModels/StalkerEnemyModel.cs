using Pathfinding;
using PixelGame.Interfaces;
using PixelGame.Model.Utils;
using UnityEngine;

namespace PixelGame.Model
{
    public class StalkerEnemyModel : AbstractAIEnemyModel
    {
        public StalkerEnemyModel(ComponentsModel components, SpriteRenderer spriteRenderer, IMove movementModel, ILogicAI logicAI) : base(components, spriteRenderer, movementModel, logicAI)
        {

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
            /*var selfDir = SpriteRenderer.transform.position;
            SpriteRenderer.flipX = selfDir.x > target.x ? true : false;*/
        }


        public override void RecalculatePath(Vector3 target)
        {
            if (LogicAI.Seeker.IsDone())
            {
                LogicAI.Seeker.StartPath(UnitComponents.RgdBody.position, target, OnPathComplete);
            }
        }

        protected override void OnPathComplete(Path p)
        {
            if (p.error) return;
            LogicAI.OnPathComplete(p);
        }
    }
}
