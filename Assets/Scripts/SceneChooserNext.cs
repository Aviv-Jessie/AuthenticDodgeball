using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChooserNext : MonoBehaviour
{
    
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(click);
        sceneName = SingletonGameBuilder.Instance.nextScene;

        Text text = GetComponentInChildren<Text>();
        text.text = SingletonGameBuilder.Instance.buttonText;
    }

   
    void click()
    {
          SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
