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

    [SerializeField] float aiAutoMoveTime = 0.05f;
    [SerializeField] float aiAutoDefenderTime = 0.25f;
    [SerializeField] float aiAutoThrownTime = 0.5f;

    [SerializeField] string area = "groundBeige_white";
    [SerializeField] string textTutorial = "";
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

        gameBuilder.aiAutoMoveTime = aiAutoMoveTime;
        gameBuilder.aiAutoDefenderTime = aiAutoDefenderTime;
        gameBuilder.aiAutoThrownTime = aiAutoThrownTime;

        gameBuilder.area = area;
        gameBuilder.textTutorial = textTutorial;

        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
