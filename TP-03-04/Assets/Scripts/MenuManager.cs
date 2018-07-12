using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void StartGame() //Starts the game
    {
        if (LevelManager.Get() != null)
            LevelManager.Get().Kill();

        SceneManager.LoadScene("Level1");
    }

    public void QuitGame() //Quits the game
    {
        Application.Quit();
    }
}
