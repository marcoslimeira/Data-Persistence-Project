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
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public GameObject textBox;
    public string playerName;



    private void Awake()
    {

        //You’ve just added a conditional statement to check whether or not Instance is null.
        //The very first time that you launch the Menu scene, no MainManager will have filled the Instance variable.
        //This means it will be null, so the condition will not be met,
        //and the script will continue as you previously wrote it.

        //However, if you load the Menu scene again later,
        //there will already be one MainManager in existence,
        //so Instance will not be null.In this case, the condition
        //is met: the extra MainManager is destroyed and the script exits there.

        //This pattern is called a singleton.
        //You use it to ensure that only a single instance of the MainManager can ever exist,
        //so it acts as a central point of access.    

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        //This first line of code stores “this”
        //in the class member Instance — the current instance of MainManager.
        //You can now call MainManager.
        //Instance from any other script(for example, the Unit script) and get a link to that
        //specific instance of it.You don’t need to have a reference to it,
        //like you do when you assign GameObjects to script properties in the Inspector.


        Instance = this;
        DontDestroyOnLoad(gameObject);


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void GetPlayerName()

    {


    }

}
