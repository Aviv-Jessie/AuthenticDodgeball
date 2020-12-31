using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this class represents the modes of the characters.
 * temporary we use a images, at the next assignment we will change it to animations.
 */


[RequireComponent(typeof(Animator))]
public class CharacterModeSwitcher : MonoBehaviour
{
    [Tooltip("set the time to defend")]
    [SerializeField] float timeToWait = 1f;

    private Animator m_Animator;
    private bool haveBall;
    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
        haveBall = false;
    }

    public void Defender()
    {
        m_Animator.SetTrigger("Catch");
        StartCoroutine(DefenderTimr());

    }
    //call when ControllerManual thrown.
    public void Thrown()
    {
        CharacterCatcher characterCatcher = GetComponentInChildren<CharacterCatcher>();
        if(characterCatcher)//Component exist
        {
            bool ballThrownSuccess = characterCatcher.Thrown();
            if(ballThrownSuccess)
                  m_Animator.SetTrigger("Thrown");
        }
    }
    private IEnumerator DefenderTimr()
    {
        yield return new WaitForSeconds(timeToWait);
        if (!haveBall)
            m_Animator.SetTrigger("Thrown");

    }

    public void setHaveBall(bool haveBall)
    {
        this.haveBall = haveBall;
    }


}
