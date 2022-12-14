using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : SingletonEnemy<BuffManager>
{
    [SerializeField] List<GameObject> buffList = new List<GameObject>();
    [SerializeField] float timeToIssueBuff;

    float timerTime;
    public bool readiness;

    void Start()
    {
        timerTime = timeToIssueBuff;
    }

    void Update()
    {
        timerTime -= Time.deltaTime;

        if (timerTime <= 0)
        {
            readiness = true;
        }
    }

    public void InstanceBuff(Transform enemy)
    {
        Instantiate(buffList[Random.Range(0, buffList.Count)], enemy.transform.position, enemy.transform.rotation);
        readiness = false;
        timerTime = timeToIssueBuff;
    }

}
