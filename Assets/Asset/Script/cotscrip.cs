using UnityEngine;

public class cotscrip : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f;
   // float PosLimit;

    void Start()
    {
     //   PosLimit = Camera.main.ScreenToWorldPoint(Vector3.zero).x  ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(Time.deltaTime * speed , 0, 0);
        //if(transform.position.x < PosLimit)
        //{
        //    Destroy(gameObject);
        //}
    }

    private void OnCollisionEnter2D(Collision2D col )
    {
        if (col.gameObject.CompareTag("delObject"))
        {
            Destroy(gameObject);
        }
    }
}
