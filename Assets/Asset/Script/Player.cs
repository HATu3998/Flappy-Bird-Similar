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

    public static int PlayerHeath = 3;
    public Slider heathBar;

   public int score = 0;
    void Start()
    {
        heathBar.value = PlayerHeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
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
            score++;
            scoreText.text = "Score :" + score;
        }

        //if (col.gameObject.name.Contains("log"))
        //{
            
        //}
        else if (col.CompareTag("Obstacle"))
        {
            if(PlayerHeath <= 0)
            {
                Time.timeScale = 0;
            }
            PlayerHeath--;
            SceneManager.LoadScene("SampleScene");
        }
       
    }
}
