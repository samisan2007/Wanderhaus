// Assets/_MyAssets/Scripts/Items/ItemEffectBase.cs
using UnityEngine;

namespace TravelingHouse.Items
{
    /// <summary>
    /// Shared fields for all effects (icon, cooldown, etc.).
    /// Still implements IItemEffect so systems remain interface-driven.
    /// </summary>
    public abstract class ItemEffectBase : ScriptableObject, IItemEffect
    {
        public Sprite icon;       // Designer eye-candy
        public float  cooldown;   // For future use

        public abstract void Apply(GameObject target);
    }
}