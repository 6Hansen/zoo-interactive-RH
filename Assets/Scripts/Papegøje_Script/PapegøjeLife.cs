using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PapegøjeLife : MonoBehaviour
{
    public static int parotLife = 3;
    Text ParotLife;
    RandomSounds GetOneOrTwo;

    void Start()
    {
        ParotLife = GetComponent<Text>();
        GetOneOrTwo = GameObject.FindGameObjectWithTag("RandomSounds").GetComponent<RandomSounds>();

    }

    // Update is called once per frame
    void Update()
    {
        ParotLife.text = "score: " + parotLife;
    }

    public void WrongMonkeyClick()
    {
        if (RandomSounds.MonkeyTrue == false)
        {
            parotLife--;
        }
    }

    public void WrongElephantClick()
    {
        if (RandomSounds.ElephantTrue == false)
        {
            parotLife--;
        }
    }

    public void WrongLionClick()
    {
        if (RandomSounds.LionTrue == false)
        {
            parotLife--;
        }
    }

    public void WrongPinguinClick()
    {
        if (RandomSounds.PinguinTrue == false)
        {
            parotLife--;
        }
    }
}
