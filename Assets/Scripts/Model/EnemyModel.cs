using PixelGame.Interfaces;
using UnityEngine;

namespace PixelGame.Model
{
    public class EnemyModel : AbstractUnitModel
    {
        public EnemyModel(SpriteRenderer spriteRenderer, Collider2D collider2D, IMove movementModel, IJump jumpModel) : base(spriteRenderer, collider2D, movementModel, jumpModel)
        {
           
        }     
    }
}
