using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
 [RequireComponent(typeof(Animator))]
public class CharacterManualMover: MonoBehaviour {

    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float Speed = 4f;
    [Tooltip("ket to move left")]
    [SerializeField] KeyCode left = KeyCode.LeftArrow;
    [Tooltip("ket to move right")]
    [SerializeField] KeyCode right = KeyCode.RightArrow;
    [Tooltip("ket to move up")]
    [SerializeField] KeyCode up = KeyCode.UpArrow;
    [Tooltip("ket to move down")]
    [SerializeField] KeyCode down = KeyCode.DownArrow;

    // the yard size
    public float rightWall = 6.0f;
    public float leftWall = -6.0f;
    public float topWall = 4.0f;
    public float bottomWall =-4.0f;

    private Animator m_Animator;

    void Start()
    {         
        m_Animator = gameObject.GetComponent<Animator>();
    }


    void Update() {             
        // position vector
        Vector3 pos = transform.position;
        // how many add to the position?
        Vector3 adder = Vector3.zero;
        
        if (Input.GetKey(up) && pos.y <= topWall)
        {
            adder.y += Speed * Time.deltaTime;            
        }
        if (Input.GetKey(down) && pos.y >= bottomWall)
        {
            adder.y -= Speed * Time.deltaTime;
        }
        if (Input.GetKey(right) && pos.x <= rightWall)
        {
            adder.x += Speed * Time.deltaTime;
        }
        if (Input.GetKey(left) && pos.x >= leftWall)
        {
            adder.x -= Speed * Time.deltaTime;
        }

        transform.position += adder;
        
        //calculateAngle
        if(adder.x != 0 || adder.y != 0)
            // Quaternion = for rotating players on its axis
            transform.rotation = Quaternion.Euler(0,0,calculateAngle(adder));

        //walk animation
        if(Input.GetKeyDown(up) || Input.GetKeyDown(down) || Input.GetKeyDown(left) || Input.GetKeyDown(right))
            m_Animator.SetTrigger("StartWalk");

        if(Input.GetKeyUp(up) || Input.GetKeyUp(down) || Input.GetKeyUp(left) || Input.GetKeyUp(right))
            m_Animator.SetTrigger("StopWalk");
     }

    // method that calculate the rotate angle.
     private float calculateAngle(Vector3 adder)
     {
        if(adder.x != 0 && adder.y == 0)
            return adder.x > 0 ? 0 : 180;
        else if(adder.x == 0 && adder.y != 0)
            return adder.y > 0 ? 90 : 270;
        else //adder.x != 0 && adder.y != 0)
            if(adder.x > 0)
                return adder.y>0 ? 45 : 315;
            else//x < 0
                return adder.y>0 ? 135 : 225;
     }
}
