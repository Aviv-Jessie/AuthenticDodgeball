using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

//https://github.com/TouchScript/TouchScript/wiki/Gestures
[RequireComponent(typeof(CharacterManualMover))]
public class CharacterDragAndDrop : MonoBehaviour
{
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

    private void PointerPressedHandler(object sender, System.EventArgs e)
    {
        mover.StartAnimation();
    }

    private void PointerUpdatedHandler(object sender, System.EventArgs e)
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        bool up = direction.y > 0;
        bool left = direction.x < 0;
        bool down = direction.y < 0;
        bool right = direction.x > 0;

        mover.move(up, left, down, right);

    }

    private void PointerReleasedHandler(object sender, System.EventArgs e)
    {
        mover.StopAnimation();
    }
}