using UnityEngine;

namespace Combat
{
    public class MeleeWeapon : MonoBehaviour
    {
        public string weaponName;
        [TextArea] public string description;
        public float range, damage;
    }
}
