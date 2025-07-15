using System.Collections;
using UnityEngine;

public class GameObjectSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Log;
    void Start()
    {
        StartCoroutine(SpawnLog());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private IEnumerator SpawnLog()
    {
        while (true)
        {
            GameObject newLog = Instantiate(Log, transform.position, new Quaternion());
            Vector3 positit = newLog.transform.position;
            positit.y = Random.Range(-4.8f, -2.11f);
            newLog.transform.position = positit;

            yield return new WaitForSeconds(1);
        }
    }
}
