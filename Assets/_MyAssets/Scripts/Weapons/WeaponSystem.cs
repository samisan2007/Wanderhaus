using TravelingHouse.Interfaces;
using UnityEngine;

namespace TravelingHouse.Weapons
{
    public class WeaponSystem : MonoBehaviour

    {
        IWeaponLoadout weaponLoadout;
        
        
        //apply upgrades to the weapon loadout
        public void ApplyUpgrade(string key)
        {
            if (weaponLoadout != null)
            {
                weaponLoadout.ApplyUpgrade(key);
            }
            else
            {
                Debug.LogWarning("WeaponLoadout is not set.");
            }
        }
    }
}