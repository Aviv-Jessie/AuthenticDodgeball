using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCatcher : MonoBehaviour
{
    [SerializeField] string ballTag = "ball";
    [SerializeField] float speedThrown = 8f;
    [SerializeField] protected float linearDrag = 1f;
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
            Debug.Log("catch ball______");
            ball = other.gameObject;
            //CircleCollider2D circleCollider2D = ball.GetComponent<CircleCollider2D>();
            //circleCollider2D.enabled = false;
            Rigidbody2D rd = ball.GetComponent<Rigidbody2D>();
            rd.isKinematic = true;
            rd.velocity = Vector3.zero;
            ball.transform.parent = transform.parent;
            characterModeSwitcher.setHaveBall(true);
            //ball.transform.position = this.transform.position;
        }

    }

    //return true if have ball and is Thrown this.
    //return false if no have ball
    public bool Thrown()
    {
        if (ball)
        {
            Debug.Log("Thrown ball______");
            characterModeSwitcher.setHaveBall(false);

            Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;

            ball.transform.SetParent(null);

            Transform player = transform.parent;
            Vector3 velocity = this.transform.position - player.position;
            float distance = Vector3.Distance(transform.position, player.position);
            velocity = velocity / distance;
            velocity = velocity * speedThrown;

            //CircleCollider2D circleCollider2D = ball.GetComponent<CircleCollider2D>();
            //circleCollider2D.enabled = true;

            rb.AddForce(velocity, forceMode);
            rb.drag = linearDrag;

            ball = null;
            return true;
        }
        else
            return false;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
