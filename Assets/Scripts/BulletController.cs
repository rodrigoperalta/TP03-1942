using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : EntityBase
{
    Vector2 move;
    int bulletNumber;
    private void Awake()
    {
        bulletNumber = PlayerController.Get().ReturnBulletNumber();        
        if (bulletNumber == 1)
            move.y = 1;
        if (bulletNumber == 2)
        {
            move.y = 1;
            move.x = 1;
        }
        if (bulletNumber == 3)
        {
            move.y = 1;
            move.x = -1;
        }       
    }

    protected override void Update()
    {
        base.Update();
        BulletDirection();       
    }    

    private void BulletDirection()
    {
        if (bulletNumber == 1)
        {
            move.y = move.y + 1 * Time.deltaTime;
        }
        if (bulletNumber == 2)
        {
            move.y = move.y + 1 * Time.deltaTime;
            move.x = move.x + 1 * Time.deltaTime;
        }
        if (bulletNumber == 3)
        {
            move.y = move.y + 1 * Time.deltaTime;
            move.x = move.x - 1 * Time.deltaTime;
        }

        movement = move;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "BulletKiller")                   //Bullet killer collision
            Destroy(this.gameObject);
    }

   
}
