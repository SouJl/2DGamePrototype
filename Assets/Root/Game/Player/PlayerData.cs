using UnityEngine;

namespace Root.PixelGame.Game
{
    internal interface IPlayerData 
    {
        float Speed { get; }
        float MoveThresh { get; }
        float JumpForce { get; }
        float JumpThreshold { get; }
        float WallJumpForce { get; }
        float WallJumpTime { get; }
        Vector2 WallJumpAngle { get; }
        float FlyThreshold { get; }
        float FallThreshold { get; }
        float WallCheckDistance { get; }
        float WallSlideSpeed { get; }
        Vector2 StartOffset { get; }
        Vector2 StopOffset { get; }
        float ClimbSmooth { get; }
        float CrouchMovementVelocity { get; }
        float CrouchColliderHeight { get; }
        float StandColliderHeight { get; }
    }

    [CreateAssetMenu(fileName = nameof(PlayerData), menuName = "Configs/Player/" + nameof(PlayerData))]
    internal class PlayerData : ScriptableObject, IPlayerData
    {
        [field: Header("Move Settings")]
        [field: SerializeField] public float Speed { get; private set; } = 10f;
        [field: SerializeField] public float MoveThresh { get; private set; } = 0.01f;

        [field: Header("Jump Settings")]
        [field: SerializeField] public float JumpForce { get; private set; } = 10f;
        [field: SerializeField] public float JumpThreshold { get; private set; } = 0.2f;

        [field: Header("Wall Jump Settings")]
        [field: SerializeField] public float WallJumpForce { get; private set; } = 20f;
        [field: SerializeField] public float WallJumpTime { get; private set; } = 0.4f;
        [field: SerializeField] public Vector2 WallJumpAngle { get; private set; } = new Vector2(1, 2);

        [field: Header("In Air Settings")]
        [field: SerializeField] public float FlyThreshold { get; private set; } = 0.2f;
        [field: SerializeField] public float FallThreshold { get; private set; } = 1f;

        [field: Header("Wall Slide Settings")]
        [field: SerializeField] public float WallCheckDistance { get; private set; } = 0.5f;
        [field: SerializeField] public float WallSlideSpeed { get; private set; } = 2f;

        [field: Header("Ledge Settings")]
        [field: SerializeField] public Vector2 StartOffset { get; private set; }
        [field: SerializeField] public Vector2 StopOffset { get; private set; }

        [field: Header("Climb Settings")]
        [field: SerializeField] public float ClimbSmooth { get; private set; } = 0.2f;

        [field: Header("Crouch Settings")]
        [field: SerializeField] public float CrouchMovementVelocity { get; private set; } = 5f;
        [field: SerializeField] public float CrouchColliderHeight { get; private set; } = 0.8f;
        [field: SerializeField] public float StandColliderHeight { get; private set; } = 1.6f;

        
    }
}
