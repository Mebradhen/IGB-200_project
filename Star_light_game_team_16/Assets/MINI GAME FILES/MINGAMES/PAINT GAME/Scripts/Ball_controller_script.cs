using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [RequireComponent(typeof(Rigidbody2D))]
public class Ball_controller_script : MonoBehaviour
{
    public float speed = 90;

    private Rigidbody2D rb;
    private Vector2 movementVector;

    public GameObject paint_smoge_green;

    public GameObject paint_smoge_red;

    public GameObject paint_smoge_blue;

    private GameObject red_ball;

    private GameObject green_ball;

    private GameObject blue_ball;

    private float paint_wait = 0;

    private float paint_height = 0;

    private GameObject gameController;

    private GameObject the_paint_color;

    private int the_colour_choosen = 0; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementVector = Vector2.zero;

        //Alex's Edits feel free to change
        gameController = GameObject.FindGameObjectWithTag("GameController");

        red_ball = this.transform.Find("Sphere_red").gameObject;

        green_ball = this.transform.Find("Sphere_green").gameObject;

        blue_ball = this.transform.Find("Sphere_blue").gameObject;

    }

    void Update()
    {
        the_color();

        EventController EC = gameController.GetComponent<EventController>();
        if (EC.miniGame_Start)
        {
            if (transform.position.x > 8.0f)
            {
                movementVector.x = -1;
            }
            else if (transform.position.x < -8.0f)
            {
                movementVector.x = 1;
            }
            else
            {
                movementVector.x = Input.GetAxis("Horizontal");
            }


            if (transform.position.y > 6.0f)
            {
                movementVector.y = -1;
            }
            else if (transform.position.y < -2.0f)
            {
                movementVector.y = 1;
            }
            else
            {
                movementVector.y = Input.GetAxis("Vertical") ;
            }

            paint_wait += 15.0f * Time.deltaTime;

            movementVector *= speed;

            movementVector *= Time.deltaTime;

            rb.velocity = movementVector;

           

            if ((movementVector.x > 0.3f || movementVector.x < -0.3f) || (movementVector.y > 0.3f || movementVector.y < -0.3f))
            {
                if (paint_wait > 1.0f)
                {
                    paint_height += 0.0001f * Time.deltaTime;

                    Instantiate(the_paint_color, new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f - paint_height), transform.rotation);


                    paint_wait = 0.00f;
                }
            }

        }
    }

    void the_color()
    {
        if(Input.GetKey("joystick button 0"))
        {
            the_colour_choosen = 0;
        }

        if (Input.GetKey("joystick button 1"))
        {
            the_colour_choosen = 1;
        }

        if (Input.GetKey("joystick button 2"))
        {
            the_colour_choosen = 2;
        }

        switch (the_colour_choosen)
        {
            case 0:
                the_paint_color = paint_smoge_green;

                green_ball.SetActive(true);
                red_ball.SetActive(false);
                blue_ball.SetActive(false);

                break;
            case 1:
                the_paint_color = paint_smoge_red;

                green_ball.SetActive(false);
                red_ball.SetActive(true);
                blue_ball.SetActive(false);

                break;
            case 2:
                the_paint_color = paint_smoge_blue;

                green_ball.SetActive(false);
                red_ball.SetActive(false);
                blue_ball.SetActive(true);

                break;
        }

    }
    
}
