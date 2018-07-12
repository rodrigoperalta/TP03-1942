using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : EntityBase {
    //Power Ups move with level
    protected override void Update()
    {
        base.Update();
        Vector2 move = Vector2.zero;
        move.y = move.y + 1;
        movement = move;                                                                    
    }
}
