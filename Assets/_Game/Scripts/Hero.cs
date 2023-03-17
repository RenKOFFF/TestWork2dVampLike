using System;
using System.Collections;
using _Game.Scripts;
using UnityEngine;

public class Hero : MonoBehaviour, IDamageable, ICreature
{
    [SerializeField] private Stats _stats;
    [SerializeField] private CircleCollider2D _attackCollider;
    [SerializeField] private float _attackRange;
    
    public Stats Stats => _stats;
    public HealthComponent<Hero> HealthComponent { get; private set; }

    public event Action OnTakeDamageEvent;

    private void Start()
    {
        HealthComponent = GetComponent<HealthComponent<Hero>>();
        HealthComponent.OnDeadEvent += Dead;

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
            StartCoroutine(Attack(monster, monster.Stats.Damage));
        }
    }

    private IEnumerator Attack(Monster monster, float damageValue)
    {
        while (true)
        {
            if (!monster)
                yield break;
            
            monster.TakeDamage(damageValue);
            yield return new WaitForSeconds(Stats.DamageSpeed);
        }
    }

    public void TakeDamage(float damageValue)
    {
        HealthComponent.DecreaseHealth(damageValue);
        OnTakeDamageEvent?.Invoke();
    }

    private void Dead()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}