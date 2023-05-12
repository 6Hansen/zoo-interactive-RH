using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MonkeySceneChanger : MonoBehaviour
{
    public string monkeySceneName;

    public void LeftSceneClick()
    {
        if (MonkeyGame_Controller.monkeyLeftCorrect == true)
        {
            SceneManager.LoadScene(monkeySceneName);
        }
    }
}
