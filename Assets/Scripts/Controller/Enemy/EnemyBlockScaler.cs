using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlockScaler : BlockScaler
{
    EnemyController e_controller;
    float actualEndur;
    public EnemyBlockScaler(EnemyController e_controller, float baseEndurance) : base (baseEndurance)
    {
        this.e_controller = e_controller;
    }

    protected override void ApplyValues(float endur)
    {
        actualEndur = endur;
    }

    public float ActualEndur => actualEndur;
}
