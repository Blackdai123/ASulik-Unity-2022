using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshPro playerPos;
    [SerializeField] TMPro.TextMeshPro playerNation;
    [SerializeField] TMPro.TextMeshPro playerLigue;
    [SerializeField] string playerClub;
    [SerializeField] TMPro.TextMeshPro plauerName;
    [SerializeField] Button enterText;

    [SerializeField] InputField inputNamePlayer;

    TMPro.TextMeshPro userEnterText;
    Players activePlayer;

    private void Start()
    {
        enterText.GetComponent<Button>().onClick.AddListener(ButtonActivation);

        activePlayer = BasePlayers.Instance.GiveRandEasyPlayer();
    }
    void Update()
    {
        playerClub = activePlayer.club;
    }

    private void ButtonActivation()
    {

    }
}
