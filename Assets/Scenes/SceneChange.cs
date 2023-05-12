using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeScene()
    {
    SceneManager.LoadScene("scene2");
        
    }
    public void SceneOne()
    {
        SceneManager.LoadScene(1);

    }
    public void SceneTwo()
    {
        SceneManager.LoadScene(2);

    }
    public void SceneThree()
    {
        SceneManager.LoadScene(3);

    }
    public void Next()
        { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    public void Back()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    public void Quit()
    {
        Application.Quit();
    }
}
