using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : EntityBase
{

    public static PlayerController player;
    public Transform bulletPrefab;
    private GameObject[] enemies;
    private Vector2 bulletScale;
    public TimeManager timeManager;
    private float energy = 0;
    private int score;
    public int numberOfBombs;
    private float spriteBlinkingTimer = 0.0f;
    private float spriteBlinkingMiniDuration = 0.1f;
    private float spriteBlinkingTotalTimer = 0.0f;
    private float spriteBlinkingTotalDuration = 1.0f;
    private bool startBlinking = false;
    private int bulletNumber;
    private bool multiShot = false;

    // public GameObject bullet;

    public static PlayerController Get()
    {
        return player;
    }

    private void Awake()
    {
        bulletNumber = 1;
        numberOfBombs = 1;
        energy = 150;
        player = this;
        bulletScale.x = 5f;
        bulletScale.y = 5f;
        bulletPrefab.transform.localScale = bulletScale;        
    }


    protected override void Update()
    {
        base.Update();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 move = Vector2.zero;
        move.x = horizontal;
        move.y = vertical;
        move.Normalize();
        energy = energy - 0.5f * Time.deltaTime;
        Die();
        DoNotRotate();
        movement = move;
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (numberOfBombs > 0)
            {
                Bomb();
                numberOfBombs--;
            }
        }

        if (startBlinking == true)
        {
            SpriteBlinkingEffect();
        }
    }

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   // according to 
                                                                             //your sprite
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;  //make changes
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   //make changes
            }
        }
    }

    public int ReturnScore()
    {
        return score;
    }

    protected void Shoot()      //Player attack1, shoots, kills enemies hit
    {        
        Transform bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity) as Transform;
        bulletNumber = 1;
        if (multiShot == true)
        {
            Transform bullet2 = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity) as Transform;
            bulletNumber = 2;
            Transform bullet3 = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity) as Transform;
            bulletNumber = 3;
        }
        
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        energy--;
    }

    public int ReturnBulletNumber()
    {
        return bulletNumber;
    }

   

    protected void Bomb()      //Player attack2, bomb, kill all enemies
    {
        GetComponent<AudioSource>().Play();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (var i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
        CameraShake.Get().Shake(0.1f, 1.0f);  //Shakes for amount and length
    }

    public Vector3 GetPos()
    {
        return this.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PU1")      //Power up 1, bigger bullets
        {
            if (bulletScale.x < 10)
            {
                bulletScale.x = bulletScale.x + 0.5f;
                bulletScale.y = bulletScale.y + 0.5f;
            }

            bulletPrefab.transform.localScale = bulletScale;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "PU2")      //Power up 2, gain energy
        {
            energy += 20;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "PU3")      //Power up 3, multishot
        {
            multiShot = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "PU4")      //Power up 4, add bomb
        {
            numberOfBombs += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "PU5")      //Power up 4, add bomb
        {
            timeManager.BulletTime();
            Destroy(collision.gameObject);
        }
       

        if (collision.gameObject.tag == "Enemy")    //Collision with enemy, player loses energy
        {
            energy -= 20;
            startBlinking = true;
            Destroy(collision.gameObject);
        }
    }


    private void Die()                              //Player death condition
    {
        if (energy < 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    private void DoNotRotate()                      //Prevents the player from rotating
    {
        transform.rotation = Quaternion.identity;
    }

    public void AddScore(int _score)
    {
        score += _score;
    }

    public int GetEnergy()
    {
        return (int)energy;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetNumberOfBombs()
    {
        return numberOfBombs;
    }




}
