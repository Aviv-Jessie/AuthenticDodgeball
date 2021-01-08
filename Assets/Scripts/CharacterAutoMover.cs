using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// plse sask for aviv show "state machine.pptx" before you read thr code.
[RequireComponent(typeof(CharacterManualMover))]
[RequireComponent(typeof(CharacterModeSwitcher))]
public class CharacterAutoMover : MonoBehaviour
{
    [SerializeField] public GameObject ball = null;
    enum State { defense, attack }

    private CharacterManualMover mover;
    private CharacterModeSwitcher modeSwitcher;
    private bool up;
    private bool left;
    private bool down;
    private bool right;

    private bool meLeftSide;

    private bool ballInMySide;

    private State state;

    private static ArrayList charactersLeft = new ArrayList();
    private static ArrayList charactersRight = new ArrayList();

    private int myIndex;

    private bool iLeader = false;

    private Vector3 startPosition;

    private float distanceDestination = 0.2f;
    private float distanceCatch = 0.35f;

    private bool ArrivedDestination = false;

    private Vector3 gizmosDes = Vector3.zero;

    void OnDrawGizmos()
    {
        if (iLeader)
        {
            // Draw a green sphere if i am leader
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.25f);
        }
        if (gizmosDes != Vector3.zero)
            Gizmos.DrawLine(transform.position, gizmosDes);
    }

    void Start()
    {
        startPosition = transform.position;
        state = State.defense;
        //now if i in left side or right side.
        meLeftSide = transform.position.x < 0;
        if (meLeftSide)
            myIndex = charactersLeft.Add(this);
        else
            myIndex = charactersRight.Add(this);

        setSomeLeader();

    }

    private void OnEnable()
    {
        mover = GetComponent<CharacterManualMover>();
        modeSwitcher = GetComponent<CharacterModeSwitcher>();

        mover.StartAnimation();

        SingletonGameBuilder builder = SingletonGameBuilder.Instance;
        //StartCoroutine(moveAuto(builder.aiAutoMoveTime));
        //StartCoroutine(defenderAuto(builder.aiAutoDefenderTime));
        //StartCoroutine(thrownAuto(builder.aiAutoThrownTime));
        mover.StartAnimation();
    }

    private void OnDisable()
    {
        mover.StopAnimation();
        setSomeLeader();
    }




    // Update is called once per frame
    void Update()
    {
        //detect side
        bool oldBallInMySide = ballInMySide;
        if (meLeftSide)
            ballInMySide = ball.transform.position.x < 0;
        else
            ballInMySide = ball.transform.position.x > 0;

        if (oldBallInMySide == true && ballInMySide == false)
            onBallExit();
        if (oldBallInMySide == false && ballInMySide == true)
            onBallEnter();





        switch (state)
        {
            case State.defense:
                UpdateDefense();
                break;
            case State.attack:
                UpdateAttack();
                break;
        }
    }

    private void UpdateDefense()
    {
        moveTo(startPosition, distanceDestination);
    }

    private void UpdateAttack()
    {
         moveTo(ball.transform.position, distanceCatch);
    }

    private void ArrivedDestinationDefense()
    {

    }

    private void ArrivedDestinationAttack()
    {      
        modeSwitcher.Defender();
    }

    private void setSomeLeader()
    {
        if (meLeftSide)
            for (int i = 0; i < charactersLeft.Count; i++)
            {
                CharacterAutoMover c = (CharacterAutoMover)charactersLeft[i];
                if (c && c.enabled)
                {
                    c.setMeLeader();
                    break;
                }
            }
        else
            for (int i = 0; i < charactersRight.Count; i++)
            {
                CharacterAutoMover c = (CharacterAutoMover)charactersRight[i];
                if (c && c.enabled)
                {
                    c.setMeLeader();
                    break;
                }
            }

    }
    private void setMeLeader()
    {
        if (meLeftSide)
            for (int i = 0; i < charactersLeft.Count; i++)
                ((CharacterAutoMover)charactersLeft[i]).iLeader = (i == myIndex);
        else
            for (int i = 0; i < charactersRight.Count; i++)
                ((CharacterAutoMover)charactersRight[i]).iLeader = (i == myIndex);

        if(ballInMySide)
            state = State.attack;



    }

    private void moveTo(Vector3 pos, float dis)
    {
        gizmosDes = pos;

        bool oldArrivedDestination = ArrivedDestination;
        if (Vector2.Distance(transform.position, pos) > dis)
        {
            ArrivedDestination = false;
            Vector3 direction = pos - transform.position;

            up = direction.y > 0;
            left = direction.x < -0;
            down = direction.y < -0;
            right = direction.x > 0;

            //Debug.Log(up+ " " + left + " " + down + " " + right);
            mover.move(up, left, down, right);
        }
        else
        {
            ArrivedDestination = true;
            mover.move(false, false, false, false);
        }

        if (oldArrivedDestination == false && ArrivedDestination == true)
            switch (state)
            {
                case State.defense:
                    ArrivedDestinationDefense();
                    break;
                case State.attack:
                    ArrivedDestinationAttack();
                    break;
            }


    }

    private void onBallExit()
    {
        state = State.defense;
    }

    private void onBallEnter()
    {
        if (iLeader)
            state = State.attack;
    }

    public void onCatchBall(){     
        if(meLeftSide)
            mover.move(false, false, false, true);
        else
             mover.move(false, true, false, false);
        modeSwitcher.Thrown();        

    }





}