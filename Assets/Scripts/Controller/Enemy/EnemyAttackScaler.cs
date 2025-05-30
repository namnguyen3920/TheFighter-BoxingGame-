using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyAttackScaler : AttackScaler
{
    EnemyController e_controller;
    float actualDamage;
    public EnemyAttackScaler (EnemyController e_controller, float baseDamage) : base (baseDamage)
    {
        this.e_controller = e_controller;
    }

    protected override void ApplyDamage(float damage)
    {
        actualDamage = damage;
    }

    public float ActualDamage => actualDamage;
}
