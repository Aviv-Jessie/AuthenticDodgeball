﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TemporarySceneChooser : MonoBehaviour{
    //https://docs.unity3d.com/2018.3/Documentation/ScriptReference/UI.Button-onClick.html
    public Button StartGame;

    // Start is called before the first frame update
    void Start(){
        //Calls the TaskOnClick/TaskWithParameters/ButtonClicked method when you click the Button
        StartGame.onClick.AddListener(StartGameMethod);
    }

    void StartGameMethod(){
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}