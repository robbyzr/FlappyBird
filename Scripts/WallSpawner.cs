using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1f;
    [SerializeField] private float heightRange = 1f;
    public GameObject wallPrefab;
    private float timer;

    public List<GameObject> spawnedWalls = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer> maxTime)
        {
            SpawnWall();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void SpawnWall()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject wall = Instantiate (wallPrefab, spawnPos, Quaternion.identity);
        spawnedWalls.Add(wall);
        
        Destroy(wall,5);
    }

    public void DestroyWall()
    {
        foreach (GameObject wall in spawnedWalls)
        {
            if(wall != null)
            {
                Destroy(wall);
            }
        }
        spawnedWalls.Clear();
    }
}
