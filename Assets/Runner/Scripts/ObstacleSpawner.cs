using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class ObstacleSpawner : ITickable
{
    private List<Transform> obstacles;
    private Transform spawner;
    readonly Settings settings;
    private float timer = 0;
    private float spawnInterval;
    bool enabled;

    [Inject]
    public ObstacleSpawner( Settings settings )
    {
        enabled = true;
        this.settings = settings;
        obstacles = new List<Transform>();
        spawner = new GameObject("Spawner").transform;
        spawner.position = settings.spawnPoint;
        RandomizeNewTimeInterval();
    }

    public void Tick()
    {
        if (enabled)
        {
            timer += Time.deltaTime;
            if (timer > spawnInterval)
            {
                Spawn();
                RandomizeNewTimeInterval();
            }
        }
    }

    private void Spawn()
    {
        Transform obstacle = GameObject.Instantiate(RandomizePrefab(), spawner).transform;
        obstacle.GetComponent<Rigidbody2D>().velocity = Vector2.left * settings.obstacleSpeed;
        obstacles.Add(obstacle);
    }

    private GameObject RandomizePrefab()
    {
        return settings.obstaclePrefab[Random.Range(0, settings.obstaclePrefab.Length)];
    }

    private void RandomizeNewTimeInterval()
    {
        timer = 0;
        spawnInterval = Random.Range(settings.minSpawnCooldown, settings.maxSpawnCooldown);
    }

    public void Start()
    {
        foreach (var obstacle in obstacles)
        {
            GameObject.Destroy(obstacle.gameObject);
        }
        obstacles.Clear();
        enabled = true;
    }

    public void ResetAll()
    {
        enabled = false;
    }

    [Serializable]
    public class Settings
    {
        public float minSpawnCooldown;
        public float maxSpawnCooldown;
        public float obstacleSpeed;
        public Vector2 spawnPoint;
        public GameObject[] obstaclePrefab;
    }
}
