using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IssueBuff : MonoBehaviour
{
    [SerializeField] List<GameObject> buffList = new List<GameObject>();
    [SerializeField]float timeToIssueBuff;

    float timerTime;
    public bool readiness;

    private void Start()
    {
        timerTime = timeToIssueBuff;
    }

    void Update()
    {
        timerTime -= Time.deltaTime;

        if (timerTime<=0)
        {   
            readiness = true;
        }
    }

    public void InstanceBuff()
    {
        Instantiate(buffList[Random.Range(0, buffList.Count)]);
        readiness = false;
        timerTime = timeToIssueBuff;
    }
}
