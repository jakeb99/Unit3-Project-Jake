using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This is the attack ability AI use
/// </summary>
public class AttackAbility : MonoBehaviour
{
    [SerializeField] private float damageAmount;
    [SerializeField] private float attackCooldown;

    private bool isAttacking;
    private float timer = 0;
    private HealthSystem attackTargetHealthSys;

    private void Update()
    {
        if (isAttacking)
        {
            // start attack timer
            timer += Time.deltaTime;

            if (timer >= attackCooldown)
            {
                Attack();
                timer = 0;
            }
            
        }
    }

    public void StartAttack(Transform target)
    {
        attackTargetHealthSys = target.GetComponent<HealthSystem>();

        isAttacking = true;

        Debug.Log("Starting attack!");
    }

    public void Attack()
    {
        if (attackTargetHealthSys)
        {
            attackTargetHealthSys.DecreaseHealth(damageAmount);
        }
    }

    public void StopAttack()
    {
        isAttacking = false;
    }
}
