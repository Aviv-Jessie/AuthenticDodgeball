using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class TemporaryExampleScript : MonoBehaviour
{
    public Transform target;
    private Animator m_Animator;
  // Angular speed in radians per sec.
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
         //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
          //Press the up arrow button to reset the trigger and set another one
        if (Input.GetKeyDown(KeyCode.R))
        {
            
            //Send the message to the Animator to activate the trigger parameter named "Jump"
            m_Animator.SetTrigger("Catch");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            //Send the message to the Animator to activate the trigger parameter named "Crouch"
            m_Animator.SetTrigger("Thrown");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            //Send the message to the Animator to activate the trigger parameter named "Crouch"
            m_Animator.SetTrigger("StartWalk");
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            //Send the message to the Animator to activate the trigger parameter named "Crouch"
            m_Animator.SetTrigger("StopWalk");
        }

    }
}
