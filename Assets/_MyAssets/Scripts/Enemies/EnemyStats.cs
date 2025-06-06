using UnityEngine;

namespace TravelingHouse.Enemies
{
    [CreateAssetMenu(menuName = "Traveling House/Enemy Stats")]
    public sealed class EnemyStats : ScriptableObject
    {
        [Header("Vitals")]
        [Min(1)] public int   maxHealth = 20;

        [Header("Movement")]
        [Min(0f)] public float moveSpeed = 3f;
        [Min(0f)] public float stoppingDistance = 2f;

        [Header("Combat")]
        [Min(1)] public int damage = 10;
        public float attackCooldown = 1.5f;
    }
}