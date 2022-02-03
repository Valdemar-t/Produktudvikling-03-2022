#region

using UnityEngine;

#endregion

namespace Inventory.Components
{
    public class Destroyer : MonoBehaviour
    {
        [SerializeField] private float lifeTimer;

        private void Start() => Destroy(gameObject, lifeTimer);
    }
}