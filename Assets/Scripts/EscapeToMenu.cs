using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * That class uses to go to menu by click "Escape"
 */

public class EscapeToMenu : MonoBehaviour
{

    [Tooltip("key to exit to menu")]
    [SerializeField] KeyCode Escape = KeyCode.Escape;
    public string nextScene = "MainMenu";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Escape))
        {
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        }
    }
}
