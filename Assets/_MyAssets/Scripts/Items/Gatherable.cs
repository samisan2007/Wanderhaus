using UnityEngine;
using TravelingHouse.Items;
using TravelingHouse.Core;

namespace TravelingHouse.Items
{
    /// <summary>
    /// Simple trigger pickup. Tag the house root "Player" (or change the tag check).
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public sealed class Gatherable : MonoBehaviour
    {
        [SerializeField] ItemDefinition item;

        void Reset()  => GetComponent<Collider>().isTrigger = true;
        void Awake()  => GetComponent<Collider>().isTrigger = true;

        void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            GameEvents.RaiseItemCollected(item);
            Destroy(gameObject);               // vanish after pickup
        }
    }
}