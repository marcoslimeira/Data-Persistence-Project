using System;
using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUI : MonoBehaviour

    
{

    public static MenuUI Instance;
    public GameObject textBox;
    public GameObject maxRank;
    public string inputName;
    public int inputScore;
    


    // Start is called before the first frame update
    void Start()
    {
        inputName = MenuManager.Instance.majorRankedPlayer;
        inputScore = MenuManager.Instance.majorScore;
        
        
        maxRank.GetComponent<Text>().text = "O jogador " + inputName + " é o melhor com " + inputScore + " pontos";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartNew()
    {
        

        SceneManager.LoadScene(0);
        
        GetPlayerName();

    }


    public void Exit()
    {
        //   MainManager.Instance.SaveColor();

#if UNITY_EDITOR

        EditorApplication.ExitPlaymode();

#else
        Application.Quit();

#endif
    }

    public void GetPlayerName()
    {

     inputName =  textBox.GetComponent<Text>().text;
        MenuManager.Instance.playerName = inputName;
    }

}
