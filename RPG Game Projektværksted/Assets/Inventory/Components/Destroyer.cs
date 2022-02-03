#region

using UnityEngine;

#endregion

namespace Inventory.Scripts
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField] private float lifeTimer;

        private void Start() => Destroy(gameObject, lifeTimer);
    }
}