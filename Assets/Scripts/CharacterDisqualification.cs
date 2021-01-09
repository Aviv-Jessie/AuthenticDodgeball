using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *  That class represents the disqualification of the characters .
 */
public class CharacterDisqualification : MonoBehaviour
{
    [SerializeField] string ballTag = "ball";
    [Tooltip("report to managerCharacter")]
    [SerializeField] ManagerCharacter managerCharacter = null;
    [SerializeField] float acceptable = 1f;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == ballTag) //other is ball
        {
            if(other.relativeVelocity.magnitude > acceptable)            
                managerCharacter.disqualification(gameObject);
        }
    }

}
