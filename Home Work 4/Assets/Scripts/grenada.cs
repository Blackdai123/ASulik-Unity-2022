using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenada : MonoBehaviour
{
    [SerializeField] float delayOfExplosion = 3f;
    public GameObject explosionEffect;
    public float radiusExplosion = 5f;
    public float force = 700f;


    private float countdown;
    private bool hasExploded = false;
    void Start()
    {
        countdown = delayOfExplosion;    
    }

    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    private void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radiusExplosion);
        foreach(Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radiusExplosion);
            }
        }

        Destroy(gameObject);
    }
}
