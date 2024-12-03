using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private Transform obstacleParent;
    public float obstacleSpawnTime = 2f;
    [Range(0f, 1f)] public float obstacleSpawnTimeFactor = 0.1f;
    public float obstacleSpeed = 1f;
    [Range(0f, 1f)] public float obstacleSpeedFactor = 0.2f;

    private float _obstacleSpawnTime;
    public float _obstacleSpeed;

    private float timeUntilObstacleSpawn;

    private float timeAlive;

    private void Start()
    {
        GameManager.instance.onGameOver.AddListener(ClearObstacles);
        timeAlive = 1f;
        GameManager.instance.onPlay.AddListener(ResetFactors);
    }

    private void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            timeAlive += Time.deltaTime;

            CalculateFactors();


            SpawnLoop();
        }
    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= _obstacleSpawnTime)
        {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void ClearObstacles()
    {
        foreach(Transform child in obstacleParent)
        {
            Destroy(child.gameObject);
        }
    }

    private void CalculateFactors()
    {
        _obstacleSpawnTime = obstacleSpawnTime / Mathf.Pow(timeAlive, obstacleSpawnTimeFactor);
        _obstacleSpeed = obstacleSpeed * Mathf.Pow(timeAlive, obstacleSpeedFactor);
    }

    private void ResetFactors()
    {
        timeAlive = 1f;
        _obstacleSpawnTime = obstacleSpawnTime;
        _obstacleSpeed = obstacleSpeed;

    }

    private void Spawn()
    {
        GameObject obstacleToSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        spawnedObstacle.transform.parent = obstacleParent;

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * _obstacleSpeed;
    }
}
