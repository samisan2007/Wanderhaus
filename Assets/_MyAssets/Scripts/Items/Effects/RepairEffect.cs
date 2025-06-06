// Assets/_MyAssets/Scripts/Items/Effects/RepairEffect.cs
using UnityEngine;
using TravelingHouse.Interfaces;
using TravelingHouse.Items;

namespace TravelingHouse.Items.Effects
{
    [CreateAssetMenu(menuName = "Traveling House/Effects/Repair")]
    public sealed class RepairEffect : ItemEffectBase
    {
        [Min(1)] public int healAmount = 25;

        public override void Apply(GameObject target)
        {
            if (target.TryGetComponent(out IHealth hp))
            {
                hp.CurrentHealth = Mathf.Min(hp.CurrentHealth + healAmount, hp.MaxHealth);
                Debug.Log($"Repaired {target.name} for {healAmount} health. Current health: {hp.CurrentHealth}/{hp.MaxHealth}");
            }
            
        }
    }
}