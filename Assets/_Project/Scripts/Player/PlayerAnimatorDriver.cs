using UnityEngine;

namespace Unfinished.Player
{
    /// <summary>Maps gameplay state to the integer parameters in Player.controller.</summary>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Animator))]
    public sealed class PlayerAnimatorDriver : MonoBehaviour
    {
        private static readonly int ActionParameter = Animator.StringToHash("Action");
        private static readonly int FacingParameter = Animator.StringToHash("Facing");

        private Animator _animator;
        private PlayerAction _lastAction;
        private PlayerFacing _lastFacing;
        private bool _hasAppliedState;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetState(PlayerAction action, PlayerFacing facing)
        {
            if (_animator == null)
            {
                return;
            }

            if (!_hasAppliedState || action != _lastAction)
            {
                _animator.SetInteger(ActionParameter, (int)action);
                _lastAction = action;
            }

            if (!_hasAppliedState || facing != _lastFacing)
            {
                _animator.SetInteger(FacingParameter, (int)facing);
                _lastFacing = facing;
            }

            _hasAppliedState = true;
        }
    }
}
