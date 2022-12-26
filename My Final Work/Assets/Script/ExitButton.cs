using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ExitButton : MonoBehaviour
{
    [SerializeField] Button exitButton;

    void Start()
    {
        exitButton.GetComponent<Button>().onClick.AddListener(ButtonActivation);
    }

    private void ButtonActivation()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}        
    
