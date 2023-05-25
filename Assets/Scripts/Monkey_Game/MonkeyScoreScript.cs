using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonkeyScoreScript : MonoBehaviour
{

    public string EndGoodSceneName;
    public string EndLossSceneName;
    public static int monkeyPoint = 0;
    Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = "score: " + monkeyPoint;
        Debug.Log("Points = " + monkeyPoint);

        if (monkeyPoint == 5)
        {
            SceneManager.LoadScene(EndGoodSceneName);
        }

        if (MonkeyLife.monkeyLife == 0)
        {
            SceneManager.LoadScene(EndLossSceneName);
        }

    }

    public void LeftMonkeyClick()
    {
        if (MonkeyGame_Controller.monkeyLeftCorrect == true)
        {
            monkeyPoint ++;
        }
    }

    public void RightMonkeyClick()
    {
        if (MonkeyGame_Controller.monkeyRightCorrect == true)
        {
            monkeyPoint++;
        }
    }
}
