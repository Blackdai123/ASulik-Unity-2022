using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorChoosing : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] Button blueButton;
    [SerializeField] Button greenButton;
    [SerializeField] Button redButton;
    [SerializeField] Button yellowButton;

    private MeshRenderer meshRenderer;

    private void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].activeSelf)
            {
                meshRenderer = objects[i].GetComponent<MeshRenderer>();
                blueButton.onClick.AddListener(() => { meshRenderer.material.color = Color.blue; });
                greenButton.onClick.AddListener(() => { meshRenderer.material.color = Color.green; });
                redButton.onClick.AddListener(() => { meshRenderer.material.color = Color.red; });
                yellowButton.onClick.AddListener(() => { meshRenderer.material.color = Color.yellow; });
            }
        }
    }
}
