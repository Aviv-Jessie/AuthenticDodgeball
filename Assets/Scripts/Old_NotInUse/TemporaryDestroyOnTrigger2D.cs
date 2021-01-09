using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This is temporary script, we will change it at the next assignment.
 * this script is for the trigger touch destories
 */
public class TemporaryDestroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag = "Player";
    [Tooltip("destroy self gameObject")]
    [SerializeField] bool destroyMySelf = false;
    // Start is called before the first frame update
   private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == triggeringTag) {
            if(destroyMySelf)
                Destroy(this.gameObject);
        }
    }
}
