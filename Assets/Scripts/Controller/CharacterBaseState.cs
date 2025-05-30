using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBaseState
{
    public abstract void EnterState(CharController character);
    public abstract void UpdateState(CharController character);
    public abstract void ExitState(CharController character);
}
