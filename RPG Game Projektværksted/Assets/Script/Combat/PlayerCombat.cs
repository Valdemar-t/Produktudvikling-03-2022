using UnityEngine;
// ReSharper disable Unity.PreferNonAllocApi

namespace Combat
{
    public class PlayerCombat : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private LayerMask enemyLayers;
        [SerializeField] private MeleeWeapon testEquipWeapon;
        private static readonly int Attack1 = Animator.StringToHash("Attack");
        public MeleeWeapon currentWeapon;
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
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                Enemy _enemy = enemy.GetComponent<Enemy>();
                Debug.Log($"Hit enemy: {enemy.name}", this);
                _enemy.Damage(attackDamage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (attackPoint != null) Gizmos.DrawWireSphere(attackPoint.position, testEquipWeapon.range);
        }
    }
}