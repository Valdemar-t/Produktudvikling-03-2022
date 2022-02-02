using UnityEngine;

// ReSharper disable NotAccessedField.Global

namespace Weapon
{
    public class MeleeWeapon : MonoBehaviour
    {
        public string weaponName;
        [TextArea] public string description;
        public float range, damage;
        public Transform attackPoint;
    }
}
