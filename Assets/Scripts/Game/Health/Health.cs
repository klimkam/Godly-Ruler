using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public abstract class Health : MonoBehaviour
{
    private Target _target;
    [SerializeField] private float _currentHealth;
    private float _maxHealth;
    public float MaxHealth { get => _maxHealth; private set => _maxHealth = value; }
    public float CurrentHealth { get => _currentHealth;  set => _currentHealth = value; }
    public event Action<Target> OnDie;
    public event Action OnChangeHealth;
    private void Awake()
    {
        _target = GetComponentInParent<Target>();
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
         List<TargetCreator> targetCreators = FindObjectsOfType<TargetCreator>().ToList();
         targetCreators.Where(e =>e.ListOfCreatedPrefabs.Contains(_target)).FirstOrDefault().Remove(_target);
          Destroy(gameObject);
        }
    }
    public void IncreaseHealth(float additionalHealth)
    {
        if(additionalHealth <= 0)
        {
            throw new InvalidOperationException();
        }
        _currentHealth = _currentHealth + additionalHealth <= _maxHealth ? _currentHealth + additionalHealth : _maxHealth;
        OnChangeHealth?.Invoke();
        }
    }
