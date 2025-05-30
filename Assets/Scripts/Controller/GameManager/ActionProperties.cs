using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ActionProperties
{
    public CharController Character;
    public CharacterAction CharacterAction;
    public float ScaledValue;
    public CharController Opponent;

    public ActionProperties(CharController character, CharacterAction characterAction, float scaledValue, CharController opponent = null)
    {
        Character = character;
        CharacterAction = characterAction;
        ScaledValue = scaledValue;
        Opponent = opponent;
    }
}
