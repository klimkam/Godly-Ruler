using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _currentHealth;
    private float _maxHealth;
    public float MaxHealth { get => _maxHealth; private set => _maxHealth = value; }
    public float CurrentHealth { get => _currentHealth;  set => _currentHealth = value; }
    public event Action<Health> OnDie;
    public event Action OnChangeHealth;
    private void Awake()
    {
        _maxHealth = _currentHealth;
    }
    public void DecreaseHealth(float damage)
    {
        if (damage <= 0)
        {
            throw new InvalidOperationException();
        }
        _currentHealth -= damage;
        OnChangeHealth?.Invoke();
        if (_currentHealth <= 0)
        {
            OnDie?.Invoke(this);
        }
    }
    public void IncreaseHealth(float additionalHealth)
    {
        if(additionalHealth <= 0)
        {
            throw new InvalidOperationException();
        }
        if (_currentHealth + additionalHealth <= _maxHealth)
        {
            _currentHealth += additionalHealth;
        }
        OnChangeHealth?.Invoke();
        }
    }
