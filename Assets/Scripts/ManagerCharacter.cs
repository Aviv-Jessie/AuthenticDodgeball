using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCharacter : MonoBehaviour
{
    [Tooltip("right captives positions")]
    [SerializeField] Transform[] rightCaptivesPositions = null;
    [Tooltip("players in the right")]
    [SerializeField] GameObject[] rightCharacters = null;
    [Tooltip("number player play in right team")]
    [SerializeField] int rightCharactersNumber = 5;
    
    [Tooltip("left captives positions")]
    [SerializeField] Transform[] leftCaptivesPositions = null;
    [Tooltip("players in the left")]
    [SerializeField] GameObject[] leftCharacters = null;
    [Tooltip("number player play in left team")]
    [SerializeField] int leftCharactersNumber = 5;

    //HashMap hold for every Character list captives. emtpty list is zero captive. null meen the character it self captive.
    private Dictionary<GameObject, ArrayList> rightCharacterStatus = new Dictionary<GameObject, ArrayList>();
    //like rightCharacterStatus for left team
    private Dictionary<GameObject, ArrayList> leftCharacterStatus = new Dictionary<GameObject, ArrayList>();

    // Start is called before the first frame update
    void Start()
    {
        //insert empty list for rightCharacterStatus
        for (int i = 0; i < rightCharactersNumber; i++)
        {
            rightCharacterStatus.Add(rightCharacters[i],new ArrayList());
        }
         //insert empty list for rightCharacterStatus
        for (int i = 0; i < leftCharactersNumber; i++)
        {
            leftCharacterStatus.Add(rightCharacters[i],new ArrayList());
        }
    }

    public void disqualification(GameObject character){
        //checked if characters is in right team.
        for (int i = 0; i < rightCharacters.Length; i++)
        {
            if(character == rightCharacters[i]){
                DisqualificationRight(character);
                return;
            }
        }
        DisqualificationLeft(character);
    }

    private void DisqualificationLeft(GameObject character){
        Debug.Log("disqualification left character. is "+character.name);
        //TODO finde the thrower
    }
    private void DisqualificationRight(GameObject character){
        Debug.Log("disqualification right character. is "+character.name);
    }
}
