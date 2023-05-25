using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PapegøjeButtons : MonoBehaviour
{
    static int ParotPoint = 0;
    Text parotScore;
    RandomSounds GetOneOrTwo;
    public GameObject gameWinScreen;
    public GameObject gameLossScreen;

    void Start()
    {
        parotScore = GetComponent<Text>();
        GetOneOrTwo = GameObject.FindGameObjectWithTag("RandomSounds").GetComponent<RandomSounds>();

    }

    // Update is called once per frame
    void Update()
    {
        parotScore.text = "score: " + ParotPoint;
        
        if (ParotPoint == 10)
        {
            gameWinScreen.SetActive(true);
        }

        if (PapegøjeLife.parotLife == 0)
        {
            gameLossScreen.SetActive(true);
        }
    }

    public void MonkeyClick()
    {
        if (RandomSounds.MonkeyTrue == true)
        {
            ParotPoint++;
        }
    }

    public void ElephantClick()
    {
        if (RandomSounds.ElephantTrue == true)
        {
            ParotPoint++;
        }
    }

    public void LionClick()
    {
        if (RandomSounds.LionTrue == true)
        {
            ParotPoint++;
        }
    }

    public void PinguinClick()
    {
        if (RandomSounds.PinguinTrue == true)
        {
            ParotPoint++;
        }
    }
    
    public void Reset()
    {
        PapegøjeLife.parotLife = 3;
        ParotPoint = 0;
        gameWinScreen.SetActive(false);
        gameLossScreen.SetActive(false);
    }
}
