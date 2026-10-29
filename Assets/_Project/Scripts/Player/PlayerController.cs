using UnityEngine;

namespace Unfinished.Player
{
    public enum PlayerAction
    {
        Idle = 0,
        Run = 1,
        Draw = 2,
        Shoot = 3,
        Hurt = 4,
        Celebrate = 5
    }

    public enum PlayerFacing
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }

    /// <summary>Coordinates keyboard input, movement, facing, and the current locomotion animation.</summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PlayerInputReader), typeof(PlayerMotor2D), typeof(PlayerAnimatorDriver))]
    public sealed class PlayerController : MonoBehaviour
    {
        private const float InputDeadZoneSquared = 0.0001f;

        [SerializeField] private PlayerFacing initialFacing = PlayerFacing.South;

        private PlayerInputReader _inputReader;
        private PlayerMotor2D _motor;
        private PlayerAnimatorDriver _animatorDriver;
        private PlayerFacing _facing;

        private void Awake()
        {
            _inputReader = GetComponent<PlayerInputReader>();
            _motor = GetComponent<PlayerMotor2D>();
            _animatorDriver = GetComponent<PlayerAnimatorDriver>();
            _facing = initialFacing;
        }

        private void Update()
        {
            var moveInput = _inputReader.ReadMoveInput();
            var isMoving = moveInput.sqrMagnitude > InputDeadZoneSquared;

            if (!isMoving)
            {
                moveInput = Vector2.zero;
            }
            else
            {
                _facing = ResolveFacing(moveInput, _facing);
            }

            _motor.SetMoveInput(moveInput);
            _animatorDriver.SetState(isMoving ? PlayerAction.Run : PlayerAction.Idle, _facing);
        }

        private void OnDisable()
        {
            if (_motor != null)
            {
                _motor.StopImmediately();
            }
        }

        private static PlayerFacing ResolveFacing(Vector2 direction, PlayerFacing currentFacing)
        {
            var absX = Mathf.Abs(direction.x);
            var absY = Mathf.Abs(direction.y);

            // Keep the prior cardinal direction on an exact diagonal to avoid visual flicker.
            if (Mathf.Approximately(absX, absY))
            {
                return currentFacing;
            }

            if (absX > absY)
            {
                return direction.x > 0f ? PlayerFacing.East : PlayerFacing.West;
            }

            return direction.y > 0f ? PlayerFacing.North : PlayerFacing.South;
        }
    }
}
