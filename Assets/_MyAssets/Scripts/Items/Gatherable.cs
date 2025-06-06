// Assets/_MyAssets/Scripts/Items/Gatherable.cs
using UnityEngine;

namespace TravelingHouse.Items
{
    [RequireComponent(typeof(Collider))]
    public sealed class Gatherable : MonoBehaviour
    {
        [SerializeField] ItemDefinition item;

        void Reset()  => GetComponent<Collider>().isTrigger = true;
        void Awake()  => GetComponent<Collider>().isTrigger = true;

        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            foreach (ScriptableObject so in item.effects)
            {
                if (so is IItemEffect effect)
                    effect.Apply(other.gameObject);
            }

            Destroy(gameObject);
        }
    }
}