using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour

{
    public float downTime, upTime = 0;    
    public bool ready = false;
    private bool moving = false;
    public float timeCheck;
    public static bool onGround = false;
    public Vector2 movementVector;
    private Rigidbody2D rb;
    public float speed = 90;
    private GameObject gameController;
    public Sprite sprite2;
    public Sprite sprite1;
    private SpriteRenderer spriteRenderer;
    private GameObject gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        rb = GetComponent<Rigidbody2D>();
        gameObjects = GameObject.FindGameObjectWithTag("jumpBar");
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround == true)
        {
            gameObjects.SetActive(true);
            spriteRenderer.sprite = sprite1;
            movementVector.y = Input.GetAxis("Vertical");
            speed = (downTime - timeCheck) * 120;
        }
        else
        {
            gameObjects.SetActive(false);
        }
        Jump();
        if (moving == true)
        {
            spriteRenderer.sprite = sprite2;
            onGround = false;
            rb.AddForce(transform.up *speed);
            moving = false;
        }
       
    }

    void Jump()
    {
        if (movementVector.y > -0.9 && (downTime - timeCheck) > 0)
        {
            moving = true;
            movementVector.y = -1;
        }

        if (movementVector.y <= -0.9 && moving != true && onGround == true)
        {            
            downTime = Time.time;                     
        }

        else if (moving != true)
        {
            timeCheck = Time.time;
        }
                
    }

    void OnTriggerEnter2D(Collider2D other)
    
    {
        EventController EC = gameController.GetComponent<EventController>();

        if (other.gameObject.tag == "Level3")
        {
            moving = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            EC.miniGame_Ended = true;
        }

        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            moving = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            onGround = true;
        }
    }
    

    
}
