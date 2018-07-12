using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {


    public static LevelManager levelManager;
    private int level;
    private int score;

    public static LevelManager Get()
    {
        return levelManager;
    }

    private void Awake()
    {
        level = 1;
        MakeThisTheOnlyLevelManager();
    }

    private void Update()
    {
        score = PlayerController.Get().ReturnScore();
    }

    public void NextLevel() //Sets up loading screen
    {
        
        level++;
        ScreenLevel.Get().GetLevelNumber(level);
        ScreenLevel.Get().LoadingScreenOnOff();       
        ScreenLevel.Get().InLoadingScreen();        
        StartCoroutine(LoadLevelAfterTime(3));
    }

    public int ReturnScore()
    {
        return score;
    }

    IEnumerator LoadLevelAfterTime(float time) // Time to wait between loading screen and next level
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Level2");
        ScreenLevel.Get().LoadingScreenOnOff();
    }
        
    void MakeThisTheOnlyLevelManager() //Singleton
    {
        if (levelManager == null)
        {
            DontDestroyOnLoad(gameObject);
            levelManager = this;
        }
        else
        {
            if (levelManager != this)
                Destroy(gameObject);
        }
    }

    public void Kill()
    {
        Destroy(this);
    }
}
