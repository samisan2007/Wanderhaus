// Assets/_MyAssets/Scripts/Items/Effects/WeaponUpgradeEffect.cs
using UnityEngine;
using TravelingHouse.Interfaces;
using TravelingHouse.Items;

namespace TravelingHouse.Items.Effects
{
    [CreateAssetMenu(menuName = "Traveling House/Effects/Weapon Upgrade")]
    public sealed class WeaponUpgradeEffect : ItemEffectBase
    {
        public string upgradeKey;

        public override void Apply(GameObject target)
        {
            if (target.TryGetComponent(out IWeaponLoadout loadout))
                loadout.ApplyUpgrade(upgradeKey);
        }
    }
}