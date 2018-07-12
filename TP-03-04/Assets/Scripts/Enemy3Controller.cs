using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : EntityBase                                          //Enemy 3, moves from bot to top
{

   
    private Vector2 enemy3Dir;
    private int enemy3Lives = 5;
    AudioSource aS;
    private ParticleSystem dieParticles;
    private SpriteRenderer sR;
    private BoxCollider2D bC2D;

    private void Awake() //Gets components on awake
    {
        dieParticles = GetComponentInChildren<ParticleSystem>();
        sR = GetComponent<SpriteRenderer>();
        bC2D = GetComponent<BoxCollider2D>();
    }

    protected override void Start() //gets audiosource on start
    {
        base.Start();
        aS = GetComponent<AudioSource>();
    }

    protected override void Update()
    {
        base.Update();
        DoNotRotate();
        enemy3Dir.y = this.transform.position.y + 20;                             //Enemy 3 movement
        enemy3Dir.Normalize();
        movement = enemy3Dir;
        if (enemy3Lives == 0)
            Enemy3Die();

    }

    public void Enemy3Die()
    {
        ItemManager.Get().DropRandomItem(this.transform.position);              //Drops item on death
        PlayerController.Get().AddScore(50);
        aS.Play();                                            //Plays sounds, does explotion and disables the enemy
        dieParticles.Play();
        sR.enabled = !sR.enabled;
        rig.Sleep();
        bC2D.enabled = !bC2D.enabled;
        enabled = false;
        Destroy(this.gameObject,2);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.tag == "Bullet")                               //Collision with bullet         
        {                            
            enemy3Lives--;
            Destroy(collision.gameObject);
        }
    }

    private void DoNotRotate()                                                  //Prevents the enemy 3 from rotating
    {
        transform.rotation = Quaternion.identity;        
    }




}