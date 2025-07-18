using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStartController : MonoBehaviour
{
    public Text ScoreBoard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        Player.PlayerHeath = 3;
        Player.Score = 0;


        ListTopScore listTopScore = JsonUtility
            .FromJson<ListTopScore>(PlayerPrefs.GetString("TopScore"));

        if(listTopScore == null || listTopScore.value.Length ==0) { return; }

        string scoreText= "";
        for(int i = 0;i < listTopScore.value.Length; i++)
        {
            scoreText += $"Top {i + 1}: {listTopScore.value[i]}\n";
        }
        ScoreBoard.text = scoreText;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
