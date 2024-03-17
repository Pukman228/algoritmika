using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public Transform borderRight;
    public Transform borderLeft;

    public float spawnInterval;
    public float spawnTimer;

    void Spawn()
    {

        float randomX = Random.Range(borderLeft.position.x, borderRight.position.x);

        Vector2 newPosition = transform.position;
        newPosition.x = randomX;

        Instantiate(prefab, newPosition, Quaternion.identity);
        spawnTimer = spawnInterval;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            Spawn();
        }

    }
}
