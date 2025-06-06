// Assets/_MyAssets/Scripts/House/HouseStats.cs
using UnityEngine;
using TravelingHouse.Interfaces;
using TravelingHouse.Movement;
using TravelingHouse.Weapons;

namespace TravelingHouse.House
{
    /// <summary>
    /// Simple aggregator so other scripts can grab
    /// health, movement, or weapon systems from one place.
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class HouseStats : MonoBehaviour,
        IHealth,              // forwarders
        IWeaponLoadout        // forwarders
    {
        [Header("Subsystems (auto-filled)")]
        [SerializeField] HouseHealth     health;
        [SerializeField] MovementInput   movement;
        [SerializeField] WeaponSystem    weapons;   // Your own script that implements IWeaponLoadout

        void Awake()
        {
            health   ??= GetComponent<HouseHealth>();
            movement ??= GetComponent<MovementInput>();
            weapons  ??= GetComponent<WeaponSystem>();
        }

        /* ---------- IHealth passthrough ---------- */
        public int  CurrentHealth
        {
            get => health.CurrentHealth;
            set => health.CurrentHealth = value;
        }
        public int  MaxHealth   => health.MaxHealth;

        /* ---------- IWeaponLoadout passthrough --- */
        public void ApplyUpgrade(string key) => weapons.ApplyUpgrade(key);

        /* ---------- Convenience accessors -------- */
        public MovementInput Movement => movement;
        public WeaponSystem  Weapons  => weapons;
    }
}