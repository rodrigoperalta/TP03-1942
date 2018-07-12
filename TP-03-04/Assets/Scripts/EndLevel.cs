using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : EntityBase
{
    //When player collides with this GO, the level changes

    protected override void Update()
    {
        base.Update();
        Vector2 move = Vector2.zero;
        move.y = move.y + 1;
        movement = move;                                          //End game trigger movemment
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            LevelManager.Get().NextLevel();  //Next level
            Destroy(this);                   
        }
    }
}