using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Gravity = -15f;
    public float strength = 7f;
    Vector3 direction;
    public Text scoreText;
    public Text gameStatus;


    public static int PlayerHeath = 3;
    public Slider heathBar;

   public static int Score = 0;
    void Start()
    {
        heathBar.value = PlayerHeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale == 0)
            {
                SceneManager.LoadScene("SceneStart");
            }
            direction = Vector3.up * strength;
        }


        direction.y += Gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Va chạm với: " + col.gameObject.tag);
        if (col.CompareTag("Point"))
        {
            Score++;
            scoreText.text = "Score :" + Score;
        }

        //if (col.gameObject.name.Contains("log"))
        //{
            
        //}
        else if (col.CompareTag("Obstacle"))
        {
            PlayerHeath--;
            if (PlayerHeath <= 0)
            {
                Time.timeScale = 0;
                heathBar.value = PlayerHeath;
                gameStatus.gameObject.SetActive(true);
                SaveScoreIfReachTop();
            }
            else {
                SceneManager.LoadScene("SampleScene");
            }
                 
        }
       
    }

    private void SaveScoreIfReachTop()
    {
        string jsonListScore = PlayerPrefs.GetString("TopScore");
        ListTopScore listTopScore = JsonUtility.FromJson<ListTopScore>(jsonListScore);

        if(listTopScore == null || listTopScore.value.Length == 0)
        {
            listTopScore = new();
        }

     listTopScore.value=   listTopScore.value.Append(Score).ToArray(); //tu dong tang do dai mang va them gia tri vao cuoi mang
        Array.Sort(listTopScore.value);   
        Array.Reverse(listTopScore.value);
        Array.Resize(ref listTopScore.value, 3); //phan tu ngoai top 3 se bi xoa

        PlayerPrefs.SetString("TopScore", JsonUtility.ToJson(listTopScore));
        PlayerPrefs.Save();
    }
}
