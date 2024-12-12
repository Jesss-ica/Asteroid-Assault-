using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AstroidSpawner : MonoBehaviour
{
    public GameObject AstroidPrefab;
    public GameObject StarPrefab;
    public GameObject HealthPrefab;

    public float timeRemaining = 3.5f;
    public bool timerIsRunning = false;

    public GameObject SpawnArea;
    public GameManager gameManager;
    Quaternion spawnB;

    Bounds bounds;

    void Start()
    {
        bounds = SpawnArea.GetComponent<BoxCollider2D>().bounds;
        timerIsRunning = true;
        gameManager = FindObjectOfType<GameManager>();
        SpawnAstroid(AstroidPrefab, 3f);
    }

    private Vector2 GetRandomLocation()
    {
        return new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));
    }

    private void SpawnAstroid(GameObject Prefab,float timeUntillNext)
    {
        Instantiate(Prefab, GetRandomLocation(), spawnB);
        timeRemaining = timeUntillNext;
    }

    private void SpawnNextAstroid(GameObject Prefab)
    {
        var score = gameManager.GetScore();

        if (score <= 500)
        {
            SpawnAstroid(Prefab, 3f);
        }
        else if (score <= 1000)
        {
            SpawnAstroid(Prefab, 2.5f);

        }
        else if (score <= 1500)
        {
            SpawnAstroid(Prefab, 2f);

        }
        else if (score <= 2000)
        {
            SpawnAstroid(Prefab, 1.5f);
        }
        else if (score <= 3000)
        {
            SpawnAstroid(Prefab, 1f);
        } else
        {
            SpawnAstroid(Prefab, 0.7f);
        }
    }

    private void SelectRandomAstroidType()
    {
        float rndmNum = Random.value;

        Debug.Log(rndmNum);

        if (rndmNum <= 0.1f)
        {
            SpawnNextAstroid(StarPrefab);
        }
        else if (rndmNum <= 0.2f)
        {
            SpawnNextAstroid(HealthPrefab);
        }
        else
        {
            SpawnNextAstroid(AstroidPrefab);
        }
    }

    void Update()
    {

        if (timerIsRunning == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                SelectRandomAstroidType();
            }
        }


    }
}
