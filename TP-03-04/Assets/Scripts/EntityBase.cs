using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour {                                   //Base entity behaviour
    
    protected Rigidbody2D rig;
    protected Vector2 movement;
    public float moveSpeed;

    protected virtual void Start ()
    {
        rig = GetComponent<Rigidbody2D>();                              
	}
		
	protected virtual void Update ()
    {           
        rig.velocity = movement * moveSpeed * Time.deltaTime;               //Sets movement		
	}

   
}
