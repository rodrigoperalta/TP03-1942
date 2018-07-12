using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : EntityBase                                          //Enemy 1, chaces player
{

    public Transform target;
    private Vector2 dir;
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

    protected override void Start() //gets audiosource
    {
        base.Start();
        aS = GetComponent<AudioSource>();
    }

    protected override void Update()
    {
        base.Update();
        dir = PlayerController.Get().GetPos() - transform.position;                 //Enemy 1 movement
        dir.Normalize();
        movement = dir;        
    }

    public void Die()
    {        
        PlayerController.Get().AddScore(10);
        aS.Play();                              //Plays sounds, does explotion and disables the enemy
        dieParticles.Play();
        sR.enabled = !sR.enabled;
        rig.Sleep();
        bC2D.enabled = !bC2D.enabled;
        enabled = false;
        Destroy(this.gameObject,2);      
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")                                   // Collision with bullet         
        {
            ItemManager.Get().DropRandomItem(this.transform.position);    //Drops item on death
            Die();
            Destroy(collision.gameObject);           
        }
    }

   




}
