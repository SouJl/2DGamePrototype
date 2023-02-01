using UnityEngine;

namespace PixelGame.Configs
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Configs/UnitConfigs/Player")]
    public class PlayerData: ScriptableObject
    {
        [Header("Move settings")]
        public float speed = 10f;
        public float moveThresh = 0.01f;

        [Header("Jump Settings")]
        public float jumpForce = 10f;
        public float jumpThreshold = 0.2f;

        [Header("Roll Settings")]
        public int rollFrames = 12;

        [Header("Wall Jump Settings")]
        public float wallJumpForce = 20f;
        public float wallJumpTime = 0.4f;
        public Vector2 wallJumpAngle = new Vector2(1, 2);

        [Header("In Air Settings")]
        public float flyThreshold = 0.2f;
        public float fallThreshold = 1f;

        [Header("Wall Slide Settings")]
        public float wallCheckDistance = 0.5f;
        public float wallSlideSpeed = 2f;

        [Header("Ledge Settings")]
        public Vector2 startOffset;
        public Vector2 stopOffset;

        [Header("Climb Settings")]
        public float climbSmooth = 0.2f;
        
        
        [Header("Crouch Settings")]
        public float crouchMovementVelocity = 5f;
        public float crouchColliderHeight = 0.8f;
        public float standColliderHeight = 1.6f;
    }
}
