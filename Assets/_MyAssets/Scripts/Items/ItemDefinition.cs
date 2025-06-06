using UnityEngine;

namespace TravelingHouse.Items
{
    public enum EffectType
    {
        MoveSpeedMult,   // %  boost   e.g. 0.25 = +25 %
        TurnSpeedMult,   // %  boost
        LinearAccelAdd,  // + m/s²
        TurnAccelAdd,    // + °/s²
        Repair,          // + HP
        WeaponUpgrade    // generic, handled by your weapon system
    }

    [CreateAssetMenu(menuName = "Traveling House/Item Definition")]
    public sealed class ItemDefinition : ScriptableObject
    {
        [System.Serializable]
        public struct Effect
        {
            public EffectType type;
            public float      amount;
        }

        public string displayName;
        [TextArea] public string description;
        public Effect[] effects;
        public Sprite   icon;     // optional UI
        public GameObject worldPrefab;  // optional for programmatic spawning
    }
}