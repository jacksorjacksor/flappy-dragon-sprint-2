using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public Sprite[] dragonSpriteArray;
    float bounds = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        Debug.Log(pos);
    }

    // Update is called once per frame
    void Update()
    {
        // MOVEMENT
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = Vector2.up;
            spriteRenderer.sprite = dragonSpriteArray[0];
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = Vector2.down;
            spriteRenderer.sprite = dragonSpriteArray[2];
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            spriteRenderer.sprite = dragonSpriteArray[1];
        }
  
        // KEEP WITHIN BOUNDS
        if(transform.position.y > bounds) 
        {
            transform.position = new Vector2(transform.position.x, 0.75f);
        }
        if (transform.position.y < -1* bounds)
        {
            transform.position = new Vector2(transform.position.x, -1 * bounds);
        }



    }
}
