using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float forceMultiplaer = 2;
    public GameObject spawnPrefabs;
    public GameObject spawnrsPosition;
    [SerializeField] float timeForDestroyProjectile = 10f;

    private GameObject[] others = new GameObject[49];
    private Vector3 spawnPos;
    private GameObject currentSpawn;
    private bool spawnReady = true;
    private int indexator = 0;
    private int destroyIndexator = 0;
    private float countdown;
    private bool hasExploded = false;

    private void Start()
    {
        countdown = timeForDestroyProjectile;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }

        if (Input.GetMouseButton(1))
        {
            SpawnNewObject();
        }

        
        if (destroyIndexator <= 49 && indexator > destroyIndexator)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0 && hasExploded)
            {
                Destroy(others[destroyIndexator]);
                hasExploded = true;
                destroyIndexator++;
            }
        }
        else
        {
            destroyIndexator = 0;
        }
    }

    void SpawnNewObject()
    {
        spawnPos = spawnrsPosition.transform.position;

        if (spawnReady)
        {
            currentSpawn = Instantiate(spawnPrefabs, spawnPos, Quaternion.identity);
            spawnReady = false;
            hasExploded = true;
            indexator++;
        }

        if (indexator >= 49)
        {   
            indexator = 0;
        }

        others[indexator] = currentSpawn;
    }

    void Shoot()
    {
        currentSpawn.GetComponent<Rigidbody>().velocity = transform.forward * forceMultiplaer;

        spawnReady = true;
    }

    private void OnTriggerEnter(Collider others)
    {
        ChangerProjectile projectile = others.GetComponent<ChangerProjectile>();
        if (projectile == null)
        {
            return;
        }
        spawnPrefabs = projectile.gameObject;
    }
}
