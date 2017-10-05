using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

    public void LoadScene1() 
    {
    SceneManager.LoadScene("LevelWithoutHealth");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Level");
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene("LevelWithChallenge");
    }

    public void LoadScene4()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
