using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This class represents the character keycode (the button that you need to click to enable the mover component ) and the mover component.
 */

[System.Serializable]
public class CharacterUnit
{
    [Tooltip("Component enable when we want the character can move")]
    public CharacterManualMover moverComponet;
    // the numbers to choose characters
    [Tooltip("key to enable the mover Component ")]
    public KeyCode key;
}

public enum Side{left,right};

/*
 * This class represents the game manager controller, this script manage the player characters,
 * update the current character and enable them to move.
 */
 [RequireComponent(typeof(ManagerCharacter))]
public class ManagerController : MonoBehaviour
{
    [SerializeField] Side side = Side.left;
    [SerializeField] CharacterUnit[] characterUnits = null;
    private ManagerCharacter managerCharacter;
    // Start is called before the first frame update
    void Start()
    {
        if(characterUnits == null || characterUnits.Length == 0)
        {
            Debug.LogError("characterUnits can't be null or zero");
        }
        managerCharacter = GetComponent<ManagerCharacter>();
        SingletonGameBuilder gameBuilder = SingletonGameBuilder.Instance;
        if(side == Side.left)
            if(gameBuilder.teamLeft.teamType == SingletonGameBuilder.TeamType.ai)
                StartAi();
            else
                StartManuel();
        else
            if(gameBuilder.teamRight.teamType == SingletonGameBuilder.TeamType.ai)
                StartAi();
            else
                StartManuel();     
    }

    private void StartAi(){
        for (int i = 0; i < characterUnits.Length; i++){
            CharacterAutoMover characterAutoMover = characterUnits[i].moverComponet.gameObject.GetComponent<CharacterAutoMover>();
            CharacterDragAndDrop characterDragAndDrop = characterUnits[i].moverComponet.gameObject.GetComponent<CharacterDragAndDrop>();
            if(characterAutoMover)
                characterAutoMover.enabled = true;
            if(characterDragAndDrop)
                characterDragAndDrop.enabled = false;
        }            
        enabled = false;
    }

    private void StartManuel(){         
        enableOneCharacter(0);
    }

    // Update is called once per frame
    void Update()
    {
        // check which character to move
         for (int i = 0; i < characterUnits.Length; i++)
            if(Input.GetKeyDown(characterUnits[i].key))
                enableOneCharacter(i);
    }

    // this is the only character that move and controll. 
    private void enableOneCharacter(int index){
        // enabling one character at the time.
        for (int i = 0; i < characterUnits.Length; i++){
            GameObject c = characterUnits[i].moverComponet.gameObject;
            if(!managerCharacter.isDisqualification(c))
                if(i == index)
                    characterUnits[i].moverComponet.enabled = true;
                else
                    characterUnits[i].moverComponet.enabled = false;
        }
        
    }
}
