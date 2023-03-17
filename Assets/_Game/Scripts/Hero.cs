using System;
using System.Collections;
using _Game.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class Hero : MonoBehaviour, IDamageable, ICreature
{
    [SerializeField] private Stats _stats;
    [SerializeField] private CircleCollider2D _attackCollider;
    [SerializeField] private float _attackRange;

    private HeroHealthComponent _healthComponent;

    public Stats Stats => _stats;
    public HeroHealthComponent HealthComponent => _healthComponent;

    public event Action OnTakeDamageEvent;

    private void Start()
    {
        _healthComponent = GetComponent<HeroHealthComponent>();
        _healthComponent.OnDeadEvent += Dead;

        _attackCollider.radius = _attackRange;
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
            StartCoroutine(Attack(monster, monster.Stats.Damage));
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
            yield return new WaitForSeconds(Stats.DamageSpeed);
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