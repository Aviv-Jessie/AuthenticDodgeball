﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;

/*
 *  this class is controller to the manual player, (not the auto player- the computer).
 *  with the option of "click" 
 */

public class ControllerManual : MonoBehaviour
{
    enum Mod { throwBall, defendBall }
    [Tooltip("players in the team")]
    [SerializeField] CharacterModeSwitcher[] characterModeSwitchers = null;
    [Tooltip("key to catch a ball")]
    [SerializeField] KeyCode keyCode = KeyCode.P;
    [Tooltip("SwitchToWithoutBallPlayer if we in throw mode and SwitchToDefenderPlayer if we on Defend mode ")]
    [SerializeField] Mod mod = Mod.throwBall;
    // Start is called before the first frame update

    private void OnEnable()
    {
        GetComponent<MetaGesture>().PointerPressed += PointerPressedHandler;
    }

    private void OnDisable()
    {
        GetComponent<MetaGesture>().PointerPressed -= PointerPressedHandler;
    }

    void Start()
    {
        if (characterModeSwitchers == null || characterModeSwitchers.Length == 0)
        {
            Debug.LogError("characterUnits can't be null or zero");
        }
    }
    // Update is called once per frame
    // check the current mode and switch to the other if the player is enable.
    void Update()
    {
        if (Input.GetKeyDown(keyCode))
            doAction();
    }

    // the "update" can be called if you click on the keyboard or mouse.
    private void doAction()
    {
        foreach (CharacterModeSwitcher character in characterModeSwitchers)
            if (character.gameObject.activeSelf)             // if the character is exist - gameobject active..
                if (mod == Mod.throwBall)
                    character.Thrown();
                else//mod == Mod.defendBall
                    character.Defender();
    }

    private void PointerPressedHandler(object sender, System.EventArgs e)
    {
        doAction();
    }
}
