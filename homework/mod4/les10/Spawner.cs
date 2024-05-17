using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer;
    public float interval = 1f;
    public Enemy enemyPrefab;
    public Transform topBorder;
    public Transform bottomBorder;
    public float spawnIntervalMax = 3.5f;
    public float spawnIntervalMin = 1f;
    public int spawnCounter = 10;
    public int spawnAddPerLevel = 5;

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter += spawnAddPerLevel * LevelController.level;
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelController.finished == false)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else if (spawnCounter > 0)
            {
                Spawn();
                timer = Random.Range(spawnIntervalMin, spawnIntervalMax);
            }
        }
    }

    public void Spawn()
    {
        Vector2 randomPos = new Vector2(transform.position.x, Random.Range(topBorder.position.y, bottomBorder.position.y));
        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
        spawnCounter--;
    }
}
