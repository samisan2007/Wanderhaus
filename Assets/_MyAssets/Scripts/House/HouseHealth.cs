// Assets/_MyAssets/Scripts/House/HouseHealth.cs
using UnityEngine;
using TravelingHouse.Interfaces;

namespace TravelingHouse.House
{
    public sealed class HouseHealth : MonoBehaviour, IHealth
    {
        [SerializeField, Min(1)] int maxHealth = 100;
        [SerializeField]         int currentHealth = 100;

        public int CurrentHealth
        {
            get => currentHealth;
            set => currentHealth = Mathf.Clamp(value, 0, maxHealth);
        }

        public int MaxHealth => maxHealth;
    }
}