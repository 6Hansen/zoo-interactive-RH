using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MonkeySceneChanger : MonoBehaviour
{
    public string LeftSceneName;
    public string RightSceneName;
    public string WrongLeftSceneName;
    public string WrongRightSceneName;
    public string EndGoodSceneName;
    public string EndBadSceneName;
    public string Complete;
    public string MainMenu;

    public void LeftSceneClick()
    {
        if (MonkeyGame_Controller.monkeyLeftCorrect == true)
        {
            SceneManager.LoadScene(LeftSceneName);
        }
    }

    public void RightSceneClick()
    {
        if (MonkeyGame_Controller.monkeyRightCorrect == true)
        {
            SceneManager.LoadScene(RightSceneName);
        }
    }

    public void WrongLeftSceneClick()
    {
        if (MonkeyGame_Controller.monkeyLeftCorrect == false)
        {
            SceneManager.LoadScene(WrongLeftSceneName);
        }
    }

    public void WrongRightSceneClick()
    {
        if (MonkeyGame_Controller.monkeyRightCorrect == false)
        {
            SceneManager.LoadScene(WrongRightSceneName);
        }
    }

    public void EndGood()
    {
        SceneManager.LoadScene(EndGoodSceneName);
    }
    
    public void WinButton()
    {
        SceneManager.LoadScene(Complete);
    }

}
