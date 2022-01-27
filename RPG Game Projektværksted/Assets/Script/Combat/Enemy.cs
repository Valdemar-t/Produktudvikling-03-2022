// ReSharper disable ParameterHidesMember

using UnityEngine;

namespace Combat
{
    public abstract class Enemy : MonoBehaviour
    {
        public float maxHealth, attackDamage, attackRange;
        [HideInInspector] public float currentHealth;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        public virtual void Damage(float attackDamage)
        {
            currentHealth -= attackDamage;
            if (!(currentHealth <= 0)) return;
            Die();
            currentHealth = 0;
        }

        protected virtual void Die()
        {
            Debug.Log($"{name} Died", this);
        }
    }
}