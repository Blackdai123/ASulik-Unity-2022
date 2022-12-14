using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] Button pauseButton;
    [SerializeField] Button resumeButton;

    bool isPaused;

    void Start()
    {
        pauseButton.GetComponent<Button>();
    }

    void Update()
    {
        pauseButton.onClick.AddListener(PausedGame);

        resumeButton.onClick.AddListener(ResumeGame);
    }

    void PausedGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }

    void ResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
