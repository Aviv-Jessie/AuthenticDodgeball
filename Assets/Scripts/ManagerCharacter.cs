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
    private Dictionary<GameObject, ArrayList> characterStatus = new Dictionary<GameObject, ArrayList>();
    //spawn in start position
    private Dictionary<GameObject, Vector3> startPosition = new Dictionary<GameObject, Vector3>();

    private GameObject thrower;

    private int indexLeftCaptivesPositions = 0;
    private int indexReftCaptivesPositions = 0;


    // Start is called before the first frame update
    void Start()
    {
        //insert empty list for rightCharacterStatus
        for (int i = 0; i < rightCharactersNumber; i++)
        {
            startPosition.Add(rightCharacters[i],rightCharacters[i].transform.position);
            characterStatus.Add(rightCharacters[i],new ArrayList());
        }
         //insert empty list for rightCharacterStatus
        for (int i = 0; i < leftCharactersNumber; i++)
        {
            startPosition.Add(leftCharacters[i],leftCharacters[i].transform.position);
            characterStatus.Add(leftCharacters[i],new ArrayList());
        }
    }

    public void setThrower(GameObject character){
        thrower = character;
    }

    public void disqualification(GameObject character){
        if(thrower == null)
            return;

        Debug.Log(character.name + " Disqualification by " + thrower.name);

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
        //move object to captive
        Transform capTransform = leftCaptivesPositions[indexLeftCaptivesPositions++].transform;
        character.transform.position = capTransform.position;
        
        //free Captives
        ArrayList capToFree = characterStatus[character];
        foreach (GameObject c in capToFree)
        {
            c.transform.position = startPosition[c];
            characterStatus[c] = new ArrayList();
            indexReftCaptivesPositions--;
        }

        //mark is Captive
        characterStatus[character] = null;
        //mark thrower
        characterStatus[thrower].Add(character);
        
    }
    private void DisqualificationRight(GameObject character){  
        //move object to captive
        Transform capTransform = rightCaptivesPositions[indexReftCaptivesPositions++].transform;
        character.transform.position = capTransform.position;
        
        //free Captives
        ArrayList capToFree = characterStatus[character];
        foreach (GameObject c in capToFree)
        {
            c.transform.position = startPosition[c];
            characterStatus[c] = new ArrayList();
            indexLeftCaptivesPositions--;
        }

        //mark is Captive
        characterStatus[character] = null;
        //mark thrower
        characterStatus[thrower].Add(character);    
    }
}
