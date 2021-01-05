using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameStarter : MonoBehaviour
{
    [SerializeField] int leftNumCharacters = 5;
    [SerializeField] TeamType leftTeamType = TeamType.manual;
    [SerializeField] int rightNumCharacters = 5;
     [SerializeField] TeamType rightTeamType = TeamType.manual;
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(click);
    }

    void click(){
        SingletonGameBuilder gameBuilder = SingletonGameBuilder.Instance;
        gameBuilder.teamLeft.numCharacters = leftNumCharacters;
        gameBuilder.teamLeft.teamType = leftTeamType;
        gameBuilder.teamRight.numCharacters = rightNumCharacters;
        gameBuilder.teamRight.teamType = rightTeamType;

        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
