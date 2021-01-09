using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 [RequireComponent(typeof(ManagerCharacter))]
public class ManagerGameBuilder : MonoBehaviour
{
    [SerializeField] public TMP_Text tutorial = null;
    // Start is called before the first frame update
    void Start()
    {
        SingletonGameBuilder gameBuilder = SingletonGameBuilder.Instance;

        ManagerCharacter managerCharacter = GetComponent<ManagerCharacter>();
        managerCharacter.rightCharactersNumber = gameBuilder.teamRight.numCharacters;
        managerCharacter.leftCharactersNumber = gameBuilder.teamLeft.numCharacters;
        managerCharacter.enabled = true;


        
        if(!System.String.IsNullOrEmpty(gameBuilder.textTutorial))
        {
            tutorial.gameObject.SetActive(true);
            tutorial.text = gameBuilder.textTutorial;
        }       
        Debug.Log("area: "+gameBuilder.area);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
