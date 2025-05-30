using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackScaler : IPowerScaler
{
    protected float actualValue;
    public float ActualValue => actualValue;

    protected readonly float baseValue;
    protected AttackScaler(float baseValue) => this.baseValue = baseValue;

    public void OnReceivedPower(float raw)
    {
        actualValue = Mathf.RoundToInt(raw * baseValue);
        ApplyDamage(actualValue);
    }

    protected abstract void ApplyDamage(float computed);
}

