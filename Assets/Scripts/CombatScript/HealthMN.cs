using System;
using UnityEngine;

public class HealthMN : MonoBehaviour
{
    [SerializeField] private CharacterStats statsSO;

    public float MaxHealth { get; private set; }
    public float CurrentHealth { get; private set; }
    public float BaseEndurance { get; private set; }
    public float CurrentEndurance { get; private set; }

    public event Action<float, float> OnHealthUpdated;
    public event Action<HealthMN> OnDeath;

    private float _shield = 0;

    private void Awake()
    {
        MaxHealth = statsSO.MaxHealth;
        BaseEndurance = statsSO.Endurance;

        CurrentHealth = MaxHealth;
        CurrentEndurance = BaseEndurance;
    }

    private void Start()
    {
        OnHealthUpdated?.Invoke(CurrentHealth, MaxHealth);
    }
    public void BlockDamage(float shield)
    {
        _shield = shield;
    }

    public void ApplyDamage(float damage)
    {
        float _dmgRemaining = damage;

        if (_shield > 0f)
        {
            if (_shield >= _dmgRemaining)
            {
                _shield -= _dmgRemaining;
                _dmgRemaining = 0f;
            }
            else
            {
                _dmgRemaining -= _shield;
                _shield = 0f;
            }
        }
        
        if (_dmgRemaining > 0f)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - _dmgRemaining, 0f, MaxHealth);
            _shield = 0f;
            OnHealthUpdated?.Invoke(CurrentHealth, MaxHealth);

            
        }
        if (CurrentHealth <= 0f)
        {
            OnDeath?.Invoke(this);
        }
    }
}
