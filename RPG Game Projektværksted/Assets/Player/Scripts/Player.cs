#region

using SilentWolfHelper;
using SilentWolfHelper.Debugger;
using UnityEditor;
using UnityEngine;

#endregion

namespace Player.Scripts
{
    public sealed class Player : PlayerCombat
    {
        [SerializeField, Header("Attributes")] private float maxHealth;
        [SerializeField] private float maxMana;

        [SerializeField, Header("Respawn")] private Transform respawnPoint;
        [SerializeField, Space] private CanvasGroup respawnPanel;

        [HideInInspector] public float currentHealth;
        [HideInInspector] public float currentMana;

        public void Damage(float attackDamage)
        {
            if (debug) DebugSW.Log("\tPlayer:lightGreen; Got:lightPurple; Hit:lightRed;", this);
            currentHealth -= attackDamage;

            if (currentHealth <= 0) Die();
        }

        private void Die()
        {
            if (debug) DebugSW.Log(shouldRespawn ? "\tPlayer:lightGreen; Died:lightRed; and Should:lightPurple; Respawn:orange;" : "\tPlayer:lightGreen; Died:lightRed; and Not Respawning:lightPurple;\n\t\tGame Over:darkRed;", this);
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
            UI.Fade(respawnPanel);
            transform.position = respawnPoint.position;
            currentHealth = maxHealth;
        }

        #region Custom MonoBehaviour Methods

        protected override void OnPlayerAwake()
        {
            base.OnPlayerAwake();
            currentHealth = maxHealth;
            currentMana = maxMana;
            transform.position = respawnPoint.position;
            respawnPanel.enabled = false;
        }

        protected override void OnPlayerStart() => base.OnPlayerStart();

        protected override void OnPlayerUpdate()
        {
            base.OnPlayerUpdate();
            if (debug)
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    Damage(5);
        }

        #endregion
    }
}