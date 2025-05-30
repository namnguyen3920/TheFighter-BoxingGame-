using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerAttackScaler : AttackScaler
{
    PlayerController p_controller;
    float actualDamage;
    public PlayerAttackScaler (PlayerController p_controller, float baseDamage) : base (baseDamage)
    {
        this.p_controller = p_controller;
    }

    protected override void ApplyDamage(float damage)
    {
        actualDamage = damage;
    }

    public float ActualDamage => actualDamage;
}
