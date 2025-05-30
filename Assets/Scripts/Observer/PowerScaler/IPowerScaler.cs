using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerScaler
{
    void OnReceivedPower(float value);

    float ActualValue { get; }
}
