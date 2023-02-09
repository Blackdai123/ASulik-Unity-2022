using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lol : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text playerPos;
    [SerializeField] TMPro.TMP_Text playerNation;
    [SerializeField] TMPro.TMP_Text playerLigue;
    [SerializeField] TMPro.TMP_Text playerClub;
    //[SerializeField] TMPro.TMP_Text plauerName;
    [SerializeField] TMPro.TMP_Text timerText;
    [SerializeField] TMPro.TMP_Text winText;
    [SerializeField] Button enterText;

    [SerializeField] TMPro.TMP_Text inputNamePlayer;

    TMPro.TMP_Text userEnterText;
    Players activePlayer;
    float timer;
    float waitingTimer = 40f;
    bool hintGiven = false;
    int hintNumber = 2;

    private void Start()
    {
        //enterText.GetComponent<Button>().onClick.AddListener(ButtonActivation);
        
        activePlayer = playersChoice();
        

    }
    void Update()
    {
        timerText.text = timer.ToString("F2");

        timer += Time.deltaTime;

        playerPos.text = activePlayer.positions;

        if (timer >= waitingTimer)
        {
            if (!hintGiven)
            {
                giveNextClue(hintNumber);

                hintNumber++;

                //if (hintNumber>4)
                //{
                //    //все что ниже нужно перенести в отдельный метод и сделать при отгадывании игрока а тут прописать конец игры
                //    hintNumber = 2;

                //    playerPos = null;

                //    playerNation = null;

                //    playerLigue = null;

                //    playerClub = null;

                //    activePlayer = playersChoice();
                //}
            }
            timer = 0;
        }
    }

    void giveNextClue(int hintNumber)
    {
        switch (hintNumber)
        {
            case 2:
                playerLigue.text = activePlayer.ligue;
                break;

            case 3:
                playerClub.text = activePlayer.club;
                break;

            case 4:
                playerNation.text = activePlayer.nationality;
                break;
        }
            
    }

    Players playersChoice()
    {
        activePlayer = BasePlayers.Instance.GiveRandEasyPlayer();
        return activePlayer;
    }

    public void inputComparison()
    {
        Debug.Log("entrance to method");
        string s = inputNamePlayer.text;
        var b3 = System.Text.Encoding.ASCII.GetBytes(s);
        //var sa = s.TrimEnd();
        s = s.TrimEnd( );
        string q = activePlayer.name;
        var b1 = System.Text.Encoding.ASCII.GetBytes(s);
        var b2 = System.Text.Encoding.ASCII.GetBytes(q);
        //var b3 = System.Text.Encoding.ASCII.GetBytes(sa);
        bool w = s == q;
        bool sd = inputNamePlayer.text == activePlayer.name;
        bool d = string.Equals(s, q, StringComparison.InvariantCulture);
        int g = string.Compare(s, q);
        Debug.Log(g);
        Debug.Log(w);
        Debug.Log(d);
        Debug.Log(sd);
        winText.text = s;

        if (inputNamePlayer.text == activePlayer.name)
        {
            winText.text = "YOU WIN!!!!!!!!!!!";
        }
        else
        {
            giveNextClue(hintNumber);
            hintNumber++;
        }

        Debug.Log(inputNamePlayer.text);

        Debug.Log(activePlayer.name);
    }

    private void ButtonActivation()
    {

    }
}
