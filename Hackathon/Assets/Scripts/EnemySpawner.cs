using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public GameObject[] creeps; 
        public int[] creepCounts; 
        public float spawnInterval = 1f; 
    }

    [SerializeField] private Wave[] waves; 
    [SerializeField] private Transform spawnPoint; 
    [SerializeField] private Transform firstTrackPoint; 
    [SerializeField] private float intervalBetweenWaves = 5f;

    private int currentWaveIndex = 0;


    private void OnEnable()
    {
        EventBus.OnEndMergeTutuor += StartSpawn;
    }

    private void OnDisable()
    {
        EventBus.OnEndMergeTutuor -= StartSpawn;        
    }
    //private void Start()
    //{
    //    StartCoroutine(SpawnWaves());        
    //}

    private void StartSpawn()
    { 
        StartCoroutine(SpawnWaves());        
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < waves.Length)
        {
            yield return StartCoroutine(SpawnWave(waves[currentWaveIndex]));
            currentWaveIndex++;
            yield return new WaitForSeconds(intervalBetweenWaves);
        }
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        for (int i = 0; i < wave.creeps.Length; i++)
        {
            for (int j = 0; j < wave.creepCounts[i]; j++)
            {
                SpawnCreep(wave.creeps[i]);
                yield return new WaitForSeconds(wave.spawnInterval);
            }
        }
    }

    private void SpawnCreep(GameObject creepPrefab)
    {
        GameObject creep = Instantiate(creepPrefab, spawnPoint.position, Quaternion.identity);
        CreepMovement creepMovement = creep.GetComponent<CreepMovement>();

        if (creepMovement != null && firstTrackPoint != null)
        {
            creepMovement.SetNewPoint(firstTrackPoint);
        }
    }
}

