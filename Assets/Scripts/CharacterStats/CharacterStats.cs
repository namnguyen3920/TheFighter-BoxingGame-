using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Character/Character Data")]
public class CharacterStats : ScriptableObject
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private int _maxHealth = 200;
    [SerializeField] private float _endurance = 10f;

    public float Damage => _damage;
    public int MaxHealth => _maxHealth;
    public float Endurance => _endurance;
}
