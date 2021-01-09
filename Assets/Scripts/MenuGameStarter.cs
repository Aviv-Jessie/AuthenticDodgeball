using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameStarter : MonoBehaviour
{
    [SerializeField] int leftNumCharacters = 5;
    [SerializeField] SingletonGameBuilder.TeamType leftTeamType = SingletonGameBuilder.TeamType.manual;
    [SerializeField] int rightNumCharacters = 5;
    [SerializeField] SingletonGameBuilder.TeamType rightTeamType = SingletonGameBuilder.TeamType.manual;

    [SerializeField] string area = "groundBeige_white";
    [SerializeField] string textTutorial = "";

    [SerializeField] string buttonText = "main menu";
    [SerializeField] string nextScene = "MainMenu";
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(click);
    }

    void click()
    {
        SingletonGameBuilder gameBuilder = SingletonGameBuilder.Instance;
        gameBuilder.teamLeft.numCharacters = leftNumCharacters;
        gameBuilder.teamLeft.teamType = leftTeamType;
        gameBuilder.teamRight.numCharacters = rightNumCharacters;
        gameBuilder.teamRight.teamType = rightTeamType;

        gameBuilder.area = area;
        gameBuilder.textTutorial = textTutorial;
        gameBuilder.buttonText = buttonText;
        gameBuilder.nextScene = nextScene;

        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
