using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Button buttonObj;
    [SerializeField] Canvas canvasFrom;
    [SerializeField] Canvas canvasBack;

    void Start()
    {
        buttonObj.GetComponent<Button>().onClick.AddListener(ButtonActivation);
    }

    private void ButtonActivation()
    {
        canvasFrom.gameObject.SetActive(false);
        canvasBack.gameObject.SetActive(true);
    }
}
