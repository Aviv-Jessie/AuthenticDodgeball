using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisqualification : MonoBehaviour
{
    [SerializeField] string ballTag = "ball";
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == ballTag) //other is ball
        {
            Debug.Log("disqualification");
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
