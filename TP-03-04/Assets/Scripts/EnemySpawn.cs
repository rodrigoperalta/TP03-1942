using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : EntityBase                                                     //Enemy 1 spawns between 1 and 3, chaces player
{
    public GameObject enemy;
    public Vector2 spawnPoint;
    public int amountOfEnemies;

    protected override void Update()
    {
        base.Update();
        Vector2 move = Vector2.zero;
        move.y = move.y + 1;
        movement = move;                                                                 //Enemy 1 Spawner Movement
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            amountOfEnemies = Random.Range(1, 3);                                        //Decides how many enemies to spawn

            for (int i = 0; i < amountOfEnemies; i++)
            {
                spawnPoint.x = this.transform.position.x + Random.Range(-11, 10);        //Sets spawn position   
                spawnPoint.y = this.transform.position.y + Random.Range(10, 15);
                Instantiate(enemy, spawnPoint, Quaternion.identity);
            }
            Destroy(this.gameObject);
        }
    }
}
