using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenLevel : MonoBehaviour {
    //Fake loading screen
    public static ScreenLevel screenLevel;
    public GameObject levelScreen;
    public Text levelT;
    private int level;
    public bool onLoadingScreen;

    public static ScreenLevel Get()
    {
        return screenLevel;
    }

    void Awake()
    {
        screenLevel = this;
        onLoadingScreen = false;
    }

    public void InLoadingScreen() //Enters Loading screen
    {
        levelT.text = "Level " + level;
        levelScreen.SetActive(true);
    }

    public void OffLoadingScreen() //Exits loading screen
    {
        levelScreen.SetActive(false);
    }

    public void GetLevelNumber(int _level)
    {
        level = _level;
    }

    public void LoadingScreenOnOff() //Switches between loading screen on and off
    {
        onLoadingScreen = !onLoadingScreen;
    }

    public bool GetOnLoadingScreen()
    {
        return onLoadingScreen;
    }
}
