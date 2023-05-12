using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonkeyLife : MonoBehaviour
{
    public static int monkeyLife = 3;
    Text life;

    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        life.text = "life: " + monkeyLife;
        Debug.Log("life = " + monkeyLife);
    }

    public void LeftLifeClick()
    {
        if (MonkeyGame_Controller.monkeyLeftCorrect == false)
        {
            monkeyLife--;
        }
    }

    public void RightLifeClick()
    {
        if (MonkeyGame_Controller.monkeyRightCorrect == false)
        {
            monkeyLife--;
        }
    }
}