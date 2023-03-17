using System;
using System.Collections;
using _Game.Scripts;
using _Game.Scripts.Components;
using _Game.Scripts.Interfaces;
using UnityEngine;

public class Hero : MonoBehaviour, IDamageable, ICreature
{
    [SerializeField] private Stats _stats;
    public Stats Stats => _stats;
    public HealthComponent<Hero> HealthComponent { get; private set; }

    public event Action<IDamageable> OnTakeDamageEvent;

    private void Awake()
    {
        HealthComponent = GetComponent<HealthComponent<Hero>>();
    }

    private void Start()
    {
        HealthComponent.OnDeadEvent += Dead;
    }

    private void OnDestroy()
    {
        HealthComponent.OnDeadEvent -= Dead;
        StopAllCoroutines();
    }

    public void TakeDamage(IDamageable sender, float damageValue)
    {
        HealthComponent.DecreaseHealth(damageValue);
        OnTakeDamageEvent?.Invoke(sender);
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
}