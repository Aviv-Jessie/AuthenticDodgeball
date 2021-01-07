using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

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

    private void PointerPressedHandler(object sender, System.EventArgs e)
    {
        mover.StartAnimation();
    }

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

    private void PointerReleasedHandler(object sender, System.EventArgs e)
    {
        mover.StopAnimation();
    }
}