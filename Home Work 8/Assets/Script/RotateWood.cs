using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWood : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float step;
    public SpriteRenderer render;

    public float progres = 0f;
    public int indexator = 1;
    public float flipProgres = 0f;

    void Start()
    {
        transform.position = startPosition;    
    }

    void Update()
    {
        if (render.flipX == false)
        {
            if (indexator == 0)
            {
                if (flipProgres <= 1)
                {
                    //flipProgres = MoveFromCurrentPosition(endPosition);
                    transform.position = Vector3.Lerp(this.gameObject.transform.position, endPosition, flipProgres); //transform.position
                    flipProgres += step;
                }     

                if (flipProgres >= 1)
                {
                    transform.position = startPosition;
                    flipProgres = 0;
                    indexator = 1;
                    progres = 0;
                }
            }
            if (indexator == 1)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, progres);
                progres += step;

                if (progres >= 1)
                {
                    transform.position = startPosition;
                    progres = 0;
                }
            }
        }
       
        if (render.flipX)
        {
            if (indexator == 1)
            {
                if (flipProgres <=1)
                {
                    //flipProgres = MoveFromCurrentPosition(startPosition);
                    transform.position = Vector3.Lerp(this.gameObject.transform.position, startPosition, flipProgres); //transform.position
                    flipProgres += step;
                }

                if (flipProgres >= 1)
                {
                    transform.position = endPosition;
                    flipProgres = 0;
                    indexator = 0;
                    progres = 0;
                }
            }

            if (indexator == 0)
            {
                transform.position = Vector3.Lerp(endPosition, startPosition, progres);
                progres += step;

                if (progres >= 1)
                {
                    transform.position = endPosition;
                    progres = 0;
                }
            }
        }
    }

    private float MoveFromCurrentPosition (Vector3 endPos)
    {
        transform.position = Vector3.Lerp(this.gameObject.transform.position, endPos, flipProgres); //transform.position
        flipProgres += step;

        return flipProgres;
    }
}
