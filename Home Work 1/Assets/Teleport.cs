using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject prefab;
    public int cicycleTime = 0;

    void Update()
    {
        var t = Task.Run(async delegate
        {
            await Task.Delay(cicycleTime);
            
        });
        t.Wait();
        prefab.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(1.0f, 5.0f), Random.Range(-5.0f, 5.0f));

    }
}
