using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [RequireComponent(typeof(ManagerCharacter))]
public class ManagerGameBuilder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SingletonGameBuilder gameBuilder = SingletonGameBuilder.Instance;

        ManagerCharacter managerCharacter = GetComponent<ManagerCharacter>();
        managerCharacter.rightCharactersNumber = gameBuilder.teamRight.numCharacters;
        managerCharacter.leftCharactersNumber = gameBuilder.teamLeft.numCharacters;
        managerCharacter.enabled = true;

        //TODO add Tutorial and area.
        Debug.Log("Tutorial: "+gameBuilder.textTutorial);
        Debug.Log("area: "+gameBuilder.area);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
