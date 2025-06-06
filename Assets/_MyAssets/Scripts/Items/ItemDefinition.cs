// Assets/_MyAssets/Scripts/Items/ItemDefinition.cs
using UnityEngine;

namespace TravelingHouse.Items
{
    [CreateAssetMenu(menuName = "Traveling House/Item")]
    public sealed class ItemDefinition : ScriptableObject
    {
        public string  displayName;
        [TextArea] public string description;
        public Sprite  icon;

        [Tooltip("All effects fired when this item is collected.")]
        public ScriptableObject[] effects; // must implement IItemEffect
    }
}