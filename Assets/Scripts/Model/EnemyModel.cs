using PixelGame.Interfaces;
using PixelGame.View;
using UnityEngine;

namespace PixelGame.Model
{
    public class EnemyModel : AbstractUnitModel
    {
        public EnemyModel(SpriteRenderer spriteRenderer, Collider2D collider2D, IMove movementModel, IJump jumpModel) : base(spriteRenderer, collider2D, movementModel, jumpModel)
        {

        }

        public void OnLocatorContact(LevelObjectView target) 
        {
            Debug.Log($"{this} locator contact {target.gameObject.tag}");
        }

        public void OnCloseContact(LevelObjectView target)
        {
            Debug.Log($"{this} close contact {target.gameObject.tag}");
        }
    }
}
