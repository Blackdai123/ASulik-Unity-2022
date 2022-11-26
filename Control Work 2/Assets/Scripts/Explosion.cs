using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float timerTime;
    [SerializeField] float range = 2.5f;
    [SerializeField] float force = 150.0f;
    [SerializeField] int explosionRange = 512;

    float time;
    bool isActive;

    void Update() 
    {
        if (isActive) time += Time.deltaTime;
        if (time >= timerTime)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, range, explosionRange);
            foreach (var collider in colliders)
            {
                collider.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, range);
            }
            Destroy(this);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isActive = true;
    }
}
