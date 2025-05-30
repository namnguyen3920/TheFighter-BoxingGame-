using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerBlockScaler : BlockScaler
{
    PlayerController p_controller;
    float actualEndur;
    public PlayerBlockScaler(PlayerController p_controller, float baseEndurance) : base (baseEndurance)
    {
        this.p_controller = p_controller;
    }

    protected override void ApplyValues(float endur)
    {
        actualEndur = endur;
    }

    public float ActualEndur => actualEndur;
}
