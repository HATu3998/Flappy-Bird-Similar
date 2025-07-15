using UnityEngine;

public class BackgroundRun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.material.mainTextureOffset = new Vector2(Time.time * 0.2f, 0);
    }
}
