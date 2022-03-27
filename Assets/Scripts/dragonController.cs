using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Sprite[] dragonSpriteArray;
    float bounds = 0.75f;
    float gravity = 0.2f;
    public Animation dragonAnim;
    public GameObject fireballPrefab;
    public gameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = 0f;
    }

    public void ReadyToFly()
    {
        rb.gravityScale = gravity;
    }


    public void BackToStartingPosition()
    {
        // Put dragon back in starting place with 0
        transform.position = new Vector2(-0.888f, 0.444f);
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gamePlayActive)  { 
            // MOVEMENT
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
            
                rb.velocity = Vector2.up;
                spriteRenderer.sprite = dragonSpriteArray[0];
            
            }
            if (Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.velocity = Vector2.down;
                spriteRenderer.sprite = dragonSpriteArray[2];
            }
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                spriteRenderer.sprite = dragonSpriteArray[1];
            }
        }

        // KEEP WITHIN BOUNDS
        if (transform.position.y > bounds) 
        {
            transform.position = new Vector2(transform.position.x, bounds);
        }
        if (transform.position.y < -1* bounds)
        {
            transform.position = new Vector2(transform.position.x, -1 * bounds);
        }

        // FIREBALLS
        // Space bar (fireball <- Needs to be possible given a specific item
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.fireballReady)
        {
            GameObject fireball = (GameObject)Instantiate(fireballPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            
            fireball.GetComponent<Rigidbody2D>().velocity = Vector2.right * gameManager.Multiplier;

            gameManager.fireballReady = false;
        }

    }
}
