// Assets/_MyAssets/Scripts/Interfaces/IHealth.cs
namespace TravelingHouse.Interfaces
{
    public interface IHealth
    {
        int  CurrentHealth { get; set; }
        int  MaxHealth     { get; }
    }
}