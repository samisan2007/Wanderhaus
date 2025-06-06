using UnityEngine;

namespace TravelingHouse.Movement
{
    /// <summary>
    /// Applies displacement and yaw to the entire stage,
    /// making the stationary house appear to move/turn.
    /// </summary>
    [AddComponentMenu("Traveling House/Movement/Stage Mover")]
    public sealed class StageMover : MonoBehaviour
    {
        /// <param name="displacement">Desired house motion (world-space, metres this frame).</param>
        public void ApplyDisplacement(Vector3 displacement)
        {
            // Move world opposite to the requested motion
            transform.Translate(-displacement, Space.World);
        }

        /// <param name="yawDegrees">Desired house yaw (degrees this frame, +right / -left).</param>
        public void ApplyYaw(float yawDegrees)
        {
            // Rotate world opposite to the requested yaw
            transform.Rotate(Vector3.up, yawDegrees, Space.World);
        }
    }
}