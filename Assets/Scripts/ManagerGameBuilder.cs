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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
