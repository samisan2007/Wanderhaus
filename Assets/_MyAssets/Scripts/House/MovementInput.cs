using UnityEngine;
using UnityEngine.Events;

namespace TravelingHouse.Movement
{
    [AddComponentMenu("Traveling House/Movement/Movement Input")]
    public sealed class MovementInput : MonoBehaviour
    {
        // ─── Events ────────────────────────────────────────────
        [System.Serializable] public class Vector3Event : UnityEvent<Vector3> { }
        [System.Serializable] public class FloatEvent   : UnityEvent<float>   { }

        public Vector3Event OnMove = new Vector3Event();
        public FloatEvent   OnTurn = new FloatEvent();

        // ─── Tuning ─────────────────────────────────────────────
        [Header("Linear (WASD)")]
        [SerializeField, Min(0f)]     float maxLinearSpeed = 3f;
        [SerializeField, Min(0.01f)]  float linearAccel    = 6f;

        [Header("Yaw (Q / E)")]
        [SerializeField, Min(0f)]     float maxTurnSpeed  = 90f;
        [SerializeField, Min(0.01f)]  float turnAccel     = 180f;

        // ─── Public setters for buffs (see HouseStats) ─────────
        public float MaxLinearSpeed { get => maxLinearSpeed;  set => maxLinearSpeed  = Mathf.Max(0f,   value); }
        public float MaxTurnSpeed   { get => maxTurnSpeed;    set => maxTurnSpeed    = Mathf.Max(0f,   value); }
        public float LinearAccel    { get => linearAccel;     set => linearAccel     = Mathf.Max(0.01f,value); }
        public float TurnAccel      { get => turnAccel;       set => turnAccel       = Mathf.Max(0.01f,value); }

        // ─── State ─────────────────────────────────────────────
        Vector3 currentLinearVel; // m/s  world space
        float   currentYawSpeed;  // °/s

        void Update()
        {
            // ------------ linear ------------------------------------
            float x = Input.GetAxisRaw("Horizontal");   // A / D
            float z = Input.GetAxisRaw("Vertical");     // W / S

            Vector3 moveDir = Vector3.zero;                           // ➜ renamed
            if (x != 0f || z != 0f)
                moveDir = transform.right * x + transform.forward * z;

            Vector3 targetLinearVel = moveDir.normalized * maxLinearSpeed;

            currentLinearVel = Vector3.MoveTowards(
                currentLinearVel,
                targetLinearVel,
                linearAccel * Time.deltaTime
            );

            if (currentLinearVel.sqrMagnitude > 0f)
                OnMove.Invoke(currentLinearVel * Time.deltaTime);

            // ------------ yaw ---------------------------------------
            float yawInput = 0f;                                       // ➜ renamed
            if (Input.GetKey(KeyCode.Q)) yawInput -= 1f;
            if (Input.GetKey(KeyCode.E)) yawInput += 1f;

            float targetYaw = yawInput * maxTurnSpeed;

            currentYawSpeed = Mathf.MoveTowards(
                currentYawSpeed,
                targetYaw,
                turnAccel * Time.deltaTime
            );

            if (!Mathf.Approximately(currentYawSpeed, 0f))
                OnTurn.Invoke(currentYawSpeed * Time.deltaTime);
        }

    }
}
