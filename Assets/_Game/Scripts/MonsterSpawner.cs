using System;
using System.Collections;
using System.Collections.Generic;
using _Game.Scripts;
using _Game.Scripts.Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private Monster[] _spawnableMonsterPrefabs;

    [Min(0), SerializeField] private float _spawnRadiusFromSpawnPoint = 10f;
    [SerializeField] private Transform _centerSpawnCircle;

    [Min(0), SerializeField] private float _spawnCoolDown = 2f;
    [SerializeField] private Transform _spawnParent;

    private List<Monster> _spawnedMonsters = new();

    private void Start()
    {
        GameManager.Hero.HealthComponent.OnDeadEvent += OnHeroDead;
        StartCoroutine(SpawnMonster());
    }

    private void OnHeroDead()
    {
        foreach (var spawnedMonster in _spawnedMonsters)
        {
            Destroy(spawnedMonster.gameObject);
        }

        enabled = false;
    }

    private Vector3 CalculateRandomSpawnPoint()
    {
        float randAng = Random.Range(0, Mathf.PI * 2);
        var spawnPoint = new Vector3(
            Mathf.Cos(randAng) * _spawnRadiusFromSpawnPoint,
            Mathf.Sin(randAng) * _spawnRadiusFromSpawnPoint);

        return spawnPoint;
    }

    private IEnumerator SpawnMonster()
    {
        while (true)
        {
            var spawnPoint = CalculateRandomSpawnPoint();

            var spawnedMonster = Instantiate(
                _spawnableMonsterPrefabs[Random.Range(0, _spawnableMonsterPrefabs.Length)], 
                spawnPoint,
                Quaternion.identity, 
                _spawnParent);

            _spawnedMonsters.Add(spawnedMonster);

            yield return new WaitForSeconds(_spawnCoolDown);
        }
    }

    private void OnDisable()
    {
        GameManager.Hero.HealthComponent.OnDeadEvent -= OnHeroDead;
        StopAllCoroutines();
    }


    private void OnDrawGizmosSelected()
    {
        if (_centerSpawnCircle == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_centerSpawnCircle.position, _spawnRadiusFromSpawnPoint);
    }
}