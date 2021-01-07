using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterManualMover))]
[RequireComponent(typeof(CharacterModeSwitcher))]
public class CharacterAutoMover : MonoBehaviour
{


    private CharacterManualMover mover;
    private CharacterModeSwitcher modeSwitcher;
    private bool up;
    private bool left;
    private bool down;
    private bool right;
    // Start is called before the first frame update

    private void OnEnable()
    {
        mover = GetComponent<CharacterManualMover>();
        mover.StartAnimation();

        modeSwitcher = GetComponent<CharacterModeSwitcher>();
        SingletonGameBuilder builder = SingletonGameBuilder.Instance;
        StartCoroutine(moveAuto(builder.aiAutoMoveTime));
        StartCoroutine(defenderAuto(builder.aiAutoDefenderTime));
        StartCoroutine(thrownAuto(builder.aiAutoThrownTime));
        mover.StartAnimation();
    }

    private void OnDisable()
    {
        mover.StopAnimation();
    }


    private IEnumerator moveAuto(float waitTime)
    {
        while (enabled)
        {

            int d = Random.Range(0, 4);
            up = (d == 0);
            left = (d == 1);
            down = (d == 2);
            right = (d == 3);
            yield return new WaitForSeconds(waitTime);

        }
    }

    private IEnumerator defenderAuto(float waitTime)
    {
        while (enabled)
        {
            yield return new WaitForSeconds(modeSwitcher.timeToWait + waitTime);
            modeSwitcher.Defender();
        }
    }

    private IEnumerator thrownAuto(float waitTime)
    {
        while (enabled)
        {
            yield return new WaitForSeconds(waitTime);
            modeSwitcher.Thrown();
        }
    }

    // Update is called once per frame
    void Update()
    {
        mover.move(up, left, down, right);
    }
}
