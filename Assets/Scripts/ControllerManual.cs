using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManual : MonoBehaviour
{
    enum Mod{throwBall,defendBall}
    [Tooltip("player in the team")]
    [SerializeField] CharacterModeSwitcher[] characterModeSwitchers = null;
    [Tooltip("key to catch ")]
    [SerializeField] KeyCode keyCode = KeyCode.P;
    [Tooltip("SwitchToWithoutBallPlayer if we in throw mode and SwitchToDefenderPlayer if we on Defend mode ")]
    [SerializeField] Mod mod = Mod.throwBall;
     // Start is called before the first frame update
    void Start()
    {
        if(characterModeSwitchers == null || characterModeSwitchers.Length == 0)
        {
            Debug.LogError("characterUnits can't be null or zero");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))
            foreach(CharacterModeSwitcher character in characterModeSwitchers)
                if(character.gameObject.activeSelf)
                    if(mod == Mod.throwBall)
                        character.SwitchToWithoutBallPlayer();
                    else
                        character.SwitchToDefenderPlayer();
        
    }
}
