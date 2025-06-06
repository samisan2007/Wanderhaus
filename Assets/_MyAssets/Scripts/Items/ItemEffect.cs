// Assets/_MyAssets/Scripts/Items/IItemEffect.cs
namespace TravelingHouse.Items
{
    /// <summary>Any ScriptableObject that can be triggered by an item pickup.</summary>
    public interface IItemEffect
    {
        /// <param name="target">GameObject that collected the item (the house root).</param>
        void Apply(UnityEngine.GameObject target);
    }
}