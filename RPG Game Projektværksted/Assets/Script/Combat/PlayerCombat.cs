using System.ComponentModel;
using Combat.CustomInspector.Attributes;
using UnityEngine;
// ReSharper disable Unity.PreferNonAllocApi
// ReSharper disable NotAccessedField.Local

namespace Combat
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField, Header("Toggles"), LeftToggle, Tooltip("This is a Debug switch")] private bool debug;
        [SerializeField, Header("Player"), Tooltip("This is players animator with Attack animation in it")] private Animator animator;
        [SerializeField, Header("Enemy"), Tooltip("This is the enemy layer masks")] private LayerMask enemyLayers;
        [SerializeField, Header("Weapon"), ConditionalHide("debug"), Tooltip("This is the weapon the player gets at the start of the game (For debugging)")] private MeleeWeapon testEquipWeapon;
        [SerializeField, Space, ConditionalHide("debug"), ReadOnly(true), Tooltip("This is the weapon the player currently have in the hand (Read Only)")] private MeleeWeapon currentWeapon;

        private static readonly int Attack1 = Animator.StringToHash("Attack");
        private float attackRange, attackDamage;

        private void Start() => EquipWeapon(testEquipWeapon);

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) Attack();
        }

        private void EquipWeapon(MeleeWeapon equippedWeapon) => currentWeapon = equippedWeapon;

        private void Attack()
        {
            if (animator != null) animator.SetTrigger(Attack1);
            attackRange = currentWeapon.range;
            attackDamage = currentWeapon.damage;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(currentWeapon.attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                Enemy _enemy = enemy.GetComponent<Enemy>();
                Debug.Log($"Hit enemy: {enemy.name}", this);
                _enemy.Damage(attackDamage);
            }
        }

        private void OnValidate() => currentWeapon = testEquipWeapon != null ? testEquipWeapon : null;

        private void OnDrawGizmosSelected()
        {
            if (currentWeapon != null && currentWeapon.attackPoint != null) Gizmos.DrawWireSphere(currentWeapon.attackPoint.position, testEquipWeapon.range);
        }
    }
}