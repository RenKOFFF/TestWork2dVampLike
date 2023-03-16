using System;
using System.Collections;
using _Game.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : MonoBehaviour, IDamageable
{
    [SerializeField] private HeroData _heroData;

    private HeroHealthComponent _healthComponent;
    
    public HeroHealthComponent HealthComponent => _healthComponent; 
    public HeroData HeroData => _heroData;

    public event Action OnTakeDamageEvent;

    private void Start()
    {
        _healthComponent = GetComponent<HeroHealthComponent>();
        _healthComponent.OnDeadEvent += Dead;
    }

    private void OnDisable()
    {
        HealthComponent.OnDeadEvent -= Dead;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var monster = col.GetComponent<Monster>();

        if (monster)
        {
            Debug.Log($"{name}: Enter monster - {col.name}");
            StartCoroutine(Attack(monster, monster.MonsterData.Stats.Damage));
        }
    }

    private IEnumerator Attack(Monster monster, float damageValue)
    {
        while (true)
        {
            if (!monster)
                yield break;
            
            Debug.Log("HeroStartAttack");
            monster.TakeDamage(damageValue);
            yield return new WaitForSeconds(_heroData.Stats.DamageSpeed);
        }
    }

    public void TakeDamage(float damageValue)
    {
        Debug.Log($"{name} taked pizdi");
        HealthComponent.DecreaseHealth(damageValue);
        OnTakeDamageEvent?.Invoke();
    }

    private void Dead()
    {
        Debug.Log("PomerHero");

        Destroy(gameObject);
    }
}