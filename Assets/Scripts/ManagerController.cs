using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterUnit
{
    [Tooltip("Componet enable when character can move")]
    public CharacterManualMover moverComponet;
    [Tooltip("key to enable the Componet")]
    public KeyCode key;
}
public class ManagerController : MonoBehaviour
{
    [SerializeField] CharacterUnit[] characterUnits = null;
    // Start is called before the first frame update
    void Start()
    {
        if(characterUnits == null || characterUnits.Length == 0)
        {
            Debug.LogError("characterUnits can't be null or zero");
        }
    }
    // Update is called once per frame
    void Update()
    {
         for (int i = 0; i < characterUnits.Length; i++)
            if(Input.GetKeyDown(characterUnits[i].key))
                enableOneCharacter(i);
    }

    private void enableOneCharacter(int index){
        for (int i = 0; i < characterUnits.Length; i++)
            if(i == index)
                characterUnits[i].moverComponet.enabled = true;
            else
                characterUnits[i].moverComponet.enabled = false;
        
    }
}
