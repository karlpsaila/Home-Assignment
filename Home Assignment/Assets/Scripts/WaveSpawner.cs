using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public Waves_SO[] waves;
    private Waves_SO currentWave;
    [SerializeField] private Transform[] spawnpoints;
    private float timeBtwnSpawns;
    private int i = 0;
    private bool stopSpawning = false;

    private void Awake()
    {
        currentWave = waves[i];
        timeBtwnSpawns = currentWave.TimeBetweenSpawns;
    }

    private void Update()
    {
        // Check if the current scene is Level 1
            if (stopSpawning)
            {
                return;
            }

            if (Time.time >= timeBtwnSpawns)
            {
                StartCoroutine(SpawnWave()); // Start the coroutine
                IncWave();

                timeBtwnSpawns = Time.time + currentWave.TimeBetweenSpawns;
            }
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < currentWave.NumberToSpawn; i++)
        {
            int num = Random.Range(0, currentWave.EnemiesInWave.Length);
            int num2 = Random.Range(0, spawnpoints.Length);

            yield return new WaitForSeconds(2f); // Add a 2-second delay

            Instantiate(currentWave.EnemiesInWave[num], spawnpoints[num2].position, spawnpoints[num2].rotation);
        }
    }

    private void IncWave()
    {
        if (i + 1 < waves.Length)
        {
            i++;
            currentWave = waves[i];
        }
        else
        {
            stopSpawning = true;
        }
    }
}
