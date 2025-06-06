using UnityEngine;
using TravelingHouse.Items;
using TravelingHouse.Core;
using TravelingHouse.Movement;

namespace TravelingHouse.House
{
    /// <summary>
    /// Owns movement buffs, health, and forwards weapon upgrades.
    /// </summary>
    public sealed class HouseStats : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] MovementInput movement;   // auto-filled in Awake

        [Header("Health")]
        [SerializeField, Min(1)] int maxHealth = 100;
        [SerializeField]           int currentHealth = 100;

        void Awake()
        {
            if (movement == null)
                movement = GetComponent<MovementInput>();
        }

        void OnEnable()  => GameEvents.ItemCollected += ApplyItem;
        void OnDisable() => GameEvents.ItemCollected -= ApplyItem;

        void ApplyItem(ItemDefinition item)
        {
            foreach (var eff in item.effects)
            {
                switch (eff.type)
                {
                    case EffectType.MoveSpeedMult:
                        movement.MaxLinearSpeed *= 1f + eff.amount;
                        break;

                    case EffectType.TurnSpeedMult:
                        movement.MaxTurnSpeed   *= 1f + eff.amount;
                        break;

                    case EffectType.LinearAccelAdd:
                        movement.LinearAccel    += eff.amount;
                        break;

                    case EffectType.TurnAccelAdd:
                        movement.TurnAccel      += eff.amount;
                        break;

                    case EffectType.Repair:
                        currentHealth = Mathf.Clamp(currentHealth + Mathf.RoundToInt(eff.amount),
                                                    0, maxHealth);
                        break;

                    case EffectType.WeaponUpgrade:
                        // Fire-and-forget; your weapon system can listen too.
                        SendMessage("ApplyWeaponUpgrade",
                                    eff.amount,
                                    SendMessageOptions.DontRequireReceiver);
                        break;
                }
            }
        }
    }
}
