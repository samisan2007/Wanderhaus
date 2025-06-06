using UnityEngine;

namespace TravelingHouse.Movement
{
    [AddComponentMenu("Traveling House/Movement/Stage Mover")]
    public sealed class StageMover : MonoBehaviour
    {
        [Header("Rotation pivot (house root)")]
        [Tooltip("Leave empty to auto-find an object tagged 'Player'.")]
        [SerializeField] Transform housePivot;

        void Awake()
        {
            if (housePivot == null)
            {
                var player = GameObject.FindGameObjectWithTag("Player");
                if (player != null) housePivot = player.transform;
            }
        }

        // --- called by MovementInput.OnMove --------------------
        public void ApplyDisplacement(Vector3 displacement)
        {
            transform.Translate(-displacement, Space.World);
        }

        // --- called by MovementInput.OnTurn --------------------
        public void ApplyYaw(float yawDegrees)
        {
            if (housePivot == null)
            {
                // fallback: rotate around own pivot (old behaviour)
                transform.Rotate(Vector3.up, -yawDegrees, Space.World);
                return;
            }

            // Rotate the world around the HOUSE position,   ➜
            // not around the Stage’s origin.
            transform.RotateAround(
                housePivot.position,
                Vector3.up,
                -yawDegrees   // opposite direction so house turns right way
            );
        }
    }
}