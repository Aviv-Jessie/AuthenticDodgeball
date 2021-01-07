using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        //now if i in ledt side or right side.
        meLeftSide = transform.position.x < 0;
        state = State.defense;
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
    }


    // Update is called once per frame
    void Update()
    {
        //detect 
        if (meLeftSide)
            ballInMySide = ball.transform.position.x < 0;
        else
            ballInMySide = ball.transform.position.x > 0;

        //go to ball if is in my side
         if (state == State.defense)
                if (ballInMySide)
                {
                    Vector3 direction = ball.transform.position - transform.position;

                    up = direction.y > 0;
                    left = direction.x < -0;
                    down = direction.y < -0;
                    right = direction.x > 0;
                }
                else
                {
                    up = false;
                    left = false;
                    down = false;
                    right = false;
                }

        mover.move(up, left, down, right);
    }

   



}
