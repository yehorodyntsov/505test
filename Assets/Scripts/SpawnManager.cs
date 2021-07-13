using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemiesNumber;
    //List<GameObject> numbers = new List<GameObject>() { Archer, Cube, Capsule };

   public GameObject Archer;
    public GameObject Cube;
    public GameObject Capsule;
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
        var position = new Vector3(Random.Range(-10.0f, 10.0f), 3, Random.Range(-10.0f, 10.0f));
        Instantiate(prefab, position, Quaternion.identity);
    }


}
