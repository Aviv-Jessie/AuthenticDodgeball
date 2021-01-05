using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisqualification : MonoBehaviour
{
    [SerializeField] string ballTag = "ball";
    [Tooltip("report to managerCharacter")]
    [SerializeField] ManagerCharacter managerCharacter = null;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == ballTag) //other is ball
        {
            managerCharacter.disqualification(gameObject);
        }
    }

}
