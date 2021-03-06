#region

using System.ComponentModel;
using Managers;
using SilentWolfHelper.CustomInspector.Attributes;
using SilentWolfHelper.Debugger;
using UnityEngine;
using Weapon;

#endregion

// ReSharper disable Unity.PreferNonAllocApi
// ReSharper disable NotAccessedField.Local

namespace Player.Scripts
{
    public class PlayerCombat : PlayerMovement
    {

        private static readonly int Attack1 = Animator.StringToHash("Attack");
        [SerializeField, Header("Player"), Tooltip("This is players animator")] private Animator animator;
        [SerializeField, Header("Enemy"), Tooltip("This is the enemy layer masks")] private LayerMask enemyLayers;
        [SerializeField, Header("Weapon"), ConditionalHide("debug"), Tooltip("This is the weapon the player gets at the start of the game (For debugging)")] private MeleeWeapon testEquipWeapon;
        [SerializeField, Space, ConditionalHide("debug"), ReadOnly(true), Tooltip("This is the weapon the player currently have in the hand (Read Only)")] private MeleeWeapon currentWeapon;
        private float attackRange, attackDamage;

        private void OnDrawGizmosSelected()
        {
            if (currentWeapon != null && currentWeapon.attackPoint != null) Gizmos.DrawWireSphere(currentWeapon.attackPoint.position, testEquipWeapon.range);
        }

        private void OnValidate() => currentWeapon = testEquipWeapon != null ? testEquipWeapon : null;

        private void EquipWeapon(MeleeWeapon equippedWeapon) => currentWeapon = equippedWeapon;

        private void Attack()
        {
            if (animator != null) animator.SetTrigger(Attack1);
            attackRange = currentWeapon.range;
            attackDamage = currentWeapon.damage;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentWeapon.attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (!enemy.isActiveAndEnabled) return;
                Enemy.Enemy _enemy = enemy.GetComponent<Enemy.Enemy>();
                #if UNITY_EDITOR
                if (debug || GameManager.instance.debug) DebugSW.Log($"\tEnemy:orange; {enemy.name}:cyan; Got:lightPurple; Hit:lightRed;", this);
                #endif
                _enemy.Damage(attackDamage);
            }
        }

        #region Custom MonoBehaviour Methods

        protected override void OnAwake() => OnPlayerAwake();

        protected override void OnStart()
        {
            OnPlayerStart();
            EquipWeapon(testEquipWeapon);
        }

        protected override void OnUpdate() => OnPlayerUpdate();

        protected virtual void OnPlayerAwake() => base.OnAwake();

        protected virtual void OnPlayerStart() => base.OnStart();

        protected virtual void OnPlayerUpdate()
        {
            base.OnUpdate();
            if (Input.GetKeyDown(KeyCode.Mouse0)) Attack();
        }

        #endregion
    }
}