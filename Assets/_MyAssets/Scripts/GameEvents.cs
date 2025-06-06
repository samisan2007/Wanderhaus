using System;
using TravelingHouse.Items;

namespace TravelingHouse.Core
{
    /// <summary>A tiny event bus so systems never need direct references.</summary>
    public static class GameEvents
    {
        public static event Action<ItemDefinition> ItemCollected;

        public static void RaiseItemCollected(ItemDefinition item) =>
            ItemCollected?.Invoke(item);
    }
}