using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text score;
    public Text energy;
    public Text bombsLeft;
    
    void Update()
    {
        score.text = LevelManager.Get().ReturnScore().ToString();
        energy.text = PlayerController.Get().GetEnergy().ToString();
        bombsLeft.text = PlayerController.Get().GetNumberOfBombs().ToString();
    }
}
