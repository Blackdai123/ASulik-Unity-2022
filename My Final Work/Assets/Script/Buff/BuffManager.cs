using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : SingletonEnemy<BuffManager>
{
    [SerializeField] List<GameObject> botleBuffList = new List<GameObject>();
    [SerializeField] float timeToIssueBotleBuff;
    [SerializeField] List<GameObject> buffList = new List<GameObject>();
    [SerializeField] float timeToIssueBuff;


    float timerTimeForBotle;
    float timerTimeForBuff;
    public bool readinessBotleBuff;
    public bool readinessBuff;

    void Start()
    {
        timerTimeForBotle = timeToIssueBotleBuff;
        timerTimeForBuff = timeToIssueBuff;
    }

    void Update()
    {
        timerTimeForBotle -= Time.deltaTime;

        if (timerTimeForBotle <= 0)
        {
            readinessBotleBuff = true;
        }

        timerTimeForBuff -= Time.deltaTime;

        if (timerTimeForBuff <= 0)
        {
            readinessBuff = true;
        }
    }

    public void InstanceBotleBuff(Transform enemy)
    {
        Instantiate(botleBuffList[Random.Range(0, botleBuffList.Count)], enemy.transform.position, enemy.transform.rotation);
        readinessBotleBuff = false;
        timerTimeForBotle = timeToIssueBotleBuff;
    }

    public void InstanceBuff(Transform enemy)
    {
        Instantiate(buffList[Random.Range(0, buffList.Count)], enemy.transform.position, enemy.transform.rotation);
        readinessBuff = false;
        timerTimeForBuff = timeToIssueBuff;
    }

}
