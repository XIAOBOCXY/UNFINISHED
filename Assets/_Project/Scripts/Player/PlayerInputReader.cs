using UnityEngine;

namespace Unfinished.Player
{
    /// <summary>Reads the current keyboard movement input without applying gameplay behavior.</summary>
    [DisallowMultipleComponent]
    public sealed class PlayerInputReader : MonoBehaviour
    {
        public Vector2 ReadMoveInput()
        {
            var input = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"));

            return Vector2.ClampMagnitude(input, 1f);
        }
    }
}
