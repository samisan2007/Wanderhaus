using System.Collections;
using UnityEngine;

namespace TravelingHouse.Enemies
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] EnemyStats   enemyType;
        [SerializeField] GameObject   enemyPrefab;   // just needs EnemyHealth + AI
        [SerializeField] int          count = 5;
        [SerializeField] float        delayBetween = 1f;

        public void SpawnWave() => StartCoroutine(CoSpawn());

        IEnumerator CoSpawn()
        {
            for (int i = 0; i < count; i++)
            {
                var go = Instantiate(enemyPrefab, transform.position, transform.rotation);
                go.GetComponent<EnemyHealth>().name = enemyType.name; // nice hierarchy labels
                // Inject stats into components
                foreach (var c in go.GetComponentsInChildren<MonoBehaviour>())
                    if (c is EnemyHealth eh) eh.GetType().GetField("stats",
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        .SetValue(eh, enemyType);
                    else if (c is EnemyAI ai) ai.GetType().GetField("stats",
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                        .SetValue(ai, enemyType);

                yield return new WaitForSeconds(delayBetween);
            }
        }
    }
}