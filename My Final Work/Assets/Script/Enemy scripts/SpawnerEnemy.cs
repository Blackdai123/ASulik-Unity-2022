using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] float timeToSpawn;
    public List<GameObject> enemyList = new List<GameObject> ();


    float time;
    List<GameObject> instanceList = new List<GameObject> ();
    int instanceCount = 0;

    void Start()
    {
        time = timeToSpawn;
    }

    void Update()
    {
        time -= Time.deltaTime;

        if (time<= 0)
        {
            InsEnemy();
            time = timeToSpawn;
        }
    }

    void InsEnemy()
    {
        instanceList.Add(Instantiate(enemyList[Random.Range(0, enemyList.Count)], transform.position, transform.rotation));
        AddObjectsToMenegerEnemy();
    }

    void AddObjectsToMenegerEnemy()
    {
        instanceCount = instanceList.Count - 1;
        ListEnemyManager.Instance.AddToListCreatedEnemy(instanceList[instanceCount]);
    }
}
