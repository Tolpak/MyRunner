using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    private List<Rigidbody2D> obstacles;
    private Transform spawner;
    private float timer = 0;
    private float spawnInterval;
    private bool enabled;
    private SpawnerSettings settings;

    public Spawner( SpawnerSettings settings )
    {
        this.settings = settings;
        enabled = true;
        obstacles = new List<Rigidbody2D>();
        spawner = new GameObject("Spawner").transform;
        spawner.position = settings.spawnPoint;
        RandomizeNewTimeInterval();
    }

    public void Update()
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
        var obstacle = GameObject.Instantiate(RandomizePrefab(), spawner).GetComponent<Rigidbody2D>();
        obstacle.velocity = Vector2.left * settings.speed;
        obstacles.Add(obstacle);
    }

    private void RandomizeNewTimeInterval()
    {
        timer = 0;
        spawnInterval = Random.Range(settings.minSpawnCooldown, settings.maxSpawnCooldown);
    }

    private GameObject RandomizePrefab()
    {
        return settings.prefabs[Random.Range(0, settings.prefabs.Length)];
    }

    public void Disable()
    {
        enabled = false;
        foreach (var obstacle in obstacles)
        {
            if (obstacle != null)
                obstacle.velocity = Vector2.zero;
        }
    }

    public void Start()
    {
        foreach (var obstacle in obstacles)
        {
            if (obstacle != null)
            {
                GameObject.Destroy(obstacle.gameObject);
            }
        }
        obstacles.Clear();
        enabled = true;
    }

    public class SpawnerSettings
    {
        public float minSpawnCooldown;
        public float maxSpawnCooldown;
        public float speed;
        public Vector2 spawnPoint;
        public GameObject[] prefabs;
    }
}
