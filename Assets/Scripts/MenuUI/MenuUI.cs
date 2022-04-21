using System;
using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
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

        LoadNameScore();

        //inputName = MenuManager.Instance.majorRankedPlayer;
        //inputScore = MenuManager.Instance.majorScore;


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

        inputName = textBox.GetComponent<Text>().text;
        MenuManager.Instance.playerName = inputName;
    }

    class SaveData
    {
        public int saveScore;
        public string saveName;
    }

    public void LoadNameScore()
    {
        // Este método é uma reversão do método SaveColor:
        // Ele usa o método File.Exists para verificar se existe um arquivo .json.
        // Caso contrário, nada foi salvo, portanto, nenhuma ação adicional é necessária.
        // Se o arquivo existir, o método lerá seu conteúdo com File.ReadAllText :

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            //Em seguida, ele fornecerá o texto resultante para JsonUtility.FromJson para transformá-lo novamente em uma instância SaveData:

            SaveData data = JsonUtility.FromJson<SaveData>(json);


            // Por fim, ele definirá o TeamColor para a cor salva nesse SaveData:

            inputName = data.saveName;
            inputScore = data.saveScore;
        }
    }
}
