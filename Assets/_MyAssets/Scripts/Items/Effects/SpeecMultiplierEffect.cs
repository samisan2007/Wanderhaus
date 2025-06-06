// Assets/_MyAssets/Scripts/Items/Effects/SpeedMultiplierEffect.cs
using UnityEngine;
using TravelingHouse.Movement;
using TravelingHouse.Items;

namespace TravelingHouse.Items.Effects
{
    [CreateAssetMenu(menuName = "Traveling House/Effects/Speed Multiplier")]
    public sealed class SpeedMultiplierEffect : ItemEffectBase
    {
        [Min(0f)] public float factor = 1.25f;  // 1.25 = +25 %

        public override void Apply(GameObject target)
        {
            if (target.TryGetComponent(out MovementInput move))
            {
                move.MaxLinearSpeed *= factor;
                move.MaxTurnSpeed   *= factor;
            }
        }
    }
}