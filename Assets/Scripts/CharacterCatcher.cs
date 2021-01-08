using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterCatcher : MonoBehaviour
{
    [SerializeField] string ballTag = "ball";
    [SerializeField] float speedThrown = 8f;
    [SerializeField] protected float linearDrag = 1f;
    [Tooltip("report to managerCharacter")]
    [SerializeField] ManagerCharacter managerCharacter = null;
    private GameObject ball;
    private ForceMode2D forceMode = ForceMode2D.Impulse;

    private CharacterModeSwitcher characterModeSwitcher;

    // Start is called before the first frame update
    void Start()
    {
        characterModeSwitcher = GetComponentInParent<CharacterModeSwitcher>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == ballTag) //other is ball
        {
            ball = other.gameObject;
            Rigidbody2D rd = ball.GetComponent<Rigidbody2D>();
            rd.isKinematic = true;                                  // change to kinematic to disable the pyshics.
            rd.velocity = Vector3.zero;                             // ball stops to move..
            ball.transform.parent = transform.parent;               // the ball will be the child of the player
            characterModeSwitcher.setHaveBall(true);                // setter to the haveBall
            ball.transform.position = this.transform.position;      // ball stay with the player position..

            CharacterAutoMover characterAutoMover = GetComponentInParent<CharacterAutoMover>();
            if(characterAutoMover && characterAutoMover.enabled)
                characterAutoMover.onCatchBall();
        }

    }

    //return true if have ball and is Thrown this.
    //return false if no have ball
    public bool Thrown()
    {
        if (ball)
        {
            characterModeSwitcher.setHaveBall(false);
            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;                             // return the pyshics rules..
            ball.transform.SetParent(null);                     // the ball no the playuer's child- the ball by his own..
            // here we calculate the ball's velocity for the throw.
            Transform playerTransform = transform.parent;       // to calculate the velocity of the trown ball
            Vector3 velocity = this.transform.position - playerTransform.position;  // the calc..
            float distance = Vector3.Distance(transform.position, playerTransform.position);    // distance calc
            velocity = velocity / distance; // normalize
            velocity = velocity * speedThrown;  // normalize = 1, we need to * speed of the throw..
            rb.AddForce(velocity, forceMode);   // add force to move the ball
            rb.drag = linearDrag;

            ball = null;
            managerCharacter.setThrower(transform.parent.gameObject);
            return true;    // return true if thrown
        }
        else
            return false;   // do not thrown..

    }

    // Update is called once per frame
    void Update()
    {

    }
}
