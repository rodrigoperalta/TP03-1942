using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Spawn : EntityBase                                                        //Spawns enemy 3
{
    public GameObject enemy3;
    public Vector2 spawnPoint;
    
    protected override void Update()
    {
        base.Update();
        Vector2 move = Vector2.zero;
        move.y = move.y + 1;
        movement = move;                                                                    //Enemy 3 spawn movement
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {

            spawnPoint.x = this.transform.position.x + Random.Range(-11, 10);              //Sets enemy 3 spawn position
            spawnPoint.y = this.transform.position.y -13;
            
            Instantiate(enemy3, spawnPoint, Quaternion.identity);
            
            Destroy(this.gameObject);
        }
    }
}
