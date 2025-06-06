using UnityEngine;
using UnityEngine.Events;
using TravelingHouse.Interfaces;

namespace TravelingHouse.Enemies
{
    /// <summary>Health container shared by AI, weapons, UI, etc.</summary>
    [DisallowMultipleComponent]
    public sealed class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] EnemyStats stats;
        [SerializeField] UnityEvent onDeath;           // optional VFX, sound
        [SerializeField] UnityEvent<int> onDamaged;    // int = amount

        int current;

        void Awake() => current = stats.maxHealth;

        /* ---------- IHealth ---------- */
        public int CurrentHealth
        {
            get => current;
            set
            {
                int newVal = Mathf.Clamp(value, 0, stats.maxHealth);
                if (newVal == current) return;

                int delta = newVal - current;
                current = newVal;
                if (delta < 0) onDamaged.Invoke(-delta);

                if (current == 0) Die();
            }
        }
        public int MaxHealth => stats.maxHealth;

        /* ---------- helpers ---------- */
        public void TakeDamage(int amount) => CurrentHealth -= amount;

        void Die()
        {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }
}