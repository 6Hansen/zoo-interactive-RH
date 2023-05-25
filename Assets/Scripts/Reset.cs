using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{

    public GameObject StartButton;
    public GameObject MiniGames;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetButtonMonkey()
    {
        MonkeyLife.monkeyLife = 3;
        MonkeyScoreScript.monkeyPoint = 0;
    }

    public void ResetButtonFodring()
    {
        AnimalFeedingGame.lionFedTimes = 0;
        AnimalFeedingGame.elephantFedTimes = 0;
    }

    public void GameStart()
    {
        StartButton.SetActive(false);
        MiniGames.SetActive(true);
        FindObjectOfType<AudioManager>().Play("Intro");
    }

    public void MonkeyStart()
    {
        FindObjectOfType<AudioManager>().Play("MonkeyIntro");
    }

}
