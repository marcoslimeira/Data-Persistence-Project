using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text perfectScore;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    public static MainManager Instance;
    public string playerName;

    




 

    // Start is called before the first frame update
    void Start()
    {
        

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }

        playerName = MenuManager.Instance.playerName;
        perfectScore.GetComponent<Text>().text = "Best Score :" + MenuManager.Instance.majorRankedPlayer + ": " + MenuManager.Instance.majorScore;
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(0);
            }

            else if (Input.GetKeyDown(KeyCode.R))
            {
                MainMenu();
            }
        }

        
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";

        if(m_Points > MenuManager.Instance.majorScore)
        {
            MenuManager.Instance.majorScore = m_Points;
            MenuManager.Instance.majorRankedPlayer = playerName;
            perfectScore.GetComponent<Text>().text = "Best Score :" + playerName + ": " + m_Points;
        }
    }

    public void GameOver()
    {
        m_GameOver = true;
        GameOverText.SetActive(true);

    }

    class SaveData
    {
        public int saveScore;
        public string saveName;
    }

    public void SaveNameScore()
    {
        // Vamos detalhar esse novo método em sequência.Primeiro,
        // você criou uma nova instância dos dados salvos e preencheu
        // seu membro da classe de cores da equipe com a variável
        // TeamColor salva no MainManager:

        SaveData data = new SaveData();
        data.saveName = MenuManager.Instance.majorRankedPlayer;
        data.saveScore = MenuManager.Instance.majorScore;

        // Em seguida, você transformou essa instância em JSON com JsonUtility.ToJson

        string json = JsonUtility.ToJson(data);


        //Finalmente, você usou o método especial File.WriteAllText para gravar uma string em um arquivo:

        //Para salvar em disco precisamos usar a biblioteca do sistema de entrada e saída - Se não tiver "File" dará erro.
        
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        //O primeiro parâmetro é o caminho para o arquivo.
        //Você usou um método do Unity chamado Application.persistentDataPath que
        //lhe dará uma pasta onde você pode salvar dados que sobreviverão entre a
        //reinstalação ou atualização do aplicativo e anexar a ele o nome de arquivo savefile.json.

        //Observação: a API Unity Scripting lista os caminhos reais por plataforma .

        //O segundo parâmetro é o texto que você deseja escrever nesse arquivo — neste caso, seu JSON!
    }

    
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
        SaveNameScore();
    }
}
