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


        maxRank.GetComponent<Text>().text = "O jogador " + inputName + " � o melhor com " + inputScore + " pontos";
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
        // Este m�todo � uma revers�o do m�todo SaveColor:
        // Ele usa o m�todo File.Exists para verificar se existe um arquivo .json.
        // Caso contr�rio, nada foi salvo, portanto, nenhuma a��o adicional � necess�ria.
        // Se o arquivo existir, o m�todo ler� seu conte�do com File.ReadAllText :

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            //Em seguida, ele fornecer� o texto resultante para JsonUtility.FromJson para transform�-lo novamente em uma inst�ncia SaveData:

            SaveData data = JsonUtility.FromJson<SaveData>(json);


            // Por fim, ele definir� o TeamColor para a cor salva nesse SaveData:

            inputName = data.saveName;
            inputScore = data.saveScore;
        }
    }
}
