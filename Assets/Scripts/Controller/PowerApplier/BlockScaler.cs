using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BlockScaler : IPowerScaler
{
    protected float actualValue;
    public float ActualValue => actualValue;

    protected readonly float baseValue;
    protected BlockScaler(float baseValue) => this.baseValue = baseValue;

    public void OnReceivedPower(float raw)
    {
        Debug.Log($"Raw: {raw}");
        Debug.Log($"baseValue: {baseValue}");
        actualValue = Mathf.RoundToInt(raw) * baseValue;
        Debug.Log($"Actual Value: {actualValue}");
        ApplyValues(actualValue);
    }

    protected abstract void ApplyValues(float computed);
}

