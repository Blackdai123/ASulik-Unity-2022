using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkipForNextGameOj : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] Button nextObj;
    [SerializeField] Button prevObj;

    private int currentIndex;

    void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (i == 0)
            {
                objects[0].SetActive(true);
            }
            else
            {
                objects[i].SetActive(false);
            }
        }

        nextObj.onClick.AddListener(ChoosingNext);
        prevObj.onClick.AddListener(ChoosingPrevious);
    }

    public void ChoosingNext()
    {
        currentIndex++;

        if (currentIndex >= objects.Length)
        {
            currentIndex = 0;
        }

        ObjectActivation();
    }

    public void ChoosingPrevious()
    {
        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = objects.Length - 1;
        }

        ObjectActivation();
    }

    public void ObjectActivation()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (i == currentIndex)
            {
                objects[i].SetActive(true);
            }
            else
            {
                objects[i].SetActive(false);
            }
        }
    }
}
