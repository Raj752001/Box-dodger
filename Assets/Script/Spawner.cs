using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBoxPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    public Vector2 spawnSizeMinMax;
    public float spawnAngleMax;
    float nextSpawnTime=0;
    Vector2 screenHalfSize;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y + spawnSize);
            GameObject fallingBox = Instantiate(fallingBoxPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            fallingBox.transform.parent = transform;
            fallingBox.transform.localScale = Vector2.one * spawnSize;
        } 
    }
}
