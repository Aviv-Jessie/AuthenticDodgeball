using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChooser : MonoBehaviour
{
    [SerializeField] string sceneName = "MainMenu";
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(click);
    }
    void click()
    {
          SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
