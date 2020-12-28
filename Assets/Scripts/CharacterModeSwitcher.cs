﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this class represents the modes of the characters.
 * temporary we use a images, at the next assignment we will change it to animations.
 */


[RequireComponent(typeof(CharacterSpawnerBall))]
public class CharacterModeSwitcher : MonoBehaviour
{
     [Tooltip("sprite spawners with ball")]
    [SerializeField] Sprite spriteWithBall = null;
    [Tooltip("sprite spawners without ball")]
    [SerializeField] Sprite spriteWithoutBall = null;
    [Tooltip("sprite spawners defender")]
    [SerializeField] Sprite spriteDefender = null;
    [Tooltip("set the time to defend")]
    [SerializeField] float timeToWait = 1f;
    [Tooltip("to trigger with ball")]
    [SerializeField] string ballTag = "ball";
    [Tooltip("balls velocity to disqualification")]
    [SerializeField] float ballVelocity = 1.0f;

    private SpriteRenderer show;
    public enum PlayerMode {withBall,withoutBall,defender};
    private PlayerMode playerMode;

    // Start is called before the first frame update
    void Start()
    {
        show = GetComponent<SpriteRenderer>();
        playerMode = PlayerMode.withoutBall;
    }

    public CharacterModeSwitcher.PlayerMode GetPlayerMode()
    {
        return playerMode;
    }

    public void SwitchToDefenderPlayer()
    {
        if(playerMode == PlayerMode.withoutBall)    //check if we can change the player mode to defender.
        {
            playerMode = PlayerMode.defender;
            show.sprite = spriteDefender;
            StartCoroutine(TimerToDisableDefender());
        }
    }

    public void SwitchToWithBallPlayer(GameObject ball)
    {
        if (playerMode == PlayerMode.defender)    //check if we can change the player mode to with ball.
        {
            playerMode = PlayerMode.withBall;
            show.sprite = spriteWithBall;
            Destroy(ball);
        }else{
            disqualification(ball);
        }
    }

    public void SwitchToWithoutBallPlayer()
    {
            if(playerMode == PlayerMode.withBall) // we need thrown the ball
            {
                GetComponent<CharacterSpawnerBall>().spawnObject();
            }
            playerMode = PlayerMode.withoutBall;
            show.sprite = spriteWithoutBall;
    }

    private void OnTriggerEnter2D(Collider2D other){ 
        if (other.tag == ballTag) //other is ball
        {
            SwitchToWithBallPlayer(other.gameObject);
        }
    }
    public void disqualification(GameObject ball){
        Rigidbody2D ballBody = ball.GetComponent<Rigidbody2D>();
        // if the ball moving very slow- the player will not disqualification.
        // if the ball moving fast- meanig bigger then "ballVelocity"- disqualification.
        if (ballBody.velocity.x >= ballVelocity || ballBody.velocity.y >= ballVelocity || ballBody.velocity.x <= -ballVelocity || ballBody.velocity.y <= -ballVelocity)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            // the player is go and take automatically the ball
            SwitchToDefenderPlayer();
            SwitchToWithBallPlayer(ball);
        }
    }


    private IEnumerator TimerToDisableDefender()
    {
        yield return new WaitForSeconds(timeToWait);    // wait "X" time (1sec default), to wait before change mode. 
        if(playerMode == PlayerMode.defender)
        {
            SwitchToWithoutBallPlayer();
        }
    }
}
