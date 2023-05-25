using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    public static bool MonkeyTrue = false;
    public static bool ElephantTrue = false;
    public static bool LionTrue = false;
    public static bool PinguinTrue = false;
    

    void Start()
    {
        OneOrTwo();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("MTrue? = " + MonkeyTrue);
        Debug.Log("ETrue? = " + ElephantTrue);
        Debug.Log("LTrue? = " + LionTrue);
        Debug.Log("PTrue? = " + PinguinTrue);
    }

    public void OneOrTwo()
    {
        int randomNumber = Random.Range(0, 2);
        MonkeyTrue = false;
        ElephantTrue = false;
        LionTrue = false;
        PinguinTrue = false;

        if (randomNumber < 1)
        {
            NumberOne();
        }
        else
        {
            NumberTwo();
        }
    }

    void NumberOne()
    {
        int AnimalOneNumber = Random.Range(0, 2);

        if (AnimalOneNumber < 1)
        {
            Monkey();
        }
        else
        {
            elephant();
        }
    }

    void NumberTwo()
    {
        int AnimalTwoNumber = Random.Range(0, 2);

        if (AnimalTwoNumber < 1)
        {
            Lion();
        }
        else
        {
            Pinguin();
        }
    }

    void Monkey()
    {
        FindObjectOfType<AudioManager>().Play("Monkey");
        MonkeyTrue = true;
        ElephantTrue = false;
        LionTrue = false;
        PinguinTrue = false;
    }

    void elephant()
    {
        FindObjectOfType<AudioManager>().Play("Elephant");
        MonkeyTrue = false;
        ElephantTrue = true;
        LionTrue = false;
        PinguinTrue = false;
    }

    void Lion()
    {
        FindObjectOfType<AudioManager>().Play("Lion");
        MonkeyTrue = false;
        ElephantTrue = false;
        LionTrue = true;
        PinguinTrue = false;
    }

    void Pinguin()
    {
        FindObjectOfType<AudioManager>().Play("Pinguin");
        MonkeyTrue = false;
        ElephantTrue = false;
        LionTrue = false;
        PinguinTrue = true;
    }
}
