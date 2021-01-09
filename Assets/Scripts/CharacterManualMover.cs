using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(RectTransform))]
public class CharacterManualMover : MonoBehaviour
{

    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float Speed = 4f;
    [Tooltip("key to move left")]
    [SerializeField] KeyCode left = KeyCode.LeftArrow;
    [Tooltip("key to move right")]
    [SerializeField] KeyCode right = KeyCode.RightArrow;
    [Tooltip("key to move up")]
    [SerializeField] KeyCode up = KeyCode.UpArrow;
    [Tooltip("key to move down")]
    [SerializeField] KeyCode down = KeyCode.DownArrow;

    // the text number of the character over the players head 
    Vector3 TextPosition = new Vector3(0.0f, 0.75f, 0.0f);

    // the yard size
    public float rightWall = 6.0f;
    public float leftWall = -6.0f;
    public float topWall = 4.0f;
    public float bottomWall = -4.0f;

    private Animator m_Animator;
    private RectTransform textTransform;

    void Awake()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        // text Transform - variable to save the position of the number over the player's head.
        textTransform = transform.GetComponentInChildren<RectTransform>();
        // to stay the text verticall to the players head.
        textTransform.rotation = Quaternion.Euler(0, 0, 0);
        textTransform.position = transform.position + TextPosition;
    }


    void Update()
    {
        bool _up = Input.GetKey(up);
        bool _down = Input.GetKey(down);
        bool _right = Input.GetKey(right);
        bool _left = Input.GetKey(left);
        move(_up,_left,_down,_right);

        //walk animation
        if (Input.GetKeyDown(up) || Input.GetKeyDown(down) || Input.GetKeyDown(left) || Input.GetKeyDown(right))
        {
           StartAnimation();
        }

        if (Input.GetKeyUp(up) || Input.GetKeyUp(down) || Input.GetKeyUp(left) || Input.GetKeyUp(right))
        {
            StopAnimation();
        }
    }

    public void StartAnimation(){
        m_Animator.SetTrigger("StartWalk");
    }

    public void StopAnimation(){
         m_Animator.SetTrigger("StopWalk");
    }

    public void move(bool up,bool left,bool down,bool right){
        
        // position vector
        Vector3 pos = transform.position;
        // how many add to the position?
        Vector3 adder = Vector3.zero;



        if (up && pos.y <= topWall)
        {
            adder.y += Speed * Time.deltaTime;
        }
        if (down && pos.y >= bottomWall)
        {
            adder.y -= Speed * Time.deltaTime;
        }
        if (right && pos.x <= rightWall)
        {
            adder.x += Speed * Time.deltaTime;
        }
        if (left && pos.x >= leftWall)
        {
            adder.x -= Speed * Time.deltaTime;
        }

        
        transform.position += adder;

        //calculateAngle
        if (adder.x != 0 || adder.y != 0)
        {
            // Quaternion = for rotating players on its axis
            transform.rotation = Quaternion.Euler(0, 0, calculateAngle(adder));
            // to stay the text verticall to the players head.
            textTransform.rotation = Quaternion.Euler(0, 0, 0);
            textTransform.position = pos + TextPosition;
        }
    }

    // method that calculate the rotate angle.
    private float calculateAngle(Vector3 adder)
    {
        if (adder.x != 0 && adder.y == 0)
            return adder.x > 0 ? 0 : 180;
        else if (adder.x == 0 && adder.y != 0)
            return adder.y > 0 ? 90 : 270;
        else //adder.x != 0 && adder.y != 0)
            if (adder.x > 0)
            return adder.y > 0 ? 45 : 315;
        else//x < 0
            return adder.y > 0 ? 135 : 225;
    }
}
