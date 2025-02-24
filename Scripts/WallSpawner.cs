using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1f;
    [SerializeField] private float heightRange = 1f;
    public GameObject wallPrefab;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        //cek jika timer melebihi waktu maksimum, spawn dinding baru
       if(timer > maxTime)
        {
            SpawnWall();
            timer = 0;
        } 
        timer += Time.deltaTime;
    }
    

    private void SpawnWall()
    {
        //menentukan posisi spawn dengan variasi tinggi secara acak
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject wall = Instantiate(wallPrefab, spawnPos, Quaternion.identity); //membuat objek dinding di posisi spawn
        Destroy(wall, 5f);//hancurkan setalah 5detik
    }
}
