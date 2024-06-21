using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnerRight;
    [SerializeField] private GameObject spawnerLeft;
    [SerializeField] private GameObject barrelPrefab;
    [SerializeField] private float spawnRate;

    private float _spawnTimer;
    
    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        
        if (_spawnTimer >= spawnRate)
        {
            Instantiate(barrelPrefab, GetSpawnPosition(), Quaternion.identity);
            _spawnTimer = 0;
        }
    }
    
    private Vector3 GetSpawnPosition()
    {
        if (Random.Range(0, 2) == 0)  { return spawnerRight.transform.position; }
        else { return spawnerLeft.transform.position; }
    }
}
