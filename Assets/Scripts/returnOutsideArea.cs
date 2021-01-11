using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnOutsideArea : MonoBehaviour
{
     //fix some glitche
    private Vector3 startPos;
    [SerializeField]float maxSize = 9;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > maxSize || transform.position.x < -maxSize || transform.position.y > maxSize || transform.position.y < -maxSize)
        {
            transform.position = startPos;
            Debug.Log("ball Outside Area start position");
        }
            
    }
}
