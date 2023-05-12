using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyGame_Controller : MonoBehaviour
{
    public GameObject MonkeyOne;
    public GameObject MonkeyTwo;
    public static bool monkeyLeftCorrect;
    public static bool monkeyRightCorrect;

    void Start()
    {
        randomMonkey();
        Debug.Log("LeftTrue? = " + monkeyLeftCorrect);
        Debug.Log("RightTrue? = " + monkeyRightCorrect);
    }

    public void randomMonkey()
    {
        int randomIndex = Random.Range(0, 2);
        if (randomIndex < 1)
        {
            monkeyOne();
        }
        else
        {
            monkeyTwo();
        }
    }

    public void monkeyOne()
    {
        Instantiate(MonkeyOne);
        monkeyLeftCorrect = true;
        monkeyRightCorrect = false;
    }

    public void monkeyTwo()
    {
        Instantiate(MonkeyTwo);
        monkeyRightCorrect = true;
        monkeyLeftCorrect = false;
    }
}