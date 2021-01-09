using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

/*
 * That class uses to enable the drag and drop option, for mobile touch or mouse play..
 */
//https://github.com/TouchScript/TouchScript/wiki/Gestures
[RequireComponent(typeof(CharacterManualMover))]
public class CharacterDragAndDrop : MonoBehaviour
{
    [SerializeField] float dis = 0.3f;
    private CharacterManualMover mover;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<CharacterManualMover>();
    }
    private void OnEnable()
    {
        GetComponent<MetaGesture>().PointerPressed += PointerPressedHandler;
        GetComponent<MetaGesture>().PointerUpdated += PointerUpdatedHandler;
        GetComponent<MetaGesture>().PointerReleased += PointerReleasedHandler;
    }

    private void OnDisable()
    {
        GetComponent<MetaGesture>().PointerPressed -= PointerPressedHandler;
        GetComponent<MetaGesture>().PointerUpdated -= PointerUpdatedHandler;
        GetComponent<MetaGesture>().PointerReleased -= PointerReleasedHandler;
    }

    // this method for the Pressed frame
    private void PointerPressedHandler(object sender, System.EventArgs e)
    {
        mover.StartAnimation();
    }

    // this method is for the whole frames that i drag the character.
    private void PointerUpdatedHandler(object sender, System.EventArgs e)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;

        if (Vector2.Distance(mousePosition, transform.position) > dis)
        {    
            bool up = direction.y > dis;
            bool left = direction.x < -dis;
            bool down = direction.y < -dis;
            bool right = direction.x > dis;
            mover.move(up, left, down, right);
        }
    }

    // this method is for released the touch.
    private void PointerReleasedHandler(object sender, System.EventArgs e)
    {
        mover.StopAnimation();
    }
}