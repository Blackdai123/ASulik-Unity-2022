using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListEnemyManager : SingletonEnemy<ListEnemyManager>
{
    public List<GameObject> createdEnemy;
    
    public void  AddToListCreatedEnemy(GameObject enemy)
    {
        createdEnemy.Add(enemy);
    }

    public List<GameObject> GetAllCreatedEnemy()
    {
        return createdEnemy;
    }
}
