// ReSharper disable ParameterHidesMember

using CustomInspector.Attributes;
using UnityEngine;

// ReSharper disable VirtualMemberNeverOverridden.Global

namespace Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField, Header("Toggles"), LeftToggle, Tooltip("This is a Debug switch")] private bool debug;
        [SerializeField, Header("Health"), Tooltip("This is the health of the enemy")] public float maxHealth;
        [SerializeField, Header("Attack"), Tooltip("This is the attack damage the enemy does")] public float attackDamage; 
        [SerializeField, Space, Tooltip("This is the attack range the enemy has")] public float attackRange;
        [HideInInspector] public float currentHealth;

        private void Start() => currentHealth = maxHealth;

        public virtual void Damage(float attackDamage)
        {
            currentHealth -= attackDamage;
            if (!(currentHealth <= 0)) return;
            Die();
            currentHealth = 0;
        }

        protected virtual void Die()
        {
            #if UNITY_EDITOR
            if (debug) Debug.Log($"\t{name} Died", this);
            #endif
            Destroy(gameObject);
        }
    }
}