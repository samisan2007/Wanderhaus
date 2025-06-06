using UnityEngine;
using UnityEngine.Events;

namespace TravelingHouse.Movement
{
    /// <summary>
    /// Emits smoothed displacement and yaw requests each frame.
    /// Uses simple MoveTowards-based acceleration so you get
    /// ramp-up / ramp-down without extra state machines.
    /// </summary>
    [AddComponentMenu("Traveling House/Movement/Movement Input")]
    public sealed class MovementInput : MonoBehaviour
    {
        // ─── Events ──────────────────────────────────────────────
        [System.Serializable] public class Vector3Event : UnityEvent<Vector3> { }
        [System.Serializable] public class FloatEvent   : UnityEvent<float>   { }

        public Vector3Event OnMove = new Vector3Event();
        public FloatEvent   OnTurn = new FloatEvent();
        
        
        // ─── Properties ──────────────────────────────────────────
        public float MaxLinearSpeed { get => maxLinearSpeed;  set => maxLinearSpeed  = Mathf.Max(0f,   value); }
        public float MaxTurnSpeed   { get => maxTurnSpeed;    set => maxTurnSpeed    = Mathf.Max(0f,   value); }
        public float LinearAccel    { get => linearAccel;     set => linearAccel     = Mathf.Max(0.01f,value); }
        public float TurnAccel      { get => turnAccel;       set => turnAccel       = Mathf.Max(0.01f,value); }

        // ─── Translation tuning ─────────────────────────────────
        [Header("Linear (WASD)")]
        [Tooltip("Top speed in m/s.")]
        [SerializeField, Min(0f)]  float maxLinearSpeed   = 3f;
        [Tooltip("How fast to reach / leave max speed (m/s²).")]
        [SerializeField, Min(0.01f)] float linearAccel    = 6f;

        // ─── Rotation tuning ────────────────────────────────────
        [Header("Yaw (Q / E)")]
        [Tooltip("Top turn rate in °/s.")]
        [SerializeField, Min(0f)]  float maxTurnSpeed     = 90f;
        [Tooltip("How fast to reach / leave max turn (°/s²).")]
        [SerializeField, Min(0.01f)] float turnAccel      = 180f;

        // ─── State ──────────────────────────────────────────────
        Vector3 currentLinearVel;   // m/s, world-space
        float   currentYawSpeed;    // °/s  (+ = right)

        void Update()
        {
            // -------- Target linear velocity --------------------
            float x = Input.GetAxisRaw("Horizontal");   // A / D
            float z = Input.GetAxisRaw("Vertical");     // W / S
            Vector3 targetLinearVel = Vector3.zero;
            if (x != 0f || z != 0f)
                targetLinearVel = new Vector3(x, 0f, z).normalized * maxLinearSpeed;

            // Smooth toward/away from target
            currentLinearVel = Vector3.MoveTowards(
                currentLinearVel,
                targetLinearVel,
                linearAccel * Time.deltaTime
            );

            // Send displacement for this frame
            if (currentLinearVel.sqrMagnitude > 0f)
                OnMove.Invoke(currentLinearVel * Time.deltaTime);

            // -------- Target yaw speed --------------------------
            float dir = 0f;
            if (Input.GetKey(KeyCode.Q)) dir -= 1f;
            if (Input.GetKey(KeyCode.E)) dir += 1f;
            float targetYawSpeed = dir * maxTurnSpeed;

            // Smooth toward/away
            currentYawSpeed = Mathf.MoveTowards(
                currentYawSpeed,
                targetYawSpeed,
                turnAccel * Time.deltaTime
            );

            // Send yaw for this frame
            if (!Mathf.Approximately(currentYawSpeed, 0f))
                OnTurn.Invoke(currentYawSpeed * Time.deltaTime);
        }
    }
}
