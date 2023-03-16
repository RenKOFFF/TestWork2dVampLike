using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnComponent : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnableObjectPrefabs;

    [Min(0), SerializeField] private float _spawnRadiusFromSpawnPoint = 10f;
    [SerializeField] private Transform _centerSpawnCircle;

    [Min(0), SerializeField] private float _spawnCoolDown = 2f;
    [SerializeField] private Transform _spawnParent;

    private void Start()
    {
        StartCoroutine(SpawnObject());
    }

    private Vector3 CalculateRandomSpawnPoint()
    {
        float randAng = Random.Range(0, Mathf.PI * 2);
        var spawnPoint = new Vector3(
            Mathf.Cos(randAng) * _spawnRadiusFromSpawnPoint,
            Mathf.Sin(randAng) * _spawnRadiusFromSpawnPoint);

        return spawnPoint;
    }

    private IEnumerator SpawnObject()
    {
        while (true)
        {
            var spawnPoint = CalculateRandomSpawnPoint();
            Instantiate(_spawnableObjectPrefabs[Random.Range(0, _spawnableObjectPrefabs.Length)], spawnPoint, Quaternion.identity, _spawnParent);
            yield return new WaitForSeconds(_spawnCoolDown);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_centerSpawnCircle == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_centerSpawnCircle.position, _spawnRadiusFromSpawnPoint);
    }
}