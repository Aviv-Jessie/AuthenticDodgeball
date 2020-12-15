using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
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



    void Update() {              
        Vector3 pos = transform.position;

        if (Input.GetKey(up)){
            pos.y += Speed * Time.deltaTime;
        }
        if (Input.GetKey(down)){
            pos.y -= Speed * Time.deltaTime;
        }
        if (Input.GetKey(right)){
            pos.x += Speed * Time.deltaTime;
        }
        if (Input.GetKey(left)){
            pos.x -= Speed * Time.deltaTime;
        }


        transform.position = pos;
     }
}
