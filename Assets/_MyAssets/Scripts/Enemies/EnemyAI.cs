using UnityEngine;
using UnityEngine.AI;
using TravelingHouse.Interfaces;

namespace TravelingHouse.Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class EnemyAI : MonoBehaviour
    {
        [SerializeField] EnemyStats stats;
        [SerializeField] string     targetTag = "Player";   // house root

        NavMeshAgent agent;
        Transform    target;
        float        nextAttackTime;

        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed            = stats.moveSpeed;
            agent.stoppingDistance = stats.stoppingDistance;

            target = GameObject.FindGameObjectWithTag(targetTag)?.transform;
        }

        void Update()
        {
            if (!target) return;

            agent.SetDestination(target.position);

            // Simple melee: if close enough & off cooldown, hurt IHealth
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (Time.time >= nextAttackTime &&
                    target.TryGetComponent(out IHealth hp))
                {
                    hp.CurrentHealth -= stats.damage;
                    nextAttackTime = Time.time + stats.attackCooldown;
                }
            }
        }
    }
}