using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float Gravity = -15f;
    public float strength = 7f;
    Vector3 direction;
    void Start()
    {
        
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
}
