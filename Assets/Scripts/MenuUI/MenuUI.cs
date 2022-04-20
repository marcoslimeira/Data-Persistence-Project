using System;
using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif



[DefaultExecutionOrder(1000)]
public class MenuUI : MonoBehaviour
{

    public static MenuUI Instance;
    public string playerName;
    public GameObject textBox;


    // Start is called before the first frame update

   


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NewName()
    {
    
    }

    public void StartNew()
    {
        SceneManager.LoadScene(0);

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

    
}
