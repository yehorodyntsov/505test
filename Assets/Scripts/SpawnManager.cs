using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemiesNumber;
   public GameObject Archer;
    public GameObject Cube;
    public GameObject Capsule;
    private static float xSpawnRange = 10f;
    private static float zSpawnRange = 10f;
    private static float ySpawnPosition = 3f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemiesNumber; i++)
        {
            createRandomEnemy();
        }
    }

    public void createRandomEnemy()
    {
        int randomEnemy = Random.Range(0, 3);
        GameObject prefab = null;
        if (randomEnemy == 0)
        {
            prefab = Archer;
        }
        else if (randomEnemy == 1)
        {
            prefab = Cube;
        }
        else if (randomEnemy == 2)
        {
            prefab = Capsule;
        }
        var position = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), ySpawnPosition, Random.Range(-zSpawnRange, zSpawnRange));
        Instantiate(prefab, position, Quaternion.identity);
    }


}
