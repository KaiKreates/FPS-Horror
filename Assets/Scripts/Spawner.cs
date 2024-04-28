using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    public List<Vector3> spacePoints = new List<Vector3>();

    public GameObject gemPrefab;
    public GameObject enemyPrefab;
    void Start() 
    {
        SpawnBlocks();
    }

    void Update()
    {
        
    }

    void SpawnBlocks()
    {
        for (int i = -45; i <= 45; i = i + 10)
        {
            for (int j = -45; j <= 45; j = j + 10)
            {
                int random = Random.Range(0, 3);
                if (random != 2)
                {
                    GameObject randomBlock = blockPrefabs[Random.Range(0, blockPrefabs.Length)];
                    Instantiate(randomBlock, new Vector3(i, 4.5f, j), Quaternion.Euler(new Vector3(0, Random.Range(-45, 45), 0)), transform);
                }
                else
                {
                    spacePoints.Add(new Vector3(i, 0, j));
                }
            }
        }
    }

    public void SpawnEnemy()
    {

    }

    void SpawnGems()
    {

    }
}

