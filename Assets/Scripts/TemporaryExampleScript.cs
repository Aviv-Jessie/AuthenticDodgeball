using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class TemporaryExampleScript : MonoBehaviour
{
    private Animation anim;


    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Catch");
            anim.Play("Catch");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Thrown");
            anim.Play("Thrown");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Walk");
            anim.Play("Walk");        
        }

    }
}
