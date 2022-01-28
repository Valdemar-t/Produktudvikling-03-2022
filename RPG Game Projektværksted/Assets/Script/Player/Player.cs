using UnityEditor;
using UnityEngine;

namespace Player
{
    public sealed class Player : PlayerCombat
    {
        [SerializeField, Header("Attributes")] private float maxHealth;
        [SerializeField] private float maxMana;
        [HideInInspector] public float currentHealth;
        [HideInInspector] public float currentMana;

        private void Awake()
        {
            currentHealth = maxHealth;
            currentMana = maxMana;
        }

        protected override void OnPlayerUpdate()
        {
            base.OnPlayerUpdate();
            if (debug) if (Input.GetKeyDown(KeyCode.Alpha1)) Damage(5);
        }

        public void Damage(float attackDamage)
        {
            if (debug) Debug.Log("\tPlayer Got Hit", this);
            currentHealth -= attackDamage;

            if (currentHealth <= 0) Die();
        }

        private void Die()
        {
            if (debug) Debug.Log(shouldRespawn ? "\tPlayer Died and Should Respawn" : "\tPlayer Died and Not Respawning\n\t\tGame Over", this);
            if (shouldRespawn) Respawn();
            else
            {
                currentHealth = 0;
                Destroy(gameObject);
                #if UNITY_EDITOR
                if (EditorApplication.isPlaying) EditorApplication.ExitPlaymode();
                #endif
            }
        }

        private void Respawn()
        {
            currentHealth = maxHealth;
        }
    }
}