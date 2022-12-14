using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health;
    [SerializeField] Vector2 CentrPosX;
    [SerializeField] Vector2 CentrPosY;

    List<GameObject> creatingEnemy;
    Vector2 rangeDistance = new Vector2(10.0f, 10.0f);
    Vector2 heading;
    float distance;

    private void Update()
    {
        if (health<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        CentrPosX.y = transform.position.y;
        CentrPosY.x = transform.position.x;

        creatingEnemy = ListEnemyManager.Instance.GetAllCreatedEnemy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
        }

        if (collision.gameObject.CompareTag("BotleBuff"))
        {
            health += BotleHealth.Instance.BotleRestoreHealth(); //проработать чтобы бафало на количество хп не больше заданного а то бужет хп больше 100
        }

        if (collision.gameObject.name.Equals("TriggerRight"))
        {
            gameObject.transform.position = CentrPosX;
            
            foreach(GameObject obj in creatingEnemy)
            {
                heading = obj.transform.position - gameObject.transform.position;
                Debug.Log(heading);
                distance = heading.magnitude;
                Debug.Log(distance);
                //if (distance < 10)
                //{
                //    obj.transform.position = new Vector2 (CentrPosX.x+distance, CentrPosY.y+distance);
                //}
                IncludedInTheRadius(gameObject.transform.position, 30.0f);
            }
        }

        if (collision.gameObject.name.Equals("TriggerLeft"))
        {
            gameObject.transform.position = CentrPosX;
        }

    }

    void IncludedInTheRadius(Vector2 center, float radius)
    {
        Debug.Log("Hello Tolia");

        Collider[] enemysInTheRadius = Physics.OverlapSphere(center, radius);
        Debug.Log(enemysInTheRadius);
        foreach(var enemy in enemysInTheRadius)
        {
            enemy.transform.position = new Vector2(CentrPosX.x + distance, CentrPosY.y + distance);
        }
    }
}
