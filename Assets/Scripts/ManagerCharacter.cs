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
    [SerializeField] public int rightCharactersNumber = 5;

    [Tooltip("left captives positions")]
    [SerializeField] Transform[] leftCaptivesPositions = null;
    [Tooltip("players in the left")]
    [SerializeField] GameObject[] leftCharacters = null;
    [Tooltip("number player play in left team")]
    [SerializeField] public int leftCharactersNumber = 5;

    [SerializeField] public GameObject CanvesLeftWin = null;
    [SerializeField] public GameObject CanvesRightWin = null;

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
            startPosition.Add(rightCharacters[i], rightCharacters[i].transform.position);
            characterStatus.Add(rightCharacters[i], new ArrayList());
        }
        //insert empty list for rightCharacterStatus
        for (int i = 0; i < leftCharactersNumber; i++)
        {
            startPosition.Add(leftCharacters[i], leftCharacters[i].transform.position);
            characterStatus.Add(leftCharacters[i], new ArrayList());
        }
        //disable non play charter
        for (int i = rightCharactersNumber; i < rightCharacters.Length; i++)
        {
            rightCharacters[i].SetActive(false);
        }
        for (int i = leftCharactersNumber; i < leftCharacters.Length; i++)
        {
            leftCharacters[i].SetActive(false);
        }
    }

    // checks if some character is disqualification or not. 
    public bool isDisqualification(GameObject character){
        if(characterStatus.ContainsKey(character))
            return ( characterStatus[character] == null );
        else
            return false;
    }

    public void setThrower(GameObject character)
    {
        thrower = character;
    }

    public void disqualification(GameObject character)
    {
        if (thrower == null)
            return;

        bool throwerIsRight = isRightTeam(thrower);
        bool characterIsRight = isRightTeam(character);
        if (throwerIsRight == characterIsRight)//character disqualification character from same team.
            return;

        Debug.Log(thrower.name + " Disqualification " + character.name);

        if (characterIsRight)
            DisqualificationRight(character);
        else
            DisqualificationLeft(character);

    }

    private void DisqualificationLeft(GameObject character)
    {
        //move object to captive
        SingletonGameBuilder singleton = SingletonGameBuilder.Instance;
        Transform capTransform = leftCaptivesPositions[indexLeftCaptivesPositions++].transform;
        character.transform.position = capTransform.position;
        character.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
        character.GetComponent<CharacterManualMover>().enabled = false;
        character.GetComponent<CharacterDragAndDrop>().enabled = false;
        character.GetComponent<CharacterAutoMover>().enabled = false;

        //free Captives
        ArrayList capToFree = characterStatus[character];
        foreach (GameObject c in capToFree)
        {
            c.transform.position = startPosition[c];
            if (singleton.teamRight.teamType == SingletonGameBuilder.TeamType.manual)
                c.GetComponent<CharacterDragAndDrop>().enabled = true;
            else
                c.GetComponent<CharacterAutoMover>().enabled = true;

            //ManualMover by manager controller
            characterStatus[c] = new ArrayList();
            indexReftCaptivesPositions--;

        }

        //mark is Captive
        characterStatus[character] = null;
        //mark thrower
        characterStatus[thrower].Add(character);

        //chack if right win
        bool win = true;
        for (int i = 0; i < leftCharactersNumber; i++)
            if (characterStatus[leftCharacters[i]] != null)
                win = false;

        if (win)
            CanvesRightWin.SetActive(true);


    }
    private void DisqualificationRight(GameObject character)
    {
        //move object to captive
        SingletonGameBuilder singleton = SingletonGameBuilder.Instance;
        Transform capTransform = rightCaptivesPositions[indexReftCaptivesPositions++].transform;
        character.transform.position = capTransform.position;
        character.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        character.GetComponent<CharacterManualMover>().enabled = false;
        character.GetComponent<CharacterDragAndDrop>().enabled = false;
        character.GetComponent<CharacterAutoMover>().enabled = false;

        //free Captives
        ArrayList capToFree = characterStatus[character];
        foreach (GameObject c in capToFree)
        {
            c.transform.position = startPosition[c];
            if (singleton.teamLeft.teamType == SingletonGameBuilder.TeamType.manual)
                c.GetComponent<CharacterDragAndDrop>().enabled = true;
            else
                c.GetComponent<CharacterAutoMover>().enabled = true;
            characterStatus[c] = new ArrayList();
            indexLeftCaptivesPositions--;
        }

        //mark is Captive
        characterStatus[character] = null;
        //mark thrower
        characterStatus[thrower].Add(character);

        //chack if left win
        bool win = true;
        for (int i = 0; i < rightCharactersNumber; i++)
            if (characterStatus[rightCharacters[i]] != null)
                win = false;

        if (win)
            CanvesLeftWin.SetActive(true);
    }

    private bool isRightTeam(GameObject character)
    {
        for (int i = 0; i < rightCharacters.Length; i++)
        {
            if (character == rightCharacters[i])
            {
                return true;
            }
        }
        return false;
    }
}
