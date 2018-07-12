using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spawn : EntityBase                                                        //Spawns groups of enemies
{
    public GameObject enemy2;
    public Vector2 spawnPoint;
   


    protected override void Update()
    {
        base.Update();
        Vector2 move = Vector2.zero;
        move.y = move.y + 1;
        movement = move;                                                                    //Enemy 2 spawn movement
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            
            spawnPoint.x = this.transform.position.x + Random.Range(-11, 10);              //Sets enemy 2 spawn position
            spawnPoint.y = this.transform.position.y + Random.Range(10, 15);
            for (int i = 0; i < 5; i++)
            {
                spawnPoint.x = spawnPoint.x + 1.5f;                                           //Spaces enemy position
                spawnPoint.y = spawnPoint.y + 1.5f;
                Instantiate(enemy2, spawnPoint, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
}
