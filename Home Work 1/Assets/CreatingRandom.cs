using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatingRandom : MonoBehaviour
{
    public List<GameObject> prefabMas = new List<GameObject>(3);

    private GameObject instance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (instance != null)
            {
                Destroy(instance);
            }
            var rotation = Quaternion.identity;
            var position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(1.0f, 5.0f), Random.Range(-5.0f, 5.0f));


            instance = Instantiate(prefabMas[Random.Range(0, prefabMas.Count)], position, rotation);
        }
    }
}
